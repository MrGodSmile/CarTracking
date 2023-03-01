using CarTracking.Entities.DataModel;
using CarTracking.Entities.Models;

namespace CarTracking.Interfaces
{
    public interface IDriverRepository
    {
        IEnumerable<Driver> GetDrivers();
        Driver GetDriver(int id);
        bool DriverExists(int id);
        bool CreateDriver(DriverDataModel driverDataModel);
        bool Save();
        bool DeleteDriver(int id);
        bool UpdateDriver(DriverDataModel driverDataModel);
    }
}
