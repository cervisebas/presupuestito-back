using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("PaymentsInvoice")]
    public class PaymentInvoice
    {
        [Key]
        [Column("PaymentInvoice",TypeName = "INT")]
        public int PaymentInvoiceId { get; set; }

        [Required]
        [ForeignKey("PaymentId")]
        public int PaymentId { get; set; }
        public virtual Payment OPayment { get; set; }

        [Required]
        [ForeignKey("InvoiceId")]
        public int InvoiceId {  get; set; }
        public virtual Invoice OInvoice { get; set; }

        [Column(TypeName = ("bit"))]
        private bool _Status;
        public bool Status
        {
            get => _Status;
            set { _Status = value; }
        }
    }
}
