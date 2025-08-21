using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{

    [Table("FixedCost")]
    public class FixedCost
    {
        [Key]
        [Column("FixedCostId",TypeName = "INT")]
        public int FixedCostId { get; set; }


        [Required]
        [Column(TypeName = "NVARCHAR(500)")]
        public string Description { get; set; }


        [Required]
        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Amount { get; set; }


        [Required]
        [Column(TypeName = "INT")]
        public int WorkingDays { get; set; }


        [Required]
        [Column(TypeName = "INT")]
        public int HoursWorked { get; set; }


        [Required]
        [Column(TypeName = "DATE")]
        public DateOnly DateCharged {  get; set; }

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
