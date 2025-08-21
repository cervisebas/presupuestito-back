using PresupuestitoBack.Models;

namespace PresupuestitoBack.DTOs.Response
{
    public class BudgetResponseDto
    {
        public int BudgetId { get; set; }
        public List<WorkResponseDto> Works { get; set; }
        public decimal Cost { get; set; }
        public string DescriptionBudget { get; set; }
        public ClientResponseDto ClientId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DeadLine { get; set; }
        public string BudgetStatus { get; set; }

    }
}
