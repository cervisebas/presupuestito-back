using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class PersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IMapper mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            this.personRepository = personRepository;
            this.mapper = mapper;
        }

        public async Task<Person> CreatePerson(PersonRequestDto personRequestDto)
        {
            var person = mapper.Map<Person>(personRequestDto);
            person.Status = true;
            await personRepository.Insert(person);
            return await personRepository.GetLastCreatedPerson();
        }

        public async Task UpdatePerson(int id, PersonRequestDto personRequestDto)
        {
            var existingPerson = await personRepository.GetById(id);
            if (existingPerson == null)
            {
                throw new Exception("La persona no existe");
            }
            else
            {
                mapper.Map(personRequestDto, existingPerson);
                await personRepository.Update(existingPerson);
            }
        }

        public async Task<ActionResult<PersonResponseDto>> GetPersonById(int id)
        {
            var person = await personRepository.GetById(id);
            if (person == null)
            {
                throw new KeyNotFoundException("La persona no fue encontrada.");
            }
            return mapper.Map<PersonResponseDto>(person);
        }

        public async Task<ActionResult<List<PersonResponseDto>>> GetAllPersons()
        {
            var persons = await personRepository.GetAll();
            if (persons == null)
            {
                throw new Exception("Personas no encontradas.");
            }
            else
            {
                return mapper.Map<List<PersonResponseDto>>(persons);
            }
        }

        public async Task DeletePerson(int id)
        {
            var person = await personRepository.GetById(id);
            if (person == null)
            {
                throw new KeyNotFoundException("La persona no fue encontrada.");
            }
            else
            {
                person.Status = false;
                await personRepository.Update(person);
            }
        }

    }
}
