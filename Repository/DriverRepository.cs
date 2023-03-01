using CarTracking.Data;
using CarTracking.Entities;
using CarTracking.Entities.DataModel;
using CarTracking.Entities.Models;
using CarTracking.Interfaces;

namespace CarTracking.Repository
{
    public class DriverRepository : IDriverRepository
    {
        private readonly DataContext _context;
        public DriverRepository(DataContext context)
        {
            _context = context;
        }
        public bool DriverExists(int id)
        {
            return _context.Drivers.Any(c => c.Id == id);
        }

        public bool CreateDriver(DriverDataModel driverDataModel)
        {
            _context.Add(new Driver
            {
                Id = driverDataModel.Id,
                FIO = driverDataModel.FIO,
                Age= driverDataModel.Age,
                Sex= driverDataModel.Sex
            });
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
        public Driver GetDriver(int id)
        {
            return _context.Drivers.Where(c => c.Id == id).FirstOrDefault();
        }
        public bool DeleteDriver(int id)
        {
            _context.Remove(_context.Drivers.Where(c => c.Id == id).FirstOrDefault());
            return Save();
        }
        public bool UpdateDriver(DriverDataModel driverDataModel)
        {
            _context.Update(TransformData.ToDriver(driverDataModel));
            return Save();
        }
        public IEnumerable<Driver> GetDrivers()
        {
            return _context.Drivers.ToList();
        }
    }
}
