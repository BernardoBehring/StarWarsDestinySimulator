using Microsoft.EntityFrameworkCore;

namespace StarWarsDestiny.Repository.Context
{
    public class StarWarsDestinyContext : DbContext
    {
        public StarWarsDestinyContext(DbContextOptions<StarWarsDestinyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StarWarsDestinyContext).Assembly);
    }
}
