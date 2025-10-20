using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService personService;

        public PersonController(PersonService personService)
        {
            this.personService = personService;
        }

        [HttpPost]
        public async Task CreatePerson([FromBody] PersonRequestDto personRequestDto)
        {
            await personService.CreatePerson(personRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdatePerson(int id, [FromBody] PersonRequestDto personRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await personService.UpdatePerson(id, personRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponseDto>> GetPersonById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var person = await personService.GetPersonById(id);
            return Ok(person);
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonResponseDto>>> GetAllPersons()
        {
            return await personService.GetAllPersons();
        }
        
        [HttpGet("/Localities")]
        public async Task<ActionResult<List<string>>> GetAllLocalities()
        {
            return await personService.GetAllLocalities();
        }

        [HttpPatch("{id}")]
        public async Task DeletePerson(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await personService.DeletePerson(id);
        }

    }
}
