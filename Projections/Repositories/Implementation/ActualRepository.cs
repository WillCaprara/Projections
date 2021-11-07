using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projections.Models;
using Projections.Repositories;
using Projections.DbContexts;

namespace Projections.Repositories.Implementation
{
    public class ActualRepository : IActualRepository
    {
        private readonly ProjectionsContext _projectionsContext;

        public ActualRepository(ProjectionsContext projectionsContext)
        {
            _projectionsContext = projectionsContext;
        }

        public IEnumerable<Models.Actuals> GetActualsByProjectionId(int projectionId)
        {
            return _projectionsContext.Actuals.Where(c => c.ProjectionId == projectionId);
        }
    }
}
