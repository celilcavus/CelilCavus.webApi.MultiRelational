namespace CelilCavus.Entitys
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string HouseType { get; set; }
        public string City { get; set; }

        public Vehicle Vehicle { get; set; }
        public Order Order { get; set; }
    }
}