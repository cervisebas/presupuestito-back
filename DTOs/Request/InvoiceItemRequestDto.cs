namespace PresupuestitoBack.DTOs.Request
{
    public class InvoiceItemRequestDto
    {
        public int MaterialId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }   
        public int InvoiceId { get; set; }
    }
}
