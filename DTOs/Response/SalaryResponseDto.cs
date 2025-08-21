namespace PresupuestitoBack.DTOs.Response
{
    public class SalaryResponseDto
    {
        public int SalaryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BillDate { get; set; }
        public PaymentResponseDto OPayment { get; set; }
    }
}
