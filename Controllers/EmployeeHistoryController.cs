using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeHistoryController : ControllerBase
    {
        private readonly EmployeeHistoryService employeeHistoryService;

        public EmployeeHistoryController(EmployeeHistoryService employeeHistoryService)
        {
            this.employeeHistoryService = employeeHistoryService;
        }

        [HttpPost]
        public async Task CreateEmployeeHistory([FromBody] EmployeeHistoryRequestDto employeeHistoryRequestDto)
        {
            await employeeHistoryService.CreateEmployeeHistory(employeeHistoryRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateEmployeeHistory(int id, [FromBody] EmployeeHistoryRequestDto employeeHistoryRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await employeeHistoryService.UpdateEmployeeHistory(id, employeeHistoryRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeHistoryResponseDto>> GetEmployeeHistoryById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var employeeHistory = await employeeHistoryService.GetEmployeeHistoryById(id);
            return Ok(employeeHistory);
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeHistoryResponseDto>>> GetAllEmployeeHistories()
        {
            return await employeeHistoryService.GetAllEmployeeHistories();
        }

        [HttpPatch("{id}")]
        public async Task DeleteEmployeeHistory(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await employeeHistoryService.DeleteEmployeeHistory(id);
        }

    }
}
