namespace PresupuestitoBack.DTOs.Response
{
    public class EmployeeHistoryResponseDto
    {
        public int EmployeeHistoryId { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
        public EmployeeResponseDto EmployeeId { get; set; }
    }
}
