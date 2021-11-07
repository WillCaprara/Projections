using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projections.Models
{
    public class Actuals
    {
        [Key]
        public int ActualId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        public string Memo { get; set; }
        public DateTime DateDeposited { get; set; }

        [ForeignKey("Projections")]
        public int ProjectionId { get; set; }
        //public virtual Projections Projection { get; set; }
    }
}
