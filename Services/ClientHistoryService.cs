using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class ClientHistoryService
    {
        private readonly IClientHistoryRepository clientHistoryRepository;
        private readonly IMapper mapper;

        public ClientHistoryService(IClientHistoryRepository clientHistoryRepository, IMapper mapper)
        {
            this.clientHistoryRepository = clientHistoryRepository;
            this.mapper = mapper;
        }

        public async Task CreateClientHistory(int ClientId)
        {
            
            /*
            var existingClientHistory = await clientHistoryRepository.GetById(ClientId);
            if (existingClientHistory == null)
            {
                ClientHistory clientHistory = new ClientHistory();
                clientHistory.ClientId = ClientId;
                clientHistory.Status = true;
                await clientHistoryRepository.Insert(clientHistory);
            }
            */
        }

        public async Task UpdateClientHistory(int id, ClientHistoryRequestDto clientHistoryRequestDto)
        {
            var existingClientHistory = await clientHistoryRepository.GetById(id);
            if (existingClientHistory == null)
            {
                throw new Exception("El historial del cliente no existe");
            }

            mapper.Map(clientHistoryRequestDto, existingClientHistory);
            await clientHistoryRepository.Update(existingClientHistory);
        }

        public async Task<ActionResult<ClientHistoryResponseDto>> GetClientHistoryById(int id)
        {
            var clientHistory = await clientHistoryRepository.GetById(id);
            if (clientHistory == null)
            {
                throw new KeyNotFoundException("El historial del cliente no fue encontrado.");
            }
            else
            {
                return mapper.Map<ClientHistoryResponseDto>(clientHistory);
            }
        }

        public async Task<ActionResult<List<ClientHistoryResponseDto>>> GetAllClientHistories()
        {
            var clientHistories = await clientHistoryRepository.GetAll();
            if (clientHistories == null)
            {
                throw new Exception("Historiales de clientes no encontrados.");
            }
            else
            {
                return mapper.Map<List<ClientHistoryResponseDto>>(clientHistories);
            }
        }

        public async Task DeleteClientHistory(int id)
        {
            var clientHistory = await clientHistoryRepository.GetById(id);
            if (clientHistory == null)
            {
                throw new KeyNotFoundException("El historial del cliente no fue encontrado.");
            }
            else
            {
                clientHistory.Status = false; 
                await clientHistoryRepository.Update(clientHistory);
            }
        }

    }
}
