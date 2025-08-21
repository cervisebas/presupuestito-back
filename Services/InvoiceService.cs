using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;
using System.Formats.Asn1;

namespace PresupuestitoBack.Services
{
    public class InvoiceService
    {
        private readonly IInvoiceRepository invoiceRepository;
        private readonly IMapper mapper;
        private readonly InvoiceItemService invoiceItemService;

        public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper, InvoiceItemService invoiceItemService)
        {
            this.invoiceRepository = invoiceRepository;
            this.mapper = mapper;
            this.invoiceItemService = invoiceItemService;
        }

        public async Task CreateInvoice(InvoiceRequestDto invoiceRequestDto)
        {
            var invoice = mapper.Map<Invoice>(invoiceRequestDto);
            invoice.Status = true;
            await invoiceRepository.Insert(invoice);
        }

        public async Task UpdateInvoice(int id, InvoiceRequestDto invoiceRequestDto)
        {
            var existingInvoice = await invoiceRepository.GetById(id);
            if (existingInvoice == null)
            {
                throw new Exception("La factura no existe");
            }
            else
            {
                mapper.Map(invoiceRequestDto, existingInvoice);
                await invoiceRepository.Update(existingInvoice);
            }
        }


        public async Task<ActionResult<InvoiceResponseDto>> GetInvoiceById(int id)
        {
            var invoice = await invoiceRepository.GetById(id);
            return mapper.Map<InvoiceResponseDto>(invoice);
            
        }

        public async Task<ActionResult<List<InvoiceResponseDto>>> GetAllInvoices()
        {
            var invoices = await invoiceRepository.GetAll();
            if (invoices == null)
            {
                throw new Exception("Facturas no encontradas.");
            }
            else
            {
                return mapper.Map<List<InvoiceResponseDto>>(invoices);
            }
        }

        public async Task DeleteInvoice(int id)
        {
            var invoice = await invoiceRepository.GetById(id);
            if (invoice == null)
            {
                throw new KeyNotFoundException("La factura no fue encontrada.");
            }
            else
            {
                invoice.Status = false;
                await invoiceRepository.Update(invoice);
            }
        }

        public async Task<ActionResult<List<InvoiceResponseDto>>> GetInvoicesBySupplierId(int SupplierId)
        {
            var invoices = await invoiceRepository.GetInvoicesBySupplierId(SupplierId);
            if (invoices == null)
            {
                throw new KeyNotFoundException("La factura no fue encontrada.");
            }
            return mapper.Map<List<InvoiceResponseDto>>(invoices);
        }

    }
}
