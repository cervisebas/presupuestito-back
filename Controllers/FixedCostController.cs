using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FixedCostController : ControllerBase
    {
        private readonly FixedCostService fixedCostService;

        public FixedCostController(FixedCostService fixedCostService)
        {
            this.fixedCostService = fixedCostService;
        }

        [HttpPost]
        public async Task CreateFixedCost([FromBody] FixedCostRequestDto fixedCostRequestDto)
        {
            await fixedCostService.CreateFixedCost(fixedCostRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateFixedCost(int id, [FromBody] FixedCostRequestDto fixedCostRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await fixedCostService.UpdateFixedCost(id, fixedCostRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FixedCostResponseDto>> GetFixedCostById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var fixedCost = await fixedCostService.GetFixedCostById(id);
            return Ok(fixedCost);
        }

        [HttpGet]
        public async Task<ActionResult<List<FixedCostResponseDto>>> GetAllFixedCosts()
        {
            return await fixedCostService.GetAllFixedCosts();
        }

        [HttpPatch("{id}")]
        public async Task DeleteFixedCost(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await fixedCostService.DeleteFixedCost(id);
        }

    }
}
