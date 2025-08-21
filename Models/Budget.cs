using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Budgets")]
    public class Budget
    {
        [Key]
        [Column("BudgetId",TypeName = "INT")]
        public int BudgetId { get; set; }
        public virtual ICollection<Work> Works { get; set; } 

        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Cost { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string BudgetStatus { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DateCreated { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime? DeadLine { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(400)")]
        public string DescriptionBudget { get; set; }

        //List Payments
        public virtual ICollection<Payment> Payments { get; set; }


        [Required]
        [Column(TypeName = "bit")]
        private bool _Status;
        public bool Status 
        {
            get => _Status;
            set { _Status = value; }
        }

        // Relación con ClientHistory 
        [Required]
        [ForeignKey("ClientId")]
        public int ClientId { get; set; } // Clave foránea
        public virtual Client Oclient { get; set; } // Propiedad de navegación

    }
}
