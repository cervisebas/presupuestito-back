using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class MaterialService
    {
        private readonly IMaterialRepository materialRepository;
        private readonly IMapper mapper;

        public MaterialService(IMaterialRepository materialRepository, IMapper mapper)
        {
            this.materialRepository = materialRepository;
            this.mapper = mapper;
        }

        public async Task CreateMaterial(MaterialRequestDto materialRequestDto)
        {
            var material = mapper.Map<Material>(materialRequestDto);
            material.Status = true;
            await materialRepository.Insert(material);
        }

        public async Task UpdateMaterial(int id, MaterialRequestDto materialRequestDto)
        {
            var existingMaterial = await materialRepository.GetById(id);
            if (existingMaterial == null)
            {
                throw new Exception("El material no existe");
            }
            else
            {
                mapper.Map(materialRequestDto, existingMaterial);
                await materialRepository.Update(existingMaterial);
            }
        }

        public async Task<ActionResult<MaterialResponseDto>> GetMaterialById(int id)
        {
            var material = await materialRepository.GetById(id);
            return mapper.Map<MaterialResponseDto>(material);
        }

        public async Task<ActionResult<List<MaterialResponseDto>>> GetAllMaterials()
        {
            var materials = await materialRepository.GetAll();
            if (materials == null)
            {
                throw new Exception("Materiales no encontrados.");
            }
            else
            {
                return mapper.Map<List<MaterialResponseDto>>(materials);
            }
        }

        public async Task DeleteMaterial(int id)
        {
            var material = await materialRepository.GetById(id);
            if (material == null)
            {
                throw new KeyNotFoundException("El material no fue encontrado.");
            }
            else
            {
                material.Status = false;
                await materialRepository.Update(material);
            }
        }

        public async Task<decimal> CalculateSubTotal(int MaterialId, decimal MaterialQuantity)
        {
            var material = await materialRepository.GetById(MaterialId);
            if (material == null)
            {
                throw new KeyNotFoundException("Material no encontrado.");
            }
            return MaterialQuantity * material.Price;
        }


    }
}
