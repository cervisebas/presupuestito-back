using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("People")]
    public class Person
    {
        [Key]
        [Column("PersonId",TypeName = "INT")]
        public int PersonId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(50)")]        
        public string Name { get; set; }
        
        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(250)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(100)")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "NVARCHAR(150)")]
        public string Email { get; set; }

        [Column(TypeName = "NVARCHAR(20)")]
        public string DNI { get; set; } 

        [Column(TypeName = "NVARCHAR(20)")]
        public string CUIT { get; set; }


        [Column(TypeName = ("bit"))]
        private bool _Status;
        public bool Status
        {
            get => _Status;
            set { _Status = value; }
        }
    }
}
