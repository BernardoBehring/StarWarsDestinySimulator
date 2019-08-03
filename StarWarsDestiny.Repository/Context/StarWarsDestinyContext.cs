using Microsoft.EntityFrameworkCore;

namespace StarWarsDestiny.Repository.Context
{
    public class StarWarsDestinyContext : DbContext
    {
        public StarWarsDestinyContext(DbContextOptions<StarWarsDestinyContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO COLOCAR NO APP SETTINGS
            optionsBuilder.UseSqlServer("Data Source=localhost\\MSSQLSERVER01; DataBase=StarWarsDestiny;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StarWarsDestinyContext).Assembly);
    }
}
