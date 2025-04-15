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
            base.OnModelCreating(modelBuilder);  // Para chamar qualquer configuração da classe base, caso necessário.

            modelBuilder.Entity<Aluno>()
                .HasKey(a => a.IdAluno);  // Configuração da chave primária para a entidade Aluno

            // Configuração de relacionamento One-to-One entre Aluno e Contato
            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Contato)
                .WithOne(c => c.Aluno)
                .HasForeignKey<Contato>(c => c.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);  // Caso o aluno seja excluído, o contato não será removido, apenas o AlunoId será setado para null

            // Configuração de relacionamento One-to-One entre Aluno e Endereco
            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Endereco)
                .WithOne(e => e.Aluno)
                .HasForeignKey<Endereco>(e => e.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);  // Caso o aluno seja excluído, o endereço também será removido, mas pode ser configurado a partir de SetNull se necessário
        }
    }
}
