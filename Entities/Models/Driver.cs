namespace CarTracking.Entities.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FIO { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public ICollection<Car> Cars { get; set;}
    }
}
