using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Services;

namespace PresupuestitoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpPost]
        public async Task CreateCategory([FromBody] CategoryRequestDto categoryRequestDto)
        {
            await categoryService.CreateCategory(categoryRequestDto);
        }

        [HttpPut("{id}")]
        public async Task UpdateCategory(int id, [FromBody] CategoryRequestDto categoryRequestDto)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await categoryService.UpdateCategory(id, categoryRequestDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponseDto>> GetCategoryById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            var category = await categoryService.GetCategoryById(id);
            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryResponseDto>>> GetAllCategories()
        {
            return await categoryService.GetAllCategories();
        }

        [HttpPatch("{id}")]
        public async Task DeleteCategory(int id)
        {
            if (id <= 0)
            {
                throw new Exception("Id invalido");
            }
            await categoryService.DeleteCategory(id);
        }

    }
}
