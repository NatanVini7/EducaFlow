using EducaFlow.Context;
using EducaFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace EducaFlow.Services
{
    public class SerieService
    {
        private readonly SerieContext _context;

        public SerieService(SerieContext context)
        {
            _context = context;
        }

        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await _context.Series
                .Include(a => a.Curso)
                .ToListAsync();
        }
        public async Task<Serie?> GetSerieByIdAsync(int id)
        {
            return await _context.Series
                .Include(a => a.Curso)
                .FirstOrDefaultAsync(a => a.IdSerie == id);
        }
        public async Task<Serie> AddSerieAsync(Serie serie)
        {
            _context.Series.Add(serie);
            await _context.SaveChangesAsync();
            return serie;
        }
        public async Task<Serie> UpdateSerieAsync(Serie serie)
        {
            _context.Series.Update(serie);
            await _context.SaveChangesAsync();
            return serie;
        }
        public async Task DeleteSerieAsync(int id)
        {
            var serie = await _context.Series.FindAsync(id);
            if (serie != null)
            {
                _context.Series.Remove(serie);
                await _context.SaveChangesAsync();
            }
        }
    }
}
