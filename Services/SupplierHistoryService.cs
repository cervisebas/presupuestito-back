using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class SupplierHistoryService
    {
        private readonly ISupplierHistoryRepository supplierHistoryRepository;
        private readonly IMapper mapper;

        public SupplierHistoryService(ISupplierHistoryRepository supplierHistoryRepository, IMapper mapper)
        {
            this.supplierHistoryRepository = supplierHistoryRepository;
            this.mapper = mapper;
        }

        public async Task CreateSupplierHistory(SupplierHistoryRequestDto supplierHistoryRequestDto)
        {
            var supplierHistory = mapper.Map<SupplierHistory>(supplierHistoryRequestDto);
            supplierHistory.Status = true;
            await supplierHistoryRepository.Insert(supplierHistory);
        }

        public async Task UpdateSupplierHistory(int id, SupplierHistoryRequestDto supplierHistoryRequestDto)
        {
            var existingSupplierHistory = await supplierHistoryRepository.GetById(id);
            if (existingSupplierHistory == null)
            {
                throw new Exception("El historial del proveedor no existe");
            }
            else
            {
                mapper.Map(supplierHistoryRequestDto, existingSupplierHistory);
                await supplierHistoryRepository.Update(existingSupplierHistory);
            }
        }

        public async Task<ActionResult<SupplierHistoryResponseDto>> GetSupplierHistoryById(int id)
        {
            var supplierHistory = await supplierHistoryRepository.GetById(id);
            if (supplierHistory == null)
            {
                throw new KeyNotFoundException("El historial del proveedor no fue encontrado.");
            }
            else
            {
                return mapper.Map<SupplierHistoryResponseDto>(supplierHistory);
            }
        }

        public async Task<ActionResult<List<SupplierHistoryResponseDto>>> GetAllSupplierHistories()
        {
            var supplierHistories = await supplierHistoryRepository.GetAll();
            if (supplierHistories == null)
            {
                throw new Exception("Historiales de proveedores no encontrados.");
            }
            else
            {
                return mapper.Map<List<SupplierHistoryResponseDto>>(supplierHistories);
            }
        }

        public async Task DeleteSupplierHistory(int id)
        {
            var supplierHistory = await supplierHistoryRepository.GetById(id);
            if (supplierHistory == null)
            {
                throw new KeyNotFoundException("El historial del proveedor no fue encontrado.");
            }
            else
            {
                supplierHistory.Status = false;
                await supplierHistoryRepository.Update(supplierHistory);
            }
        }

    }
}
