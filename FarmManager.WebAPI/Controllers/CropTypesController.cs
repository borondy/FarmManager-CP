using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FarmManager.Domain.Entities;
using FarmManager.Domain.Repositories;

namespace FarmManager.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CropTypesController : ControllerBase
    {
        private readonly ICropTypeRepository _cropTypeRepository;

        public CropTypesController(ICropTypeRepository cropTypeRepository)
        {
            _cropTypeRepository = cropTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CropType>>> GetCropTypes()
        {
            return Ok(await _cropTypeRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CropType>> GetCropType(int id)
        {
            var cropType = await _cropTypeRepository.GetByIdAsync(id);
            if (cropType == null)
            {
                return NotFound();
            }
            return Ok(cropType);
        }

        [HttpGet("byMonth/{month}")]
        public async Task<ActionResult<IEnumerable<CropType>>> GetCropTypesByMonth(int month)
        {
            if (month < 1 || month > 12)
            {
                return BadRequest("Month must be between 1 and 12");
            }
            return Ok(await _cropTypeRepository.GetBySeedingMonthAsync(month));
        }

        [HttpPost]
        public async Task<ActionResult<CropType>> CreateCropType(CropType cropType)
        {
            var createdCropType = await _cropTypeRepository.AddAsync(cropType);
            return CreatedAtAction(nameof(GetCropType), new { id = createdCropType.Id }, createdCropType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCropType(int id, CropType cropType)
        {
            if (id != cropType.Id)
            {
                return BadRequest();
            }

            await _cropTypeRepository.UpdateAsync(cropType);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCropType(int id)
        {
            await _cropTypeRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
