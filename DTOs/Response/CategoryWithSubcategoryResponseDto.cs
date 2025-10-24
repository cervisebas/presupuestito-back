using PresupuestitoBack.DTOs.Request;

namespace PresupuestitoBack.DTOs.Response
{
    public class CategoryWithSubcategoryResponseDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<SubCategoryBaseMaterialResponseDto> SubCategories { get; set; }
    }
}
