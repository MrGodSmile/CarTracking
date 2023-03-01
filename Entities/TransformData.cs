using CarTracking.Entities.DataModel;
using CarTracking.Entities.Models;

namespace CarTracking.Entities
{
    public static class TransformData
    {
        public static CarDataModel ToCarDataModel(Car car)
        {
            return new CarDataModel
            {
                Id = car.Id,
                Name= car.Name,
                Type    = car.Type,
                Number= car.Number,
                DriverId=car.DriverId,
                CarRouteId=car.CarRouteId
            };
        }
        public static Car ToCar(CarDataModel carDataModel)
        {
            return new Car
            {
                Id= carDataModel.Id,
                Name= carDataModel.Name,
                Type = carDataModel.Type,
                Number= carDataModel.Number,
                DriverId=carDataModel.DriverId,
                CarRouteId=carDataModel.CarRouteId
            };
        }

        public static CarRouteDataModel ToCarRouteDataModel(CarRoute carRoute)
        {
            return new CarRouteDataModel
            {
                Id = carRoute.Id,
                From = carRoute.From,
                Destination = carRoute.Destination
            };
        }
        public static CarRoute ToCarRoute(CarRouteDataModel carRouteDataModel)
        {
            return new CarRoute
            {
                Id = carRouteDataModel.Id,
                From = carRouteDataModel.From,
                Destination = carRouteDataModel.Destination
            };
        }
        public static DriverDataModel ToDriverDataModel(Driver driver)
        {
            return new DriverDataModel
            {
                Id = driver.Id,
                Age = driver.Age,
                FIO = driver.FIO,
                Sex = driver.Sex 
            };
        }
        public static Driver ToDriver(DriverDataModel driverDataModel)
        {
            return new Driver
            {
                Id = driverDataModel.Id,
                Age = driverDataModel.Age,
                FIO = driverDataModel.FIO,
                Sex = driverDataModel.Sex
            };
        }
    }
}
