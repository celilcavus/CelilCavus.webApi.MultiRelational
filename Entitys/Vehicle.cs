namespace CelilCavus.Entitys
{
    public class Vehicle
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }
}