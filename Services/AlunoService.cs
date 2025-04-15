using EducaFlow.Context;
using EducaFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace EducaFlow.Services
{
    public class AlunoService
    {
        private readonly AlunoContext _context;

        public AlunoService(AlunoContext context)
        {
            _context = context;
        }

        public async Task<List<Aluno>> GetAlunosAsync()
        {
            return await _context.Alunos
                .Include(a => a.Contato)
                .Include(a => a.Endereco)
                .ToListAsync();
        }
        public async Task<Aluno?> GetAlunoByIdAsync(int id)
        {
            return await _context.Alunos
                .Include(a => a.Contato)
                .Include(a => a.Endereco)
                .FirstOrDefaultAsync(a => a.IdAluno == id);
        }
        public async Task<Aluno> AddAlunoAsync(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }
        public async Task<Aluno> UpdateAlunoAsync(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync();
            return aluno;
        }
        public async Task DeleteAlunoAsync(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno != null)
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
            }
        }
    }
}
