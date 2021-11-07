using System;
using System.ComponentModel.DataAnnotations;

namespace Projections.Models
{
    public class Projections
    {
        [Key]
        public int ProjectionId { get; set; }
        public DateTime StartDate { get; set; }
        public string Xml { get; set; }
    }
}
