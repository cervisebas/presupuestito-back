﻿using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryMaterialController : ControllerBase
    {
        private readonly SubCategoryMaterialService subCategoryMaterialService;

        public SubCategoryMaterialController(SubCategoryMaterialService subCategoryMaterialService)
        {
            this.subCategoryMaterialService = subCategoryMaterialService;
        }

        [HttpPost]
        public async Task CreateSubCategoryMaterial([FromBody] SubCategoryMaterialRequestDto subCategoryMaterialRequestDto)
        {
            await subCategoryMaterialService.CreateSubCategoryMaterial(subCategoryMaterialRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateSubCategoryMaterial(int id, [FromBody] SubCategoryMaterialRequestDto subCategoryMaterialRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await subCategoryMaterialService.UpdateSubCategoryMaterial(id, subCategoryMaterialRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryMaterialResponseDto>> GetSubCategoryMaterialById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var subCategoryMaterial = await subCategoryMaterialService.GetSubCategoryMaterialById(id);
            return Ok(subCategoryMaterial);
        }

        [HttpGet]
        public async Task<ActionResult<List<SubCategoryMaterialResponseDto>>> GetAllSubCategoryMaterials()
        {
            return await subCategoryMaterialService.GetAllSubCategoryMaterials();
        }

        [HttpPatch("{id}")]
        public async Task DeleteSubCategoryMaterial(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await subCategoryMaterialService.DeleteSubCategoryMaterial(id);
        }

    }
}
