using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PresupuestitoBack.Models
{
    [Table("Works")]
    public class Work
    {
        [Key]
        [Column("WorkId",TypeName = "INT")]
        public int WorkId { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(500)")]
        public string WorkName { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int EstimatedHoursWorked { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime DeadLine { get; set; }

        [Column(TypeName = "DECIMAL(18, 2)")]
        public decimal CostPrice { get; set; }
        public virtual ICollection<Item> OMaterials { get; set; }

        [Column(TypeName = ("bit"))]
        private bool _Status;
        public bool Status
        {
            get => _Status;
            set { _Status = value; }
        }

        [Column(TypeName = "NVARCHAR(500)")]
        public string Notes { get; set; }

        [Required]
        [ForeignKey("BudgetId")]
        public int BudgetId { get; set; } 
        public virtual Budget Budget { get; set; }

        [Required]
        [Column(TypeName = "NVARCHAR(500)")]
        public string WorkStatus { get; set; }

    }
}





