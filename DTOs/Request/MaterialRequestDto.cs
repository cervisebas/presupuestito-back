namespace PresupuestitoBack.DTOs.Request
{
    public class MaterialRequestDto
    {
        public string MaterialName { get; set; }
        public string MaterialDescription { get; set; }
        public string MaterialColor { get; set; }
        public string MaterialBrand { get; set; }
        public string MaterialMeasure {  get; set; }
        public string MaterialUnitMeasure { get; set; }
        public decimal Price { get; set; }
        public int SubCategoryMaterialId { get; set; }
    }
}
