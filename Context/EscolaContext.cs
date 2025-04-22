using EducaFlow.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EducaFlow.Context
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options)
        {
        }

        public DbSet<Escola> Escolas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Escola>()
                .HasKey(e => e.IdEscola);
            modelBuilder.Entity<Escola>()
                .HasOne(e => e.Endereco)
                .WithMany()
                .HasForeignKey(e => e.IdEndereco);
            modelBuilder.Entity<Escola>()
                .HasOne(e => e.Contato)
                .WithMany()
                .HasForeignKey(e => e.IdContato);
        }
    }

    public class EscolaContextFactory : IDesignTimeDbContextFactory<EscolaContext>
    {
        public EscolaContext CreateDbContext(string[] args)
        {
            // Carrega manualmente o appsettings.json para pegar a string de conexão
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<EscolaContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            return new EscolaContext(builder.Options);
        }
    }
}
