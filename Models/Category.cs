using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace PresupuestitoBack.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [Column("CategoryId",TypeName = "INT")]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string CategoryName { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        private bool _Status; 
        public bool Status
        {
            get => _Status;  
            set { _Status = value; }  
        }

        public virtual ICollection<SubCategoryMaterial> SubCategories { get; set; } 
    }
}
