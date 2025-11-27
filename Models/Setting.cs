using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Settings")]
    public class Setting
    {
        [Key]
        [Column("SettingId", TypeName = "INT")]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string Label { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(150)")]
        public string Value { get; set; }
    }
}