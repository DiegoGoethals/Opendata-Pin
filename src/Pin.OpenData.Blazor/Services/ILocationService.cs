using Pin.OpenData.Blazor.Models;

namespace Pin.OpenData.Blazor.Services
{
    public interface ILocationService
    {
        List<Location> GetLocations();
        Location GetLocation(Guid id);
        Task AddLocation(Location location);
        void DeleteLocation(Location location);
        void UpdateLocation(Location location);
	}
}
