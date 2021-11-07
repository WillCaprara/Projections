using System.Collections.Generic;

namespace Projections.Services
{
    public interface IActualService
    {
        public IEnumerable<Models.Actuals> GetActualsByProjectionId(int projectionId);
    }
}
