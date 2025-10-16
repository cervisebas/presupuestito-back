using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PresupuestitoBack.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        [Column("ClientId",TypeName = "INT")]
        public int ClientId { get; set; }

        [Required]
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
        public virtual Person OPerson { get; set; }

        public virtual ICollection<ClientHistory> ClientsHistory { get; set; } 

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