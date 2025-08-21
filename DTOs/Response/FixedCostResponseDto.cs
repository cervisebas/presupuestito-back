namespace PresupuestitoBack.DTOs.Response
{
    public class FixedCostResponseDto
    {
        public int FixedCostId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int WorkingDays { get; set; }
        public int HoursWorked { get; set; }
        public DateOnly DateCharged { get; set; }
    }
}
