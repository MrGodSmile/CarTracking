using CarTracking.Entities.DataModel;
using CarTracking.Entities.Models;

namespace CarTracking.Interfaces
{
    public interface ICarRouteRepository
    {
        IEnumerable<CarRoute> GetCarRoutes();
        CarRoute GetCarRoute(int id);
        bool CarRouteExists(int id);
        bool CreateCarRoute(CarRouteDataModel carRouteDataModel);
        bool Save();
        bool DeleteCarRoute(int id);
        bool UpdateCarRoute(CarRouteDataModel carRouteDataModel);
    }
}
