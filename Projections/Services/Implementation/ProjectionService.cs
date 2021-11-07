using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models = Projections.Models;
using Projections.Services;
using Projections.Repositories;
using Projections.Helpers;
using Projections.Models;
using Projections.Utilities;
using ViewModels = Projections.Models.ViewModels;

namespace Projections.Services.Implementation
{
   
    public class ProjectionService: IProjectionService
    {
        private readonly IProjectionRepository _projectionRepository;
        private readonly IActualRepository _actualRepository;
        private readonly IXmlHelper _xmlHelper;
        public ProjectionService(IProjectionRepository projectionRepository, IActualRepository actualRepository, IXmlHelper xmlHelper)
        {
            _projectionRepository = projectionRepository;
            _actualRepository = actualRepository;
            _xmlHelper = xmlHelper;
        }

        public IEnumerable<ViewModels.ProjectionDataVm> GetProjections()
        {
            var result = new List<ViewModels.ProjectionDataVm>();

            var projections = _projectionRepository.GetAll();

            foreach (var projection in projections)
            {
                var currentProjection = _xmlHelper.DeserializeXml<Row>(projection.Xml);

                var years = currentProjection.Where(c => c.MonthYear != DateTime.MinValue).Select(c => c.MonthYear.Year).Distinct();

                foreach (var year in years)
                {
                    foreach (var month in Constants.MONTHS)
                    {
                        var projectionsForCurrentMonthYear = currentProjection.Where(c => c.MonthYear.Month == month.Key && c.MonthYear.Year == year);

                        if (projectionsForCurrentMonthYear.Count() > 0)
                        {
                            var element = new ViewModels.ProjectionDataVm();
                            element.Month = month.Value;

                            //
                            var rows = new List<Row>();
                            foreach (var row in projectionsForCurrentMonthYear)
                            {
                                rows.Add(new Row()
                                {
                                    Deposit = row.Deposit,
                                    Description = row.Description,
                                    MonthYear = row.MonthYear,
                                    Payment = row.Payment,
                                    Projected = row.Projected
                                });
                            }
                            element.MonthData = rows;

                            //
                            var actualsForCurrentMonthYear = _actualRepository.GetActualsByProjectionId(projection.ProjectionId).Where(c => c.DateDeposited.Month == month.Key).ToList();
                            element.Actuals = actualsForCurrentMonthYear;

                            result.Add(element);
                        }
                        else
                        {
                            var element = new ViewModels.ProjectionDataVm();
                            element.Month = month.Value;

                            //
                            var rows = new List<Row>();

                            //
                            var actualsForCurrentMonthYear = new List<Actuals>();

                            result.Add(element);
                        }
                    }
                }                
            }

            return result;
        }
    }
}
