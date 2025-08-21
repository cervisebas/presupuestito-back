using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostController : ControllerBase
    {
        private readonly CostService costService;

        public CostController(CostService costService)
        {
            this.costService = costService;
        }

        [HttpPost]
        public async Task CreateCost([FromBody] CostRequestDto costRequestDto)
        {
            await costService.CreateCost(costRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateCost(int id, [FromBody] CostRequestDto costRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await costService.UpdateCost(id, costRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CostResponseDto>> GetCostById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var cost = await costService.GetCostById(id);
            return Ok(cost);
        }

        [HttpGet]
        public async Task<ActionResult<List<CostResponseDto>>> GetAllCosts()
        {
            return await costService.GetAllCosts();
        }

        [HttpPatch("{id}")]
        public async Task DeleteCost(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await costService.DeleteCost(id);
        }

    }
}
