using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PresupuestitoBack.DTOs.Request;
using PresupuestitoBack.DTOs.Response;
using PresupuestitoBack.Models;
using PresupuestitoBack.Repositories.IRepository;

namespace PresupuestitoBack.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task CreateCategory(CategoryRequestDto categoryRequestDto)
        {
            var category = mapper.Map<Category>(categoryRequestDto);
            category.Status = true;
            await categoryRepository.Insert(category);
        }

        public async Task UpdateCategory(int id, CategoryRequestDto categoryRequestDto)
        {
            var existingCategory = await categoryRepository.GetById(id);
            if (existingCategory == null)
            {
                throw new KeyNotFoundException("La categoria no existe.");
            }
            else
            {
                mapper.Map(categoryRequestDto, existingCategory);
                await categoryRepository.Update(existingCategory);
            }                     
        }

        public async Task<ActionResult<CategoryResponseDto>> GetCategoryById(int id)
        {
            var category = await categoryRepository.GetById(id);
            return mapper.Map<CategoryResponseDto>(category);
        }

        public async Task<ActionResult<List<CategoryResponseDto>>> GetAllCategories()
        {
            var categories = await categoryRepository.GetAll();   
            if (categories == null)
            {
                throw new Exception("Categorias no encontradas");
            }
            else
            {
                return mapper.Map<List<CategoryResponseDto>>(categories);
            }                        
        }

        public async Task DeleteCategory(int id)
        {
            var category = await categoryRepository.GetById(id);
            if (category == null)
            {
                throw new KeyNotFoundException("La categoria no fue encontrada.");
            }
            else
            {
                category.Status = false;
                await categoryRepository.Update(category);
            }
        }

    }
}
