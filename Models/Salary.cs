using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Salaries")]
    public class Salary
    {
        [Key]
        [Column("SalaryId", TypeName = "INT")]
        public int SalaryId { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime BillDate { get; set; }

        [ForeignKey("PaymentId")]
        public int PaymentId { get; set; }
        public virtual Payment OPayment { get; set; }

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
