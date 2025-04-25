using EducaFlow.Models;
using EducaFlow.Services;
using Microsoft.AspNetCore.Mvc;

namespace EducaFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SerieController : ControllerBase
    {
        private readonly SerieService _serieService;

        public SerieController(SerieService serieService)
        {
            _serieService = serieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Serie>>> GetSeries()
        {
            var series = await _serieService.GetSeriesAsync();
            return Ok(series);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Serie>> GetSerieById(int id)
        {
            var serie = await _serieService.GetSerieByIdAsync(id);
            if (serie == null)
                return NotFound();

            return Ok(serie);
        }

        [HttpPost]
        public async Task<ActionResult<Serie>> AddSerie(Serie serie)
        {
            var novaSerie = await _serieService.AddSerieAsync(serie);
            return CreatedAtAction(nameof(GetSerieById), new { id = novaSerie.IdSerie }, novaSerie);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Serie>> UpdateSerie(int id, Serie serie)
        {
            if (id != serie.IdSerie)
                return BadRequest("ID da serie não confere.");

            var serieAtualizado = await _serieService.UpdateSerieAsync(serie);
            return Ok(serieAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerie(int id)
        {
            await _serieService.DeleteSerieAsync(id);
            return NoContent();
        }
    }
}
