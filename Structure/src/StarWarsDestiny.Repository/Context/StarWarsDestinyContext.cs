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
            //optionsBuilder.UseSqlServer("Data Source=localhost\\MSSQLSERVER01; DataBase=StarWarsDestiny;Integrated Security=True");
            optionsBuilder.UseNpgsql(
                "User ID=kgpfxqphujvjvr;Password=4b0a2cbcd0c0731368e01574230d765e0d9c229dec8ae642c8298add428a981e;Host=ec2-50-19-254-63.compute-1.amazonaws.com;Port=5432;Database=d54k8gn3rvihiv;Pooling=true; Min Pool Size=0; Max Pool Size=100; Connection Lifetime=0;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(StarWarsDestinyContext).Assembly);
    }
}
