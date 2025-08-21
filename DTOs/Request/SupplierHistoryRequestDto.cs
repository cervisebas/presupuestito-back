namespace PresupuestitoBack.DTOs.Request
{
    public class SupplierHistoryRequestDto
    {
        public int SupplierId { get; set; }
        public List<int> InvoicesId { get; set; }
    }
}
