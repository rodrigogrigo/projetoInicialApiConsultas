using Microsoft.EntityFrameworkCore;
using PrimeiraApiConsulta.Models;

namespace PrimeiraApiConsulta.Data
{
    // Representação do banco de dados em memória
    public class AppDbContext : DbContext
    {
        // Representação da tabela
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
        

        // Para cada model existente, um DbSet será criado
    }
}
