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

        public BudgetService(IBudgetRepository budgetRepository, IMapper mapper, WorkService workService, ClientHistoryService clientHistoryService)
        {
            this.budgetRepository = budgetRepository;
            this.mapper = mapper;
            this.workService = workService;
            this.clientHistoryService = clientHistoryService;
        }
        
        public async Task CreateBudget(BudgetRequestDto budgetRequestDto)
        {
            var budget = mapper.Map<Budget>(budgetRequestDto);
            budget.Status = true;
            await budgetRepository.Insert(budget);
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
            return mapper.Map<BudgetResponseDto>(budget);   
            
        }

        public async Task<ActionResult<List<BudgetResponseDto>>> GetBudgetsByClientId(int ClientId)
        {
            var budgets = await budgetRepository.GetBudgetsByClientId(ClientId);
            if (budgets == null)
            {
                throw new KeyNotFoundException("El presupuesto no fue encontrado");
            }
            else
            {
                return mapper.Map<List<BudgetResponseDto>>(budgets);
            }
        }

        public async Task<ActionResult<List<BudgetResponseDto>>> GetAllBudgets()
        {
            var budgets = await budgetRepository.GetAll();
            if (budgets == null)
            {
                throw new Exception("Presupuestos no encontrados");
            }
            else
            {
                return mapper.Map<List<BudgetResponseDto>>(budgets);    
            }
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
        
    }
}