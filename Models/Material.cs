using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Materials")]
    public class Material
    {
        [Key]
        [Column("MaterialId",TypeName = "INT")]
        public int MaterialId { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string MaterialName { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR(400)")]
        public string MaterialDescription { get; set; }

        [Column(TypeName = "NVARCHAR(50)")]
        public string MaterialColor { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string MaterialBrand { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string MaterialMeasure { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR(50)")]
        public string MaterialUnitMeasure { get; set; }

        [Required]
        [ForeignKey("SubCategoryMaterialId")]
        public int SubCategoryMaterialId { get; set; } 
        public virtual SubCategoryMaterial OSubcategoryMaterial { get; set; } 

        [Required]
        [Column(TypeName = "bit")]
        private bool _Status;
        public bool Status
        {
            get => _Status;
            set { _Status = value; }
        }

    }
}