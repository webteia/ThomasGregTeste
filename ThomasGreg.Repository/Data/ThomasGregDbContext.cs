using Microsoft.EntityFrameworkCore;
using ThomasGreg.Repository.Extensions;
using ThomasGreg.Repository.Mappings;
using ThomasGreg.Repository.Models;

namespace ThomasGregTeste.Data
{
    public class ThomasGregDbContext : DbContext
    {
        public ThomasGregDbContext()
        {

        }
        public ThomasGregDbContext(DbContextOptions<ThomasGregDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Logradouro> Logradouros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                Environment.GetEnvironmentVariable("Default"),
                 options => options.EnableRetryOnFailure());

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Producao" ||
                Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Production")
                optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new ClienteMapping());
            modelBuilder.AddConfiguration(new LogradouroMapping());
            CarregarEntidades(modelBuilder);
        }

        private void CarregarEntidades(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
