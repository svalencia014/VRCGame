using System;
namespace VrcGame
{
	public class Runway
	{
		public string Id { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public int Heading { get; set; }

		public Runway(string id, double latitude, double longitude, int heading)
		{
			Id = id;
			Latitude = latitude;
			Longitude = longitude;
			Heading = heading;
		}
	}
}

