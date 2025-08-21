using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientHistoryController : ControllerBase
    {
        private readonly ClientHistoryService clientHistoryService;

        public ClientHistoryController(ClientHistoryService clientHistoryService)
        {
            this.clientHistoryService = clientHistoryService;
        }
        /*
        [HttpPost]
        public async Task CreateClientHistory([FromBody] ClientHistoryRequestDto clientHistoryRequestDto)
        {
            await clientHistoryService.CreateClientHistory(clientHistoryRequestDto);
        }
        */
        [HttpPut("{id}")]
        public async Task UpdateClientHistory(int id, [FromBody] ClientHistoryRequestDto clientHistoryRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await clientHistoryService.UpdateClientHistory(id, clientHistoryRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientHistoryResponseDto>> GetClientHistoryById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var clientHistory = await clientHistoryService.GetClientHistoryById(id);
            return Ok(clientHistory);
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientHistoryResponseDto>>> GetAllClientHistories()
        {
            return await clientHistoryService.GetAllClientHistories();
        }

        [HttpPatch("{id}")]
        public async Task DeleteClientHistory(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await clientHistoryService.DeleteClientHistory(id);
        }

    }
}