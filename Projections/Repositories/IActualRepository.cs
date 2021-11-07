using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projections.Repositories
{
    public interface IActualRepository
    {
        public IEnumerable<Models.Actuals> GetActualsByProjectionId(int projectionId);
    }
}
