using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs.Response
{
    public class InvoiceResponseDto
    {
        public List<InvoiceItemResponseDto> OInvoiceItems { get; set; }
        public int InvoiceId { get; set; }
        public DateTime Date { get; set; }
        public bool IsPaid { get; set; }
        public Supplier OSupplier { get; set; }        
    }
}
