using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly BudgetService budgetService;

        public BudgetController(BudgetService budgetService)
        {
            this.budgetService = budgetService;
        }

        [HttpPost]
        public async Task CreateBudget([FromBody] BudgetRequestDto budgetRequestDto)
        {
            await budgetService.CreateBudget(budgetRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateBudget(int id, [FromBody] BudgetRequestDto budgetRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await budgetService.UpdateBudget(id, budgetRequestDto);
        }

        [HttpGet("ById/{id}")]
        public async Task<ActionResult<BudgetResponseDto>> GetBudgetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var budget = await budgetService.GetBudgetById(id);
            return (Ok(budget));
        }

        [HttpGet("ByClient/{ClientId}")]
        public async Task<ActionResult<List<BudgetResponseDto>>> GetBudgetsByClientId(int ClientId)
        {
            if (ClientId <= 0)
            {
                throw new Exception("Id invalido");
            }
            return await budgetService.GetBudgetsByClientId(ClientId);
        }

        [HttpGet]
        public async Task<ActionResult<List<BudgetResponseDto>>> GetBudgets()
        {
            return await budgetService.GetAllBudgets();
        }

        [HttpPatch("{id}")]
        public async Task DeleteBudget(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await budgetService.DeleteBudget(id);
        }

        [HttpGet("CalculatePrice/{BudgetId}")]
        public async Task<decimal> CalculateBudgetPrice(int BudgetId)
        {
            if (BudgetId <= 0)
            {
                throw new Exception("Id invalido");
            }
            return await budgetService.CalculateTotalPriceBudget(BudgetId);
        }

    }
}