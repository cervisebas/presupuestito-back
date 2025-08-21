namespace PresupuestitoBack.DTOs.Response
{
    public class SupplierHistoryResponseDto
    {
        public int SupplierHistoryId { get; set; }
        public int SupplierId { get; set; }
        public List<InvoiceItemResponseDto> OInvoices { get; set; }
    }
}
