using Library;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Repository.EntityConfig;

namespace Repository.Contexts
{
    public class Context : DbContext
    {
        private readonly IConfiguration _configuration;

        public Context(DbContextOptions<Context> options, IConfiguration configuration) : base(options)
        {
            this._configuration = configuration;
        }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Telefone> Telefone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Default"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.HasPostgresExtension("uuid - ossp");

            _ = modelBuilder.ApplyConfiguration(new PessoaEntityConfig());
            _ = modelBuilder.ApplyConfiguration(new TelefoneEntityConfig());
        }
    }
}
