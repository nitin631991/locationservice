using LocationService.Models;

namespace LocationService.Data{
public interface ILocationRepo
{
   Location GetLocationByZip(int Zip);
    List<Location> GetAllLocations();
}
}
