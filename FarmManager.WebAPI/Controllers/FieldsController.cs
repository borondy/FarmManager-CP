using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FarmManager.Domain.Entities;
using FarmManager.Core.Interfaces;
using FarmManager.Core.DTOs;

namespace FarmManager.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FieldsController : ControllerBase
    {
        private readonly IFieldService _fieldService;

        public FieldsController(IFieldService fieldService)
        {
            _fieldService = fieldService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Field>>> GetFields()
        {
            return Ok(await _fieldService.GetFieldsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Field>> GetField(int id)
        {
            var field = await _fieldService.GetFieldByIdAsync(id);
            if (field == null)
            {
                return NotFound();
            }
            return Ok(field);
        }

        [HttpPost]
        public async Task<ActionResult<Field>> CreateField(CreateFieldDto createFieldDto)
        {
            var createdField = await _fieldService.CreateFieldAsync(createFieldDto);
            return CreatedAtAction(nameof(GetField), new { id = createdField.Id }, createdField);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateField(int id, Field field)
        {
            try 
            {
                await _fieldService.UpdateFieldAsync(id, field);
                return NoContent();
            }
            catch (System.ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteField(int id)
        {
            await _fieldService.DeleteFieldAsync(id);
            return NoContent();
        }
    }
}
