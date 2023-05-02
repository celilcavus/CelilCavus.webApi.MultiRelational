namespace CelilCavus.Dto.VehicleDto
{
    public class VehiclePutDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }
}