using EducaFlow.Models;
using EducaFlow.Services;
using Microsoft.AspNetCore.Mvc;

namespace EducaFlow.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _alunoService;

        public AlunoController(AlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Aluno>>> GetAlunos()
        {
            var alunos = await _alunoService.GetAlunosAsync();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAlunoById(int id)
        {
            var aluno = await _alunoService.GetAlunoByIdAsync(id);
            if (aluno == null)
                return NotFound();

            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> AddAluno(Aluno aluno)
        {
            var novoAluno = await _alunoService.AddAlunoAsync(aluno);
            return CreatedAtAction(nameof(GetAlunoById), new { id = novoAluno.IdAluno }, novoAluno);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Aluno>> UpdateAluno(int id, Aluno aluno)
        {
            if (id != aluno.IdAluno)
                return BadRequest("ID do aluno não confere.");

            var alunoAtualizado = await _alunoService.UpdateAlunoAsync(aluno);
            return Ok(alunoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            await _alunoService.DeleteAlunoAsync(id);
            return NoContent();
        }
    }
}
