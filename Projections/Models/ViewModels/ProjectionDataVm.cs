using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projections.Models.ViewModels
{
    public class ProjectionDataVm
    {
        public string Month { get; set; }
        public IEnumerable<Row> MonthData { get; set; }
        public IEnumerable<Actuals> Actuals { get; set; }
    }
}
