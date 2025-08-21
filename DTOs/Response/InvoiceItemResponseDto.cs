namespace PresupuestitoBack.DTOs.Response
{
    public class InvoiceItemResponseDto
    {
        public int InvoiceItemId { get; set; }
        public MaterialResponseDto OMaterial { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public int InvoiceId { get; set; }
    }
}
