using System;

namespace VrcGame
{
	public class Facility
	{
		public string Id;
		public enum FacilityType
		{
			Tower,
			Tracon,
			Tracab
		}
		public FacilityType Type;
		public List<Controller>? Positions;
		public List<Airport>? Airports;

		public Facility(string id, FacilityType type)
		{
			Id = id;
			Type = type;
			Positions = new List<Controller>();
			Airports = new List<Airport>();
		}
	}
}

