using CarTracking.Entities.DataModel;
using CarTracking.Entities.Models;

namespace CarTracking.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars();
        Car GetCar(int id);
        bool CarExists(int id);
        bool CreateCar(CarDataModel carDataModel);
        bool Save();
        bool DeleteCar(int id);
        bool UpdateCar(CarDataModel carDataModel);
    }
}