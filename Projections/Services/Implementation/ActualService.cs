using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projections.Models;
using Projections.Services;
using Projections.Repositories;

namespace Projections.Services.Implementation
{
    public class ActualService : IActualService
    {
        private readonly IActualRepository _actualRepository;

        public ActualService(IActualRepository actualRepository)
        {
            _actualRepository = actualRepository;
        }

        public IEnumerable<Actuals> GetActualsByProjectionId(int projectionId)
        {
            return _actualRepository.GetActualsByProjectionId(projectionId);
        }
    }
}
