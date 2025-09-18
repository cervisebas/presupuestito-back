using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class SubCategoryMaterialService
    {
        private readonly ISubCategoryMaterialRepository subCategoryMaterialRepository;
        private readonly IMapper mapper;

        public SubCategoryMaterialService(ISubCategoryMaterialRepository subCategoryMaterialRepository, IMapper mapper)
        {
            this.subCategoryMaterialRepository = subCategoryMaterialRepository;
            this.mapper = mapper;
        }

        public async Task<ActionResult<SubCategoryMaterialResponseDto>> CreateSubCategoryMaterial(SubCategoryMaterialRequestDto subCategoryMaterialRequestDto)
        {
            var subCategoryMaterial = mapper.Map<SubCategoryMaterial>(subCategoryMaterialRequestDto);
            subCategoryMaterial.Status = true;

            var newSubcategory = await subCategoryMaterialRepository.Insert(subCategoryMaterial);
            return mapper.Map<SubCategoryMaterialResponseDto>(newSubcategory);
        }

        public async Task UpdateSubCategoryMaterial(int id, SubCategoryMaterialRequestDto subCategoryMaterialRequestDto)
        {
            var existingSubCategoryMaterial = await subCategoryMaterialRepository.GetById(id);
            if (existingSubCategoryMaterial == null)
            {
                throw new Exception("La subcategoría de material no existe");
            }
            else
            {
                mapper.Map(subCategoryMaterialRequestDto, existingSubCategoryMaterial);
                await subCategoryMaterialRepository.Update(existingSubCategoryMaterial);
            }
        }

        public async Task<ActionResult<SubCategoryMaterialResponseDto>> GetSubCategoryMaterialById(int id)
        {
            var subCategoryMaterial = await subCategoryMaterialRepository.GetById(id);
            return mapper.Map<SubCategoryMaterialResponseDto>(subCategoryMaterial);
        }

        public async Task<ActionResult<List<SubCategoryMaterialResponseDto>>> GetAllSubCategoryMaterials()
        {
            var subCategoryMaterials = await subCategoryMaterialRepository.GetAll();
            if (subCategoryMaterials == null)
            {
                throw new Exception("Subcategorías de material no encontradas.");
            }
            else
            {
                return mapper.Map<List<SubCategoryMaterialResponseDto>>(subCategoryMaterials);
            }
        }

        public async Task DeleteSubCategoryMaterial(int id)
        {
            var subCategoryMaterial = await subCategoryMaterialRepository.GetById(id);
            if (subCategoryMaterial == null)
            {
                throw new KeyNotFoundException("La subcategoría de material no fue encontrada.");
            }
            else
            {
                subCategoryMaterial.Status = false;
                await subCategoryMaterialRepository.Update(subCategoryMaterial);
            }
        }

    }
}
