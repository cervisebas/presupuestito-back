using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
  public class StatService
  {
    private readonly IBudgetRepository budgetRepository;
    private readonly IWorkRepository workRepository;
    private readonly IClientRepository clientRepository;
    private readonly IMaterialRepository materialRepository;
    private readonly ISupplierRepository supplierRepository;

    public StatService(ISupplierRepository supplierRepository, IMaterialRepository materialRepository, IClientRepository clientRepository, IWorkRepository workRepository, IBudgetRepository budgetRepository)
    {
      this.supplierRepository = supplierRepository;
      this.materialRepository = materialRepository;
      this.clientRepository = clientRepository;
      this.workRepository = workRepository;
      this.budgetRepository = budgetRepository;
    }

    public async Task<ActionResult<StatResponseDto>> GetStats()
    {
      var budgetCount = await budgetRepository.GetCount();
      var workCount = await workRepository.GetCount();
      var clientCount = await clientRepository.GetCount();
      var materialCount = await materialRepository.GetCount();
      var supplierCount = await supplierRepository.GetCount();

      var stats = new StatResponseDto
      {
        BudgetCount = (long) budgetCount,
        WorkCount = (long) workCount,
        ClientCount = (long) clientCount,
        MaterialCount = (long) materialCount,
        SupplierCount = (long) supplierCount,
      };

      return stats;
        
    }
  }
}