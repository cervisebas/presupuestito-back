using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("PaymentsBudget")]
    public class PaymentBudget
    {
        [Key]
        [Column("PaymentBudgetId",TypeName = "INT")]
        public int PaymentBudgetId { get; set; }

        [Required]
        [ForeignKey("PaymentId")]
        public int PaymentId { get; set; }
        public virtual Payment OPayment { get; set; }

        [Required]
        [ForeignKey("BudgetId")]
        public int BudgetId { get; set; }
        public virtual Budget OBudget { get; set; }

        [Column(TypeName = ("bit"))]
        private bool _Status;
        public bool Status
        {
            get => _Status;
            set { _Status = value; }
        }

    }
}
