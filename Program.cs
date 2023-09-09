namespace VrcGame
{
    public class Program
    {
        public static FSDServer? fsdServer;
        public static void Main(string[] args)
        {
            Console.WriteLine("Initializing. Please Standby...");
            Initialize();
        }

        private static void Initialize()
        {
            FSDServer.Start();
        }
    }
}