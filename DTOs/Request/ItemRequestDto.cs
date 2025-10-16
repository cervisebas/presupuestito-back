namespace PresupuestitoBack.DTOs.Request
{
    public class ItemRequestDto
    {
        public int MaterialId { get; set; }
        public int WorkId { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
