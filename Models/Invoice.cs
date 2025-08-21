using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{

    [Table("Invoices")]
    public class Invoice
    {
        
        [Key]
        [Column("InvoiceId",TypeName = "INT")]
        public int InvoiceId { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime Date { get; set; }

        [Column(TypeName = "BIT")]
        public bool IsPaid { get; set; }

        // Relación con SupplierHistory
        [Required]
        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; } // Clave foránea
        public virtual Supplier OSupplier { get; set; } // Propiedad de navegación

        public virtual ICollection<Payment> Payments { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }

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
