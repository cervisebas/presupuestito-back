using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("SupplierHistories")]
    public class SupplierHistory
    {
        [Key]
        [Column("SupplierHistoryId",TypeName = "INT")]
        public int SupplierHistoryId { get; set; }

        [Required]
        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; } 
        public virtual Supplier Osupplier { get; set; }

        [Column(TypeName = ("bit"))]
        private bool _Status;
        public bool Status
        {
            get => _Status;
            set { _Status = value; }
        }

    } 
}
