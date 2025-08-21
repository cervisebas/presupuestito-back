using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class InvoiceItemService
    {
        private readonly IInvoiceItemRepository invoiceItemRepository;
        private readonly IMapper mapper;

        public InvoiceItemService(IInvoiceItemRepository invoiceItemRepository, IMapper mapper)
        {
            this.invoiceItemRepository = invoiceItemRepository;
            this.mapper = mapper;
        }

        public async Task CreateInvoiceItem(InvoiceItemRequestDto invoiceItemRequestDto)
        {
            var invoiceItem = mapper.Map<InvoiceItem>(invoiceItemRequestDto);
            invoiceItem.Status = true;
            await invoiceItemRepository.Insert(invoiceItem);
        }

        public async Task UpdateInvoiceItem(int id, InvoiceItemRequestDto invoiceItemRequestDto)
        {
            var existingInvoiceItem = await invoiceItemRepository.GetById(id);
            if (existingInvoiceItem == null)
            {
                throw new Exception("El ítem de factura no existe");
            }
            else
            {
                mapper.Map(invoiceItemRequestDto, existingInvoiceItem);
                await invoiceItemRepository.Update(existingInvoiceItem);
            }
        }

        public async Task<ActionResult<InvoiceItemResponseDto>> GetInvoiceItemById(int id)
        {
            var invoiceItem = await invoiceItemRepository.GetById(id);
            return mapper.Map<InvoiceItemResponseDto>(invoiceItem);
        }

        public async Task<ActionResult<List<InvoiceItemResponseDto>>> GetAllInvoiceItems()
        {
            var invoiceItems = await invoiceItemRepository.GetAll();
            if (invoiceItems == null)
            {
                throw new Exception("Ítems de factura no encontrados.");
            }
            else
            {
                return mapper.Map<List<InvoiceItemResponseDto>>(invoiceItems);
            }
        }

        public async Task DeleteInvoiceItem(int id)
        {
            var invoiceItem = await invoiceItemRepository.GetById(id);
            if (invoiceItem == null)
            {
                throw new KeyNotFoundException("El ítem de factura no fue encontrado.");
            }
            else
            {
                invoiceItem.Status = false;
                await invoiceItemRepository.Update(invoiceItem);
            }
        }

    }
}
