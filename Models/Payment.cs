using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        [Column("PaymentId",TypeName = "INT")]
        public int PaymentId { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime Date { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public double Amount { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(400)")]
        public string? DescriptionPayment { get; set; }

        [Required]        
        [ForeignKey("InvoiceId")]
        public int InvoiceId { get; set; }
        public virtual Invoice? OInvoice { get; set; }

        [Required]
        [ForeignKey("BudgetId")]
        public int BudgetId { get; set; }      
        public virtual Budget? OBudget { get; set; }

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
