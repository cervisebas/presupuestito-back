using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs.Response
{
    public class WorkResponseDto
    {
        public int WorkId { get; set; }
        public string WorkName { get; set; }
        public int EstimatedHoursWorked { get; set; }
        public DateTime DeadLine { get; set; }
        public decimal CostPrice { get; set; }
        public List<ItemResponseDto> ItemsId { get; set; }
        public string Notes { get; set; }
        public string WorkStatus { get; set; }
        public int BudgetId { get; set; }
    }
}
