namespace PresupuestitoBack.DTOs.Request
{
    public class InvoiceRequestDto
    {
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public int SupplierId { get; set; }

    }
}
