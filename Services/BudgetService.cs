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
            var existyingBudget = await budgetRepository.GetById(id);
            if (existyingBudget == null)
            {
                throw new Exception("El presupuesto no existe");
            }
            else
            {
                mapper.Map(budgetRequestDto, existyingBudget);
                await budgetRepository.Update(existyingBudget);
            }
        }

        public async Task<ActionResult<BudgetResponseDto>> GetBudgetById(int id)
        {
            var budget = await budgetRepository.GetById(id);
            var dto = mapper.Map<BudgetResponseDto>(budget);

            MarkExpirationFlag(dto); 

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

            MarkExpirationFlagForList(list); 

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

            MarkExpirationFlagForList(list); 

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

       private void MarkExpirationFlag(BudgetResponseDto dto)
        {
            dto.IsCloseToExpiration = CheckIfCloseToDeadline(dto.DeadLine, 10);
        }

        private void MarkExpirationFlagForList(List<BudgetResponseDto> list)
        {
            foreach (var dto in list)
            {
                MarkExpirationFlag(dto);
            }
        }

        private bool CheckIfCloseToDeadline(DateTime? deadline, int daysBefore)
        {
            return deadline.HasValue 
            && deadline.Value <= DateTime.UtcNow.AddDays(daysBefore);
        }

        public async Task<int> UpdateBudgetItemPricesAsync(int budgetId)
        {
            var works = await workRepository.GetWorksWithMaterialsByBudgetId(budgetId);

            int updatedItems = 0;

            foreach (var work in works)
            {
                foreach (var item in work.OMaterials)
                {
                    var precioActualMaterial = item.OMaterial.Price;

                    if (item.Price != precioActualMaterial)
                    {
                        item.Price = precioActualMaterial;
                        updatedItems++;
                    }
                }

            // recalcular total del work
            await workService.CalculateTotalWorkPrice(work.WorkId);

            // guardar cambios en el work
            await workRepository.Update(work);
            }

            return updatedItems;
        }   

    }
}