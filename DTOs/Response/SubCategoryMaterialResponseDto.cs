namespace PresupuestitoBack.DTOs.Response
{
    public class SubCategoryMaterialResponseDto
    {
        public int SubCategoryMaterialId { get; set; }
        public string SubCategoryName { get; set; }
        public CategoryResponseDto categoryId { get; set; }
    }
}
