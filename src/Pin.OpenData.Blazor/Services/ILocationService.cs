using Pin.OpenData.Blazor.Models;

namespace Pin.OpenData.Blazor.Services
{
    public interface ILocationService
    {
        List<Location> GetLocations();
        Location GetLocation(string id);
    }
}
