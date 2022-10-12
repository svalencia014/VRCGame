using System;
using System.Net;
using System.IO;

using VRCServer.Extensions;
using Newtonsoft.Json.Serialization;

#pragma warning disable CS8604

namespace VRCServer.Core
{

    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("VRC Server V0.1");
            Console.WriteLine("What is the path of your Situation Folder?");
            string Path = Console.ReadLine();
            if (Path == "")
            {
                Console.WriteLine("You need to enter a path!");
                Environment.Exit(1);
            } else if (Path == "~")
            {
                Path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            }
            Readers.openSituation(Path);
        }
    }
}