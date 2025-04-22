using EducaFlow.Models;
using EducaFlow.Services;
using Microsoft.AspNetCore.Mvc;

namespace EducaFlow.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private readonly EscolaService _escolaService;
        public EscolaController(EscolaService escolaService)
        {
            _escolaService = escolaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Escola>>> GetEscolas()
        {
            var escolas = await _escolaService.GetEscolasAsync();
            return Ok(escolas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Escola>> GetEscolaById(int id)
        {
            var escola = await _escolaService.GetEscolaByIdAsync(id);
            if (escola == null)
                return NotFound();
            return Ok(escola);
        }

        [HttpPost]
        public async Task<ActionResult<Escola>> AddEscola(Escola escola)
        {
            var novaEscola = await _escolaService.AddEscolaAsync(escola);
            return CreatedAtAction(nameof(GetEscolaById), new { id = novaEscola.IdEscola }, novaEscola);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Escola>> UpdateEscola(int id, Escola escola)
        {
            if (id != escola.IdEscola)
                return BadRequest("ID da escola não confere.");
            var escolaAtualizada = await _escolaService.UpdateEscolaAsync(escola);
            return Ok(escolaAtualizada);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEscola(int id)
        {
            await _escolaService.DeleteEscolaAsync(id);
            return NoContent();
        }
    }
}
