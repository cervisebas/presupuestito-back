using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService invoiceService;

        public InvoiceController(InvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task CreateInvoice([FromBody] InvoiceRequestDto invoiceRequestDto)
        {
            await invoiceService.CreateInvoice(invoiceRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateInvoice(int id, [FromBody] InvoiceRequestDto invoiceRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await invoiceService.UpdateInvoice(id, invoiceRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceResponseDto>> GetInvoiceById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var invoice = await invoiceService.GetInvoiceById(id);
            return Ok(invoice);
        }

        [HttpGet]
        public async Task<ActionResult<List<InvoiceResponseDto>>> GetAllInvoices()
        {
            return await invoiceService.GetAllInvoices();
        }

        [HttpPatch("{id}")]
        public async Task DeleteInvoice(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await invoiceService.DeleteInvoice(id);
        }

        [HttpGet("BySupplier/{SupplierId}")]
        public async Task<ActionResult<List<InvoiceResponseDto>>> GetInvoicesBySupplierId(int SupplierId)
        {
            if (SupplierId <= 0)
            {
                throw new Exception("Id invalido");
            }
            return await invoiceService.GetInvoicesBySupplierId(SupplierId);
        }

    }
}
