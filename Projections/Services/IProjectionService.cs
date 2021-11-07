using System.Collections.Generic;
using ViewModels = Projections.Models.ViewModels;

namespace Projections.Services
{
    public interface IProjectionService
    {
        public IEnumerable<ViewModels.ProjectionDataVm> GetProjections();
    }
}
