using System;

namespace VrcGame
{
	public class Facility
	{
		public string Id { get; set; }
		public enum FacilityType
		{
			Tower,
			Tracon,
			Tracab
		}
		public FacilityType Type { get; set; }
		public List<Controller> Positions { get; set; }
		public List<Airport> Airports { get; set; }

		public Facility(string id, FacilityType type)
		{
			Id = id;
			Type = type;
			Positions = new List<Controller>();
			Airports = new List<Airport>();
		}
	}
}

