using EducaFlow.Models;
using EducaFlow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducaFlow.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly CursoService _cursoService;
        public CursoController(CursoService cursoService)
        {
            _cursoService = cursoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCursos()
        {
            var cursos = await _cursoService.GetCursosAsync();
            return Ok(cursos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurso(int id)
        {
            var curso = await _cursoService.GetCursoByIdAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return Ok(curso);
        }
        [HttpPost]
        public async Task<IActionResult> PostCurso([FromBody] Curso curso)
        {
            if (curso == null)
            {
                return BadRequest();
            }
            var createdCurso = await _cursoService.AddCursoAsync(curso);
            return CreatedAtAction(nameof(GetCurso), new { id = createdCurso.IdCurso }, createdCurso);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, [FromBody] Curso curso)
        {
            if (id != curso.IdCurso)
            {
                return BadRequest();
            }
            await _cursoService.UpdateCursoAsync(curso);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            await _cursoService.DeleteCursoAsync(id);
            return NoContent();
        }
    }
}
