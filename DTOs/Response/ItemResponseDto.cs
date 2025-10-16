namespace PresupuestitoBack.DTOs.Response
{
    public class ItemResponseDto
    {
        public int ItemId { get; set; }
        public MaterialResponseDto OMaterial { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
