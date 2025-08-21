using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly SalaryService salaryService;

        public SalaryController(SalaryService salaryService)
        {
            this.salaryService = salaryService;
        }

        [HttpPost]
        public async Task CreateSalary([FromBody] SalaryRequestDto salaryRequestDto)
        {
            await salaryService.CreateSalary(salaryRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateSalary(int id, [FromBody] SalaryRequestDto salaryRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await salaryService.UpdateSalary(id, salaryRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SalaryResponseDto>> GetSalaryById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var salary = await salaryService.GetSalaryById(id);
            return Ok(salary);
        }

        [HttpGet]
        public async Task<ActionResult<List<SalaryResponseDto>>> GetAllSalaries()
        {
            return await salaryService.GetAllSalaries();
        }

        [HttpPatch("{id}")]
        public async Task DeleteSalary(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await salaryService.DeleteSalary(id);
        }

    }
}
