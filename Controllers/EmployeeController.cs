using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        public async Task CreateEmployee([FromBody] PersonRequestDto personRequestDto)
        {
            await employeeService.CreateEmployee(personRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateEmployee(int id,[FromBody] PersonRequestDto personRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await employeeService.UpdateEmployee(id, personRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeResponseDto>> GetEmployeeById(int id)
        {
            
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var employee = await employeeService.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeeResponseDto>>> getAllEmployees()
        {
            return await employeeService.GetAllEmployees();
        }

        [HttpPatch]
        public async Task DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await employeeService.DeleteEmployee(id);
        }

    }
}
