using System;
namespace VrcGame
{
	public class Airport
	{
		public string ICAO { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public int ADR; //Airport departure rate (per hour)
		public int AAR; //Airport arrival rate (per hour)
		public List<Coordinate> Taxiways;
		public List<Coordinate>? Parking;
		public List<Runway> Runways;

		public Airport()
		{

		}

		public void AddTaxiway(string name, double Lat, double Lng)
		{
			Taxiways.Add(new Coordinate(name, Lat, Lng));
		}

		public void AddRunway(string name, double Lat, double Lng, int Heading)
		{
			Runways.Add(new Runway(name, Lat, Lng, Heading));
		}

		public double[] RunwayQuery(string runway)
		{
			double[] coordinates = new double[2];
			IEnumerable<double> latitudeQuery = from Runway in Runways where Runway.Id == runway select Runway.Latitude;
			IEnumerable<double> longitudeQuery = from Runway in Runways where Runway.Id == runway select Runway.Longitude;
			foreach (double coord in latitudeQuery)
			{
				coordinates[0] = coord;
			}
			foreach (double coord in longitudeQuery)
			{
				coordinates[1] = coord;
			}

			return coordinates;
		}
	}
	//Define Airport properties here later
	public class Coordinate
	{
		public string Label;
		public double Latitude;
		public double Longitude;

		public Coordinate(string label, double lat, double lng)
		{
			Label = label;
			Latitude = lat;
			Longitude = lng;
		}
	}
}

