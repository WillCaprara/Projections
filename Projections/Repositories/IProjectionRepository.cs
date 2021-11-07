using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models = Projections.Models;

namespace Projections.Repositories
{
    public interface IProjectionRepository
    {
        IEnumerable<Models.Projections> GetAll();
        Models.Projections GetProjectionById(int projectionId);
    }
}
