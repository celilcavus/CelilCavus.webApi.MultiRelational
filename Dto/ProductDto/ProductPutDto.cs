namespace CelilCavus.Dto.ProductDto
{
    public class ProductPutDto
    {
        public int Id { get; set; }
        public string Quantiity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
    }
}