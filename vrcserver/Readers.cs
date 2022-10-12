using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

#pragma warning disable CS8618
#pragma warning disable CS8602

namespace VRCServer.Extensions
{
	public class Situation
	{
		public string Airport { get; set; }
		public string Elevation { get; set; }
		public string Position { get; set; }
	}

	public class SimulatedController
	{
		public string Callsign { get; set; }
		public string Frequency { get; set; }
	}
	
	public class Rules
	{
		
	}
	
	public class Readers
	{
		public static void openSituation(string FilePath)
		{
			Situation LoadedSituation = new();
			if (FilePath.EndsWith("\\"))
			{
				FilePath += "Situation.txt";
			} else
			{
				FilePath += "\\Situation.txt";
			}
			
			Console.WriteLine(FilePath);
			StreamReader r = new(FilePath);
			string File = r.ReadToEnd();
			string[] Config = File.Split("\n");
			Console.WriteLine(Config[0]);
			for (int i = 0; i < Config.Length; i++)
			{
				if (i == 0 && Config[i].StartsWith("AIRPORT"))
				{
					string[] Line = Config[0].Split(":");
					LoadedSituation.Airport = Line[1];
					LoadedSituation.Elevation = Line[2];
					LoadedSituation.Position = Line[3];
					Console.WriteLine("Airport Config Loaded");
				} else if (Config[i].StartsWith("CONTROLLER"))
				{
					string[] Line = Config[1].Split(":");
					SimulatedController Controller = new();
					Controller.Callsign = Line[2];
					Controller.Frequency = Line[3];
				}
				
			}			
		}
	}

}