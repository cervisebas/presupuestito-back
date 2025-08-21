namespace PresupuestitoBack.DTOs.Request
{
    public class SalaryRequestDto
    {
        public decimal Amount { get; set; }
        public DateTime BillDate { get; set; }
        public int EmployeeId { get; set; }
    }
}
