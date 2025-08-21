namespace PresupuestitoBack.DTOs.Request
{
    public class EmployeeHistoryRequestDto
    {
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId {  get; set; }
    }
}
