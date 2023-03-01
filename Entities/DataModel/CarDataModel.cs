namespace CarTracking.Entities.DataModel
{
    public class CarDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public int DriverId { get; set; }
        public int CarRouteId { get; set; }
    }
}
