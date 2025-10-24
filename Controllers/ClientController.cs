using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService clientService;        

        public ClientController(ClientService clientService)
        {
            this.clientService = clientService;           
        }

        [HttpPost]
        public async Task CreateClient([FromBody] PersonRequestDto personRequestDto)
        {
            await clientService.CreateClient(personRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateClient(int id, [FromBody] PersonRequestDto personRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await clientService.UpdateClient(id, personRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientResponseDto>> GetClientById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var client = await clientService.GetClientById(id);
            return Ok(client);
        }

        [HttpGet]
        public async Task<ActionResult<List<ClientResponseDto>>> GetAllClients()
        {
            return await clientService.GetAllClients();
        }

        [HttpDelete("{id}")]
        public async Task DeleteClient(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await clientService.DeleteClient(id);
        }

    }
}