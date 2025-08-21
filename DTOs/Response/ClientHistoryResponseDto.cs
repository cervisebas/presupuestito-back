namespace PresupuestitoBack.DTOs.Response
{
    public class ClientHistoryResponseDto
    {
        public int ClientHistoryId { get; set; }
        public ClientResponseDto ClientId {  get; set; }
        public List<BudgetResponseDto> BudgetsId { get; set; }
    }
}
