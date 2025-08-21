using PresupuestitoBack.DTOs.Response;

namespace PresupuestitoBack.DTOs.Request
{
    public class WorkRequestDto
    {
        public int EstimatedHoursWorked { get; set; }
        public string WorkName {  get; set; }
        public DateTime DeadLine { get; set; }
        public decimal CostPrice { get; set; }
        public int BudgetId { get; set; }
        public string WorkStatus { get; set; }
        public string Notes { get; set; }
    }
}
