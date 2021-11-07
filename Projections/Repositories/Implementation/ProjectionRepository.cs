using System.Collections.Generic;
using System.Linq;
using Projections.DbContexts;

namespace Projections.Repositories.Implementation
{
    public class ProjectionRepository : IProjectionRepository
    {
        private readonly ProjectionsContext _projectionContext;

        public ProjectionRepository(ProjectionsContext projectionsContext)
        {
            _projectionContext = projectionsContext;
        }
        public IEnumerable<Models.Projections> GetAll()
        {
            return _projectionContext.Projections.ToList();
        }

        public Models.Projections GetProjectionById(int projectionId)
        {
            return _projectionContext.Find<Models.Projections>(projectionId);
        }
    }
}
