using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemController : ControllerBase
    {
        private readonly InvoiceItemService invoiceItemService;

        public InvoiceItemController(InvoiceItemService invoiceItemService)
        {
            this.invoiceItemService = invoiceItemService;
        }

        [HttpPost]
        public async Task CreateInvoiceItem([FromBody] InvoiceItemRequestDto invoiceItemRequestDto)
        {
            await invoiceItemService.CreateInvoiceItem(invoiceItemRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateInvoiceItem(int id, [FromBody] InvoiceItemRequestDto invoiceItemRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await invoiceItemService.UpdateInvoiceItem(id, invoiceItemRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceItemResponseDto>> GetInvoiceItemById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var invoiceItem = await invoiceItemService.GetInvoiceItemById(id);
            return Ok(invoiceItem);
        }

        [HttpGet]
        public async Task<ActionResult<List<InvoiceItemResponseDto>>> GetAllInvoiceItems()
        {
            return await invoiceItemService.GetAllInvoiceItems();
        }

        [HttpPatch("{id}")]
        public async Task DeleteInvoiceItem(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await invoiceItemService.DeleteInvoiceItem(id);
        }

    }
}
