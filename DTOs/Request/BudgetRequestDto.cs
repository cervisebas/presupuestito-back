namespace PresupuestitoBack.DTOs.Request
{
    public class BudgetRequestDto
    {
        public string DescriptionBudget { get; set; }
        public int ClientId { get; set; }
        public string BudgetStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DeadLine { get; set; }
    }
}
