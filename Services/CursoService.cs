using EducaFlow.Context;
using EducaFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace EducaFlow.Services
{
    public class CursoService
    {
        private readonly CursoContext _context;

        public CursoService(CursoContext context)
        {
            _context = context;
        }

        public async Task<List<Curso>> GetCursosAsync()
        {
            return await _context.Cursos
                .ToListAsync();
        }
        public async Task<Curso?> GetCursoByIdAsync(int id)
        {
            return await _context.Cursos
                .FirstOrDefaultAsync(a => a.IdCurso == id);
        }
        public async Task<Curso> AddCursoAsync(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            return curso;
        }
        public async Task<Curso> UpdateCursoAsync(Curso curso)
        {
            _context.Cursos.Update(curso);
            await _context.SaveChangesAsync();
            return curso;
        }
        public async Task DeleteCursoAsync(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
                await _context.SaveChangesAsync();
            }
        }
    }
}
