using System.Net.Http.Headers;
using System.Threading.Tasks;
using api.Models.DTOs.Turf;
using api.Models.Entities;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/turfs")]
    public class TurfController : ControllerBase
    {
        private readonly TurfService _service;

        public TurfController(TurfService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TurfListDto>>> GetAll()
        {
            var turfs = await _service.GetAllTurfAsync();
            return Ok(turfs);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTurfDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TurfDetailDto>> GetTurfByIdAsync(int id)
        {
            var dto = await _service.GetTurfByIdAsync(id);
            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTurf(int id, [FromBody] TurfDetailDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);

            if (!updated)
                return NotFound();

            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
