using Microsoft.AspNetCore.Mvc;
using UniSoft.Application.DTOs;
using UniSoft.Application.Interfaces;

namespace UniSoft.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        // GET: api/Application/Details/5
        [HttpGet("Details/{id}")]
        public async Task<ActionResult<ApplicationDto>> GetApplicationDetails(int id)
        {
            var applicationDetails = await _applicationService.GetApplicationDetailsAsync(id);
            if (applicationDetails == null)
            {
                return NotFound();
            }
            return Ok(applicationDetails);
        }
    }
}
