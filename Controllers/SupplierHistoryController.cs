using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierHistoryController : ControllerBase
    {
        private readonly SupplierHistoryService supplierHistoryService;

        public SupplierHistoryController(SupplierHistoryService supplierHistoryService)
        {
            this.supplierHistoryService = supplierHistoryService;
        }

        [HttpPost]
        public async Task CreateSupplierHistory([FromBody] SupplierHistoryRequestDto supplierHistoryRequestDto)
        {
            await supplierHistoryService.CreateSupplierHistory(supplierHistoryRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateSupplierHistory(int id, [FromBody] SupplierHistoryRequestDto supplierHistoryRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await supplierHistoryService.UpdateSupplierHistory(id, supplierHistoryRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierHistoryResponseDto>> GetSupplierHistoryById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var supplierHistory = await supplierHistoryService.GetSupplierHistoryById(id);
            return Ok(supplierHistory);
        }

        [HttpGet]
        public async Task<ActionResult<List<SupplierHistoryResponseDto>>> GetAllSupplierHistories()
        {
            return await supplierHistoryService.GetAllSupplierHistories();
        }

        [HttpPatch("{id}")]
        public async Task DeleteSupplierHistory(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await supplierHistoryService.DeleteSupplierHistory(id);
        }

    }
}
