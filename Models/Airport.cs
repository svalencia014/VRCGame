using System;
namespace VrcGame
{
	public class Airport
	{
		public string ICAO { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
		public int Elevation { get; set; }
		public int ADR { get; set; } //Airport departure rate (per hour)
		public int AAR { get; set; } //Airport arrival rate (per hour)
		public List<Coordinate> Taxiways { get; set; }
		public List<Coordinate> Parking { get; set; }
		public List<Runway> Runways { get; set; }

		public Airport(string icao, double lat, double lng, int elev)
		{
			ICAO = icao;
			Latitude = lat;
			Longitude = lng;
			Elevation = elev;

			Taxiways = new List<Coordinate>();
			Parking = new List<Coordinate>();
			Runways = new List<Runway>();
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

		public double[] TaxiwayQuery(string taxiway) {
			double[] coordinates = new double[2];
			IEnumerable<double> latitudeQuery = from Coordinate in Taxiways where Coordinate.Label == taxiway select Coordinate.Latitude;
			IEnumerable<double> longitudeQuery = from Coordinate in Taxiways where Coordinate.Label == taxiway select Coordinate.Longitude;
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

		public double[] ParkingQuery(string spot) {
			double[] coordinates = new double[2];
			IEnumerable<double> latitudeQuery = from Coordinate in Parking where Coordinate.Label == spot select Coordinate.Latitude;
			IEnumerable<double> longitudeQuery = from Coordinate in Parking where Coordinate.Label == spot select Coordinate.Longitude;
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

