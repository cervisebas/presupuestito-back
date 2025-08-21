using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PresupuestitoBack.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Column("EmployeeId", TypeName = "INT")]
        public int EmployeeId { get; set; }

        [Required]
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
        public virtual Person OPerson { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal Salary { get; set; }

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
