namespace PresupuestitoBack.DTOs.Request
{
    public class FixedCostRequestDto
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int WorkingDays { get; set; }
        public int HoursWorked { get; set; }
        public DateOnly DateCharged { get; set; }
    }
}
