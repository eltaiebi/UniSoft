using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniSoft.Application.DTOs;
using UniSoft.Application.Interfaces;

namespace UniSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicDataController : ControllerBase
    {
        private readonly IDynamicDataService _dynamicDataService;

        public DynamicDataController(IDynamicDataService applicationService)
        {
            _dynamicDataService = applicationService;
        }

        [HttpGet("Data/{tableId}")]
        public async Task<ActionResult<DynamicDataDto>> GetAllDataAsync(int tableId)
        {
            var datas = await _dynamicDataService.GetAllAsync(tableId);
            if (datas == null)
            {
                return NotFound();
            }
            return Ok(datas);
        }
    }
}
