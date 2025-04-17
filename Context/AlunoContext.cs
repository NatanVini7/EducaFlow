using EducaFlow.Models;
using Microsoft.EntityFrameworkCore;

namespace EducaFlow.Context
{
    public class AlunoContext : DbContext
    {
        public AlunoContext(DbContextOptions<AlunoContext> options) : base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>()
                .HasKey(a => a.IdAluno);  

            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Contato);

            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Endereco);

        }
    }
}
