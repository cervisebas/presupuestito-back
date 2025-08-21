namespace PresupuestitoBack.DTOs.Request
{
    public class PaymentRequestDto
    {
        public DateTime Date {  get; set; }
        public double Amount { get; set; }
        public string PaymentDescription { get; set; }
        public int InvoiceId { get; set; }
        public int BudgetId { get; set; }
    }
}
