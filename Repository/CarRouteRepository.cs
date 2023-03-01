using CarTracking.Data;
using CarTracking.Entities;
using CarTracking.Entities.DataModel;
using CarTracking.Entities.Models;
using CarTracking.Interfaces;

namespace CarTracking.Repository
{
    public class CarRouteRepository : ICarRouteRepository
    {
        private readonly DataContext _context;
        public CarRouteRepository(DataContext context)
        {
            _context = context;
        }
        public bool CarRouteExists(int id)
        {
            return _context.CarRoutes.Any(c => c.Id == id);
        }
        
        public bool CreateCarRoute(CarRouteDataModel carRouteDataModel)
        {
            _context.Add(new CarRoute
            {
                Id = carRouteDataModel.Id,
                From = carRouteDataModel.From,
                Destination= carRouteDataModel.Destination
            });
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public CarRoute GetCarRoute(int id)
        {
            return _context.CarRoutes.Where(c => c.Id == id).FirstOrDefault();
        }
        public bool DeleteCarRoute(int id)
        {
            _context.Remove(_context.CarRoutes.Where(c => c.Id == id).FirstOrDefault());
            return Save();
        }

        public IEnumerable<CarRoute> GetCarRoutes()
        {
            return _context.CarRoutes.ToList();
        }
        public bool UpdateCarRoute(CarRouteDataModel carRouteDataModel)
        {
            _context.Update(TransformData.ToCarRoute(carRouteDataModel));
            return Save();
        }
    }
}
