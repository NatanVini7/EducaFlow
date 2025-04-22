using EducaFlow.Context;
using EducaFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace EducaFlow.Services
{
    public class EscolaService
    {
        private readonly EscolaContext _context;
        public EscolaService(EscolaContext context)
        {
            _context = context;
        }
        public async Task<List<Escola>> GetEscolasAsync()
        {
            return await _context.Escolas
                .Include(e => e.Contato)
                .Include(e => e.Endereco)
                .ToListAsync();
        }
        public async Task<Escola?> GetEscolaByIdAsync(int id)
        {
            return await _context.Escolas
                .Include(e => e.Contato)
                .Include(e => e.Endereco)
                .FirstOrDefaultAsync(e => e.IdEscola == id);
        }
        public async Task<Escola> AddEscolaAsync(Escola escola)
        {
            _context.Escolas.Add(escola);
            await _context.SaveChangesAsync();
            return escola;
        }
        public async Task<Escola> UpdateEscolaAsync(Escola escola)
        {
            _context.Escolas.Update(escola);
            await _context.SaveChangesAsync();
            return escola;
        }
        public async Task DeleteEscolaAsync(int id)
        {
            var escola = await _context.Escolas.FindAsync(id);
            if (escola != null)
            {
                _context.Escolas.Remove(escola);
                await _context.SaveChangesAsync();
            }
        }
    }
}
