using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class WorkService
    {
        private readonly IWorkRepository workRepository;
        private readonly IMapper mapper;
        private readonly MaterialService materialService;

        public WorkService(IWorkRepository workRepository, IMapper mapper, MaterialService materialService)
        {
            this.workRepository = workRepository;
            this.mapper = mapper;
            this.materialService = materialService;
        }

        public async Task<ActionResult<WorkResponseDto>> CreateWork(WorkRequestDto workRequestDto)
        {
            var work = mapper.Map<Work>(workRequestDto);
            work.Status = true;

            var newWork = await workRepository.Insert(work);
            return mapper.Map<WorkResponseDto>(newWork);
        }

        public async Task UpdateWork(int id, WorkRequestDto workRequestDto)
        {
            var existingWork = await workRepository.GetById(id);
            if (existingWork == null)
            {
                throw new Exception("El trabajo no existe");
            }
            else
            {
                mapper.Map(workRequestDto, existingWork);
                await workRepository.Update(existingWork);
            }
        }

        public async Task<ActionResult<WorkResponseDto>> GetWorkById(int id)
        {
            var work = await workRepository.GetById(id);
            return mapper.Map<WorkResponseDto>(work);
        }

        public async Task<ActionResult<List<WorkResponseDto>>> GetAllWorks()
        {
            var works = await workRepository.GetAll();
            if (works == null)
            {
                throw new Exception("Trabajos no encontrados.");
            }
            else
            {
                foreach (var work in works)
                {
                    await CalculateTotalWorkPrice(work.WorkId);
                }
                return mapper.Map<List<WorkResponseDto>>(works);
            }
        }

        public async Task DeleteWork(int id)
        {
            var work = await workRepository.GetById(id);
            if (work == null)
            {
                throw new KeyNotFoundException("El trabajo no fue encontrado.");
            }
            else
            {
                work.Status = false;
                await workRepository.Update(work);
            }
        }
        
        public async Task<decimal> CalculateTotalWorkPrice(int WorkId)
        {
            decimal WorkPrice = 0;
            var work = await workRepository.GetById(WorkId);
            foreach(var item in work.OMaterials)
            {
                int MaterialId = item.MaterialId;
                decimal MaterialQuantity = item.Quantity;
                WorkPrice += await materialService.CalculateSubTotal(MaterialId, MaterialQuantity);
            }
            work.CostPrice = WorkPrice;
            await workRepository.Update(work);
            return WorkPrice;
        }
        
    }
}
