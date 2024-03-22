﻿using Newtonsoft.Json;
using Pin.OpenData.Blazor.Models;

namespace Pin.OpenData.Blazor.Services
{
    public class LocationService : ILocationService
    {
        private static List<Location> _locations;

		public List<Location> GetLocations()
		{
			_locations ??= LoadLocationsFromJson();

			return _locations;
		}
		private static List<Location> LoadLocationsFromJson()
		{
			List<Location> locations = new List<Location>();

			string jsonFilePath = "../Pin.OpenData.Core/Data/data.json";

			if (File.Exists(jsonFilePath))
			{
				string jsonData = File.ReadAllText(jsonFilePath);
				dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

				foreach (var item in jsonObject)
				{
					var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/water.avif");

					FileStream fileStream = File.OpenRead(imagePath);

					var image =  new FormFile(fileStream, 0, fileStream.Length, null, Path.GetFileName(imagePath));

					Location location = new Location
					{
						Id = Guid.NewGuid(),
						Name = item.naam,
						StreetName = item.straatnaam,
						HouseNumber = item.huisnummer,
						PostalCode = item.postcode,
						City = item.gemeente,
						Website = item.website,
						Email = item.email,
						GeoPoint2D = new GeoPoint2D
						{
							Longitude = item.geo_point_2d.lon,
							Latitude = item.geo_point_2d.lat
						},
						Image = item.image ?? image
					};
					locations.Add(location);
				}
			}
			return locations;
		}

		public Location GetLocation(string name)
        {
			return _locations.FirstOrDefault(l => l.Name == name);
		}

		public void AddLocation(Location location)
		{
			   _locations.Add(location);
		}

		public void DeleteLocation(Location location)
		{
			_locations.Remove(location);
		}

		public void UpdateLocation(Location location)
		{
			var existingLocationIndex = _locations.FindIndex(l => l.Id == location.Id);
			_locations[existingLocationIndex] = location;
		}
    }
}
