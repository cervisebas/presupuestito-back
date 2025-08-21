using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class CostService
    {
        private readonly ICostRepository costRepository;
        private readonly IMapper mapper;

        public CostService(ICostRepository costRepository, IMapper mapper)
        {
            this.costRepository = costRepository;
            this.mapper = mapper;
        }

        public async Task CreateCost(CostRequestDto costRequestDto)
        {
            var cost = mapper.Map<Cost>(costRequestDto);
            cost.Status = true;
            await costRepository.Insert(cost);
        }

        public async Task UpdateCost(int id, CostRequestDto costRequestDto)
        {
            var existingCost = await costRepository.GetById(id);
            if (existingCost == null)
            {
                throw new Exception("El costo no existe");
            }
            else
            {
                mapper.Map(costRequestDto, existingCost);
                await costRepository.Update(existingCost);
            }
        }

        public async Task<ActionResult<CostResponseDto>> GetCostById(int id)
        {
            var cost = await costRepository.GetById(id);
            if(cost == null)
            {
                throw new KeyNotFoundException("El costo no fue encontrado");
            }
            else
            {
                return mapper.Map<CostResponseDto>(cost);
            }
        }

        public async Task<ActionResult<List<CostResponseDto>>> GetAllCosts()
        {
            var costs = await costRepository.GetAll();
            if(costs == null)
            {
                throw new Exception("Los costos no fueron encontrados");
            }
            else
            {
                return mapper.Map<List<CostResponseDto>>(costs);
            }
        }

        public async Task DeleteCost(int id)
        {
            var cost = await costRepository.GetById(id);
            if(cost == null)
            {
                throw new KeyNotFoundException("El costo no fue encontrado");
            }
            else
            {
                cost.Status = false;
                await costRepository.Update(cost);
            }
        }

    }
}