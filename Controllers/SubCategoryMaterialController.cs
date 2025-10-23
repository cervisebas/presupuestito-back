using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<SubCategoryMaterialResponseDto>> CreateSubCategoryMaterial([FromBody] SubCategoryMaterialRequestDto subCategoryMaterialRequestDto)
        {
            var subcategory = await subCategoryMaterialService.CreateSubCategoryMaterial(subCategoryMaterialRequestDto);
            return subcategory;
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

            if (subCategoryMaterial == null)
            {
                return NotFound();
            }

            return subCategoryMaterial;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubCategoryMaterialResponseDto>>> GetAllSubCategoryMaterials()
        {
            return await subCategoryMaterialService.GetAllSubCategoryMaterials();
        }

        [HttpDelete("{id}")]
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
