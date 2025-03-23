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

        public DynamicDataController(IDynamicDataService dynamicDataService)
        {
            _dynamicDataService = dynamicDataService;
        }

        [HttpGet("Data/{tableId}")]
        public async Task<ActionResult<DynamicDataDto>> GetAllDataAsync(int tableId)
        {
            var datas = await _dynamicDataService.GetAllAsync(tableId);
            return datas != null ? Ok(datas) : NotFound("Aucune donnée trouvée.");
        }

        [HttpPost("Data/{tableId}")]
        public async Task<IActionResult> AddDataAsync(int tableId, [FromBody] DynamicLineDto newData)
        {
            if (newData == null || newData.Rows == null || newData.Rows.Count == 0)
                return BadRequest("Données invalides.");

            var result = await _dynamicDataService.AddAsync(tableId, newData);
            return result ? Ok("Donnée ajoutée avec succès.") : StatusCode(500, "Erreur lors de l'ajout.");
        }

        [HttpPut("Data/{tableId}/{id}")]
        public async Task<IActionResult> UpdateDataAsync(int tableId, int id, [FromBody] DynamicLineDto updatedData)
        {
            if (updatedData == null || updatedData.Rows == null || updatedData.Rows.Count == 0)
                return BadRequest("Données invalides.");

            var result = await _dynamicDataService.UpdateAsync(tableId, id, updatedData);
            return result ? Ok("Donnée mise à jour.") : NotFound("Donnée non trouvée.");
        }

        [HttpDelete("Data/{tableId}/{id}")]
        public async Task<IActionResult> DeleteDataAsync(int tableId, int id)
        {
            var result = await _dynamicDataService.DeleteAsync(tableId, id);
            return result ? Ok("Donnée supprimée.") : NotFound("Donnée non trouvée.");
        }
    }
}
