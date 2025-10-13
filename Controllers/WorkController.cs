using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly WorkService workService;

        public WorkController(WorkService workService)
        {
            this.workService = workService;
        }

        [HttpPost]
        public async Task<ActionResult<WorkResponseDto>> CreateWork([FromBody] WorkRequestDto workRequestDto)
        {
            return await workService.CreateWork(workRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateWork(int id, [FromBody] WorkRequestDto workRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await workService.UpdateWork(id, workRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkResponseDto>> GetWorkById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var work = await workService.GetWorkById(id);
            return Ok(work);
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkResponseDto>>> GetAllWorks()
        {
            return await workService.GetAllWorks();
        }

        [HttpPatch("{id}")]
        public async Task DeleteWork(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await workService.DeleteWork(id);
        }

    }
}
