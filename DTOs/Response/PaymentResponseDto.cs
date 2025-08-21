namespace PresupuestitoBack.DTOs.Response
{
    public class PaymentResponseDto
    {
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string PaymentDescription { get; set; }
        public InvoiceItemResponseDto Invoice { get; set; }
        public BudgetResponseDto Budget { get; set; }
    }
}
