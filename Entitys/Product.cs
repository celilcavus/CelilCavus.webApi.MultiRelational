namespace CelilCavus.Entitys
{
    public class Product
    {
        public int Id { get; set; }
        public string Quantiity { get; set; }
        public decimal Price { get; set; }
    
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}