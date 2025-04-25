using EducaFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace EducaFlow.Context
{
    public class SerieContext : DbContext
    {
        public SerieContext(DbContextOptions<SerieContext> options) : base(options)
        {
        }

        public DbSet<Serie> Series { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Serie>()
                .HasKey(a => a.IdSerie);

            modelBuilder.Entity<Serie>()
                .HasOne(a => a.Curso);

        }
    }
}
