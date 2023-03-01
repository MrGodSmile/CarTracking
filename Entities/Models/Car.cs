namespace CarTracking.Entities.Models
{
    public class Car
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public int DriverId { get; set; }
        public int CarRouteId { get; set; }  
        public Driver Driver { get; set; }
        public CarRoute CarRoute { get; set; }
    }
}
