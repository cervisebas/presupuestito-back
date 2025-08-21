using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("SubCategories")]
    public class SubCategoryMaterial
    {
        [Key]
        [Column("SubCategoryMaterialId",TypeName = "INT")]
        public int SubCategoryMaterialId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string SubCategoryName { get; set; }

        [Required]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }       
        public virtual Category OCategory { get; set; }

        [Column(TypeName = ("bit"))]
        private bool _Status;
        public bool Status
        {
            get => _Status;
            set { _Status = value; }
        }
    }
}

