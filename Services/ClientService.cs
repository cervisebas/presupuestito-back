using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class ClientService
    {
        private readonly IClientRepository clientRepository;
        private readonly PersonService personService;
        private readonly IMapper mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper, PersonService personService)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
            this.personService = personService;
        }
        
        public async Task CreateClient(PersonRequestDto personRequestDto)
        {
            var client = await personService.CreatePerson(personRequestDto);
            Client cliente = new Client();
            cliente.PersonId = client.PersonId;
            cliente.Status = true;
            await clientRepository.Insert(cliente);
            
        }

        public async Task UpdateClient(int id, PersonRequestDto personRequestDto)
        {
            var existingClient = await clientRepository.GetById(id);
            if (existingClient == null)
            {
                throw new Exception("El cliente no existe");
            }
            else
            {
                // Actualiza la persona relacionada con el cliente
                var idPersona = existingClient.PersonId;
                await personService.UpdatePerson(idPersona, personRequestDto);

                // Si necesitas también actualizar los datos del cliente, debes tener un `clientRequestDto`
                // mapper.Map(clientRequestDto, existingClient);

                await clientRepository.Update(existingClient);
            }            
        }

        public async Task<ActionResult<ClientResponseDto>> GetClientById(int id)
        {
            var client = await clientRepository.GetById(id);
            return mapper.Map<ClientResponseDto>(client);
        }

        public async Task<ActionResult<List<ClientResponseDto>>> GetAllClients()
        {
            var clients = await clientRepository.GetAll();
            if (clients == null)
            {
                throw new Exception("Clientes no encontradas");
            }
            else
            {
                return mapper.Map<List<ClientResponseDto>>(clients);
            }
        }

        public async Task DeleteClient(int id)
        {
            var client = await clientRepository.GetById(id);
            if(client == null)
            {
                throw new KeyNotFoundException("El cliente no fue encontrado");
            }
            else
            {
                client.Status = false;
                await clientRepository.Update(client);
            }
        }

    }
}