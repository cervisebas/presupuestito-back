using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("InvoicesItems")]
    public class InvoiceItem
    {
        [Key]
        [Column("InvoiceItemId", TypeName = "INT")]
        public int InvoiceItemId { get; set; }

        [ForeignKey("MaterialId")]
        public int MaterialId { get; set; }        
        public virtual Material OMaterial { get; set; } 

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "bit")]
        private bool _Status;
        public bool Status
        {
            get => _Status;
            set { _Status = value; }
        }


        [Required]
        [ForeignKey("InvoiceId")]
        public int InvoiceId { get; set; } 
        public virtual Invoice OInvoice { get; set; } 
    }
}

