using Journey.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Journey.Infrastructure
{
    public class JourneyDbContext : DbContext
    {
        // Acesso direto a tabela "Viagem"
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Activity> Activities { get; set; }

        // Sobrescrever uma função da classe "DbContext"
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurando para traduzir
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\PC\\Documents\\JourneyDatabase.db");
        }
    }
}
