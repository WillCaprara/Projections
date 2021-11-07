using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projections.Models
{
    [XmlRoot(Namespace = "#RowsetSchema", ElementName ="row")]
    public class Row
    {
        [XmlAttribute("Deposit")]
        public decimal Deposit { get; set; }
        [XmlAttribute("Description")]
        public string Description { get; set; }
        [XmlAttribute("MonthYear")]
        public DateTime MonthYear { get; set; }
        [XmlAttribute("Payment")]
        public decimal Payment { get; set; }
        [XmlAttribute("Projected")]
        public decimal Projected { get; set; }
    }
}
