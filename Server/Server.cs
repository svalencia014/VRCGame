using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;

namespace VrcGame
{
    public class FSDServer
    {
        private static TcpListener _server;
        public static TcpClient Client;
        public static NetworkStream Stream;
        public static StreamReader Reader;
        public static Controller Player;
        public static Byte[] bytes = new byte[256];

        public static void Start()
        {
            _server = new TcpListener(IPAddress.Parse("127.0.0.1"), 6809);
            _server.Start();
            Console.WriteLine("Server Started. Connect to localhost or 127.0.0.1");

            while (true)
            {
                Client = _server.AcceptTcpClient();
                Stream = Client.GetStream();
                Send("$DISERVER:CLIENT:VATSIM FSD v3.13:abcdef12");
                Console.WriteLine("Client Connected");
                int i = 0;
                while (Client.Connected)
                {
                    while ((i = Stream.Read(bytes, 0, bytes.Length)) != 0) 
                    {
                        String data = Encoding.ASCII.GetString(bytes, 0, i);
                        if (data == null) break;
                        String[] dataLines = data.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                        foreach (var dataLine in dataLines)
                        {
                            ProcessData(dataLine);
                        }
                    }
                }
            }
        }

        public static void Send(string text)
        {
            byte[] msg = Encoding.UTF8.GetBytes($"{text}\r\n");
            Stream.Write(msg, 0, msg.Length);
        }

        public static void ProcessData(string data)
        {
            if (data.StartsWith("%"))
            {
                var tokens = data["%".Length..].Split(":");
                var from = tokens[0];
                var freq = tokens[1];

                if (from == Player.Callsign && freq != Player.Frequency)
                {
                    Player.Frequency = freq;
                    Console.WriteLine($"{Player.Callsign} changed to {Player.Frequency}");
                }
            }
            if (data.StartsWith("$ID"))
            {
                var info = data["$ID".Length..].Split(':');
                Player = new Controller(info[0], "199.998");
                Console.WriteLine($"Created new Player with callsign {Player.Callsign} on {Player.Frequency}");
            }

            if (data.StartsWith("#AA"))
            {
                var tokens = data["#AA".Length..].Split(":");
                var from = tokens[0];
                var realName = tokens[2];

                if (from == Player.Callsign)
                {
                    Send($"#TMserver:{Player.Callsign}:Connected to VRC-Game.");
                    Send($"#TMserver:{Player.Callsign}:VRC-Game Version 0.0.1");
                    Send($"$CRSERVER:{Player.Callsign}:ATC:Y:{Player.Callsign}");
                    Send($"$CRSERVER:{Player.Callsign}:IP:127.0.0.1");
                    Send($"$ZCSERVER:{Player.Callsign}:84b0829fc89d9d7848");
                    Console.WriteLine($"{Player.Callsign} Logged on!");
                }
            }
        }
    }
}