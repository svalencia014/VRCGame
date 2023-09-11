using System;
namespace VrcGame
{
	public class Parser
	{
		public static Facility LoadFile(string path)
		{
			Console.WriteLine("Loading Facility");
			if (!path.EndsWith(".json"))
			{
				Console.WriteLine("Invalid File Type! Expected a JSON");
				Environment.Exit(1);
				return null;
			}
			else if (!File.Exists(path))
			{
				Console.WriteLine("File Not Found!");
				Environment.Exit(1);
				return null;
			}

			string FacilityFile = File.ReadAllText(path);
			if (FacilityFile == null)
			{
				Console.WriteLine("File is Empty!");
				Environment.Exit(1);
				return null;
			}
			Console.WriteLine("Parsing Facility");
			dynamic config;
	}
}

