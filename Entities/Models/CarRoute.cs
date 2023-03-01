namespace CarTracking.Entities.Models
{
    public class CarRoute
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string Destination { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
