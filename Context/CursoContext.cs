using EducaFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace EducaFlow.Context
{
    public class CursoContext : DbContext
    {
        public CursoContext(DbContextOptions<CursoContext> options) : base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Curso>()
                .HasKey(a => a.IdCurso);

        }
    }
}
