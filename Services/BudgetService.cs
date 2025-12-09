using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class BudgetService
    {
        private readonly IBudgetRepository budgetRepository;
        private readonly IMapper mapper;
        private readonly WorkService workService;
        private readonly ClientHistoryService clientHistoryService;

        private readonly IWorkRepository workRepository;
        public BudgetService(IBudgetRepository budgetRepository, IMapper mapper, WorkService workService, ClientHistoryService clientHistoryService, IWorkRepository workRepository)
        {
            this.workRepository = workRepository;
            this.budgetRepository = budgetRepository;
            this.mapper = mapper;
            this.workService = workService;
            this.clientHistoryService = clientHistoryService;
        }

        public async Task<ActionResult<BudgetResponseDto>> CreateBudget(BudgetRequestDto budgetRequestDto)
        {
            var budget = mapper.Map<Budget>(budgetRequestDto);
            budget.Status = true;

            var newBudget = await budgetRepository.Insert(budget);
            return mapper.Map<BudgetResponseDto>(newBudget);
        }

        public async Task UpdateBudget(int id, BudgetRequestDto budgetRequestDto)
        {
            var existingBudget = await budgetRepository.GetById(id);
            if (existingBudget == null)
            {
                throw new Exception("El presupuesto no existe");
            }
            else
            {
                mapper.Map(budgetRequestDto, existingBudget);
                await budgetRepository.Update(existingBudget);
            }
        }

        public async Task<ActionResult<BudgetResponseDto>> GetBudgetById(int id)
        {
            var budget = await budgetRepository.GetById(id);
            var dto = mapper.Map<BudgetResponseDto>(budget);

            return dto;     
            
        }

        public async Task<ActionResult<List<BudgetResponseDto>>> GetBudgetsByClientId(int ClientId)
        {
            var budgets = await budgetRepository.GetBudgetsByClientId(ClientId);
            if (budgets == null)
            {
                throw new KeyNotFoundException("El presupuesto no fue encontrado");
            }
            var list = mapper.Map<List<BudgetResponseDto>>(budgets);


            return list;
        }

        public async Task<ActionResult<List<BudgetResponseDto>>> GetAllBudgets()
        {
            var budgets = await budgetRepository.GetAll();
            if (budgets == null)
            {
                throw new Exception("Presupuestos no encontrados");
            }
            
            var list = mapper.Map<List<BudgetResponseDto>>(budgets);

            return list;
           
        }

        public async Task DeleteBudget(int id)
        {
            var budget = await budgetRepository.GetById(id);
            if (budget == null)
            {
                throw new KeyNotFoundException("El presupuesto no fue encontrado");
            }
            else
            {
                budget.Status = false;
                await budgetRepository.Update(budget);
            }
        }
        
        public async Task<decimal> CalculateTotalPriceBudget(int BudgetId)
        {
            decimal BudgetTotalPrice = 0;
            var budget = await budgetRepository.GetById(BudgetId);
            foreach(var work in budget.Works)
            {
                int WorkId = work.WorkId;
                BudgetTotalPrice += await this.workService.CalculateTotalWorkPrice(WorkId);
            }          
            budget.Cost = BudgetTotalPrice;
            var budgetMapped = mapper.Map<BudgetRequestDto>(budget);
            await UpdateBudget(budget.BudgetId, budgetMapped);
            return BudgetTotalPrice;
        }

        public async Task UpdateBudgetItemPricesAsync(int budgetId)
        {
            var works = await workRepository.GetWorksWithMaterialsByBudgetId(budgetId);

            foreach (var work in works)
            {
                foreach (var item in work.OMaterials)
                {
                    var precioActualMaterial = item.OMaterial.Price;

                    if (item.Price != precioActualMaterial)
                    {
                        item.Price = precioActualMaterial;
                    }
                }

            // recalcular total del work
            await workService.CalculateTotalWorkPrice(work.WorkId);

            // guardar cambios en el work
            await workRepository.Update(work);
            }
        }   

    }
}