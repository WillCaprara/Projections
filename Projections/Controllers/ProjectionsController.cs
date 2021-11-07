using Microsoft.AspNetCore.Mvc;
using System;
using Projections.Services;

namespace Projections.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionsController : ControllerBase
    {
        private readonly IProjectionService _projectionService;

        public ProjectionsController(IProjectionService projectionService)
        {
            _projectionService = projectionService;
        }

        [HttpGet]
        public IActionResult GetProjections()
        {
            try
            {
                var result = _projectionService.GetProjections();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
