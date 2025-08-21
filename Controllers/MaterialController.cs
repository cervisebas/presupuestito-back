using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly MaterialService materialService;

        public MaterialController(MaterialService materialService)
        {
            this.materialService = materialService;
        }

        [HttpPost]
        public async Task CreateMaterial([FromBody] MaterialRequestDto materialRequestDto)
        {
            await materialService.CreateMaterial(materialRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateMaterial(int id, [FromBody] MaterialRequestDto materialRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await materialService.UpdateMaterial(id, materialRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialResponseDto>> GetMaterialById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var material = await materialService.GetMaterialById(id);
            return Ok(material);
        }

        [HttpGet]
        public async Task<ActionResult<List<MaterialResponseDto>>> GetAllMaterials()
        {
            return await materialService.GetAllMaterials();
        }

        [HttpPatch("{id}")]
        public async Task DeleteMaterial(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await materialService.DeleteMaterial(id);
        }

    }
}
