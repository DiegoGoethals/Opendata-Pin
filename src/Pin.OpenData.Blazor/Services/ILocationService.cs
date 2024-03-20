using Pin.OpenData.Blazor.Models;

namespace Pin.OpenData.Blazor.Services
{
    public interface ILocationService
    {
        List<Location> GetLocations();
        Location GetLocation(string name);
        void AddLocation(Location location);
        void DeleteLocation(Location location);
    }
}
