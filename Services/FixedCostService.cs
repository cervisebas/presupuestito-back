using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class FixedCostService
    {
        private readonly IFixedCostRepository fixedCostRepository;
        private readonly IMapper mapper;

        public FixedCostService(IFixedCostRepository fixedCostRepository, IMapper mapper)
        {
            this.fixedCostRepository = fixedCostRepository;
            this.mapper = mapper;
        }

        public async Task CreateFixedCost(FixedCostRequestDto fixedCostRequestDto)
        {
            var fixedCost = mapper.Map<FixedCost>(fixedCostRequestDto);
            fixedCost.Status = true;
            await fixedCostRepository.Insert(fixedCost);
        }

        public async Task UpdateFixedCost(int id, FixedCostRequestDto fixedCostRequestDto)
        {
            var existingFixedCost = await fixedCostRepository.GetById(id);
            if (existingFixedCost == null)
            {
                throw new Exception("El costo fijo no existe");
            }
            else
            {
                mapper.Map(fixedCostRequestDto, existingFixedCost);
                await fixedCostRepository.Update(existingFixedCost);
            }
        }

        public async Task<ActionResult<FixedCostResponseDto>> GetFixedCostById(int id)
        {
            var fixedCost = await fixedCostRepository.GetById(id);
            if (fixedCost == null)
            {
                throw new KeyNotFoundException("El costo fijo no fue encontrado.");
            }
            else
            {
                return mapper.Map<FixedCostResponseDto>(fixedCost);
            }
        }

        public async Task<ActionResult<List<FixedCostResponseDto>>> GetAllFixedCosts()
        {
            var fixedCosts = await fixedCostRepository.GetAll();
            if (fixedCosts == null)
            {
                throw new Exception("Costos fijos no encontrados.");
            }
            else
            {
                return mapper.Map<List<FixedCostResponseDto>>(fixedCosts);
            }
        }

        public async Task DeleteFixedCost(int id)
        {
            var fixedCost = await fixedCostRepository.GetById(id);
            if (fixedCost == null)
            {
                throw new KeyNotFoundException("El costo fijo no fue encontrado.");
            }
            else
            {
                fixedCost.Status = false;
                await fixedCostRepository.Update(fixedCost);
            }
        }

    }
}
