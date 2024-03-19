using Newtonsoft.Json;
using Pin.OpenData.Blazor.Models;
using System.Reflection;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace Pin.OpenData.Blazor.Services
{
    public class LocationService : ILocationService
    {
        private readonly IWebHostEnvironment _env;

        public LocationService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public List<Location> GetLocations()
        {
            List<Location> locations = new List<Location>();

            string jsonFilePath = Path.Combine("C:\\Users\\diego\\source\\repos\\st-2-d-pe01-opendata-DiegoGoethals\\src\\Pin.OpenData.Core\\Data\\data.json");
            Console.WriteLine("JSON File Path: " + jsonFilePath);

            if (File.Exists(jsonFilePath))
            {
                string jsonData = File.ReadAllText(jsonFilePath);
                dynamic jsonObject = JsonConvert.DeserializeObject(jsonData);

                foreach (var item in jsonObject)
                {
                    Location location = new Location
                    {
                        Name = item.naam,
                        StreetName = item.straatnaam,
                        HouseNumber = item.huisnummer,
                        PostalCode = item.postcode,
                        City = item.gemeente,
                        Website = item.website,
                        Email = item.email,
                        Drinkwater = item.drinkwater,
                        GeoPoint2D = new GeoPoint2D
                        {
                            Lon = item.geo_point_2d.lon,
                            Lat = item.geo_point_2d.lat
                        },
                        Geometry = new Geometry
                        {
                            Type = item.geometry.type,
                            Coordinates = new GeoPoint2D
                            {
                                Lon = item.geometry.geometry.coordinates[0],
                                Lat = item.geometry.geometry.coordinates[1]
                            }
                        }
                    };

                    locations.Add(location);
                }
            }

            return locations;
        }
    }
}
