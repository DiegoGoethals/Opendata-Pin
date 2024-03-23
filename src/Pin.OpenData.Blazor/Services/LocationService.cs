using Newtonsoft.Json;
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
					//var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/water.avif");

					//FileStream fileStream = File.OpenRead(imagePath);

					//var image =  new FormFile(fileStream, 0, fileStream.Length, null, Path.GetFileName(imagePath));

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
						}
					};
					locations.Add(location);
				}
			}
			return locations;
		}

		public Location GetLocation(Guid id)
        {
			return _locations.FirstOrDefault(l => l.Id == id);
		}

		public async Task AddLocation(Location location)
		{
			var (latitude, longitude) = await GeocodeAddressAsync(location.StreetName, location.HouseNumber, location.PostalCode, location.City);
			location.GeoPoint2D = new GeoPoint2D { Latitude = latitude, Longitude = longitude };
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

		private static async Task<(double latitude, double longitude)> GeocodeAddressAsync(string street, string houseNumber, string postalCode, string city)
		{
			try
			{
				string address = $"{street} {houseNumber}, {postalCode}, {city}";

				string apiUrl = $"https://nominatim.openstreetmap.org/search?format=json&q={Uri.EscapeDataString(address)}";

				using (var httpClient = new HttpClient())
				{
					httpClient.DefaultRequestHeaders.Add("User-Agent", "DrinkWaterGent/1.0");
					var response = await httpClient.GetAsync(apiUrl);
					if (response.IsSuccessStatusCode)
					{
						var json = await response.Content.ReadAsStringAsync();
						Console.WriteLine(json);
						dynamic results = JsonConvert.DeserializeObject(json);
						Console.WriteLine(results);
						if (results != null)
						{
							var resultObject = results[0];
							double latitude = resultObject["lat"];
							double longitude = resultObject["lon"];

							Console.WriteLine($"Geocoded address {address} to latitude {latitude} and longitude {longitude}");
							return (latitude, longitude);
						}
					}
				}
				return (0, 0);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error geocoding address: {ex.Message}");
				return (0, 0);
			}
		}
	}
}
