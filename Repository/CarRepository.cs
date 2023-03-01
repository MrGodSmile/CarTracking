using CarTracking.Data;
using CarTracking.Entities;
using CarTracking.Entities.DataModel;
using CarTracking.Entities.Models;
using CarTracking.Interfaces;

namespace CarTracking.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly DataContext _context;
        
        public CarRepository(DataContext context)
        {
            _context = context;
        }
        public bool CarExists(int id)
        {
            return _context.Cars.Any(c => c.Id == id);
        }

        public bool CreateCar(CarDataModel carDataModel)
        {
            _context.Add(new Car
            {
                Id = carDataModel.Id,
                Name = carDataModel.Name,
                CarRouteId= carDataModel.CarRouteId,
                DriverId = carDataModel.DriverId,
                Type = carDataModel.Type,
                Number= carDataModel.Number
            });
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
        public Car GetCar(int id)
        {
            return _context.Cars.Where(c => c.Id == id).FirstOrDefault();
        }
        public bool DeleteCar(int id)
        {
            _context.Remove(_context.Cars.Where(c => c.Id == id).FirstOrDefault());
            return Save();
        }
        public bool UpdateCar(CarDataModel carDataModel)
        {
            _context.Update(TransformData.ToCar(carDataModel));
            return Save();
        }
        public IEnumerable<Car> GetCars()
        {
            return _context.Cars.ToList();
        }
    }
}
