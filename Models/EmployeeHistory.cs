using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PresupuestitoBack.Models
{
    [Table("EmployeeHistories")]
    public class EmployeeHistory
    {
        [Key]
        [Column("EmployeeHistoryId",TypeName = "INT")]
        public int EmployeeHistoryId { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Quantity { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        private bool _Status;
        public bool Status
        {
            get => _Status;
            set { _Status = value; }
        }

        // Relación con Employee
        [Required]
        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; } // Clave foránea
        public virtual Employee OEmployee { get; set; } // Propiedad de navegación
    }
}
