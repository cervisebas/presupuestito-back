using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class SupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly PersonService personService;
        private readonly IMapper mapper;
        private readonly DbContext context;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper, PersonService personService)
        {
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
            this.personService = personService;
        }
      
        public async Task CreateSupplier(PersonRequestDto personRequestDto)
        {
            var supplier = await personService.CreatePerson(personRequestDto);
            Supplier proveedor = new Supplier();
            proveedor.PersonId = supplier.PersonId;
            proveedor.Status = true;
            await supplierRepository.Insert(proveedor);
        }

        public async Task UpdateSupplier(int id, PersonRequestDto personRequestDto)
        {
            var existingSupplier = await supplierRepository.GetById(id);
            if (existingSupplier == null)
            {
                throw new Exception("El proveedor no existe");
            }
            else
            {
                var idPersona = existingSupplier.PersonId;
                await personService.UpdatePerson(idPersona, personRequestDto);
                await supplierRepository.Update(existingSupplier);
            }
        }

        public async Task<ActionResult<SupplierResponseDto>> GetSupplierById(int id)
        {
            var supplier = await supplierRepository.GetById(id);
            return mapper.Map<SupplierResponseDto>(supplier);
        }

        public async Task<ActionResult<List<SupplierResponseDto>>> GetAllSuppliers()
        {
            var suppliers = await supplierRepository.GetAll();
            if (suppliers == null)
            {
                throw new Exception("Proveedores no encontrados.");
            }
            else
            {
                return mapper.Map<List<SupplierResponseDto>>(suppliers);
            }
        }

        public async Task DeleteSupplier(int id)
        {
            var supplier = await supplierRepository.GetById(id);
            if (supplier == null)
            {
                throw new KeyNotFoundException("El proveedor no fue encontrado.");
            }
            else
            {
                supplier.Status = false;
                await supplierRepository.Update(supplier);
            }
        }

    }
}
