using Microsoft.EntityFrameworkCore;
using StarWarsDestiny.Crawler.Model;

namespace StarWarsDestiny.Crawler.Repository.Context
{
    public class CrawlerContext : DbContext
    {
        public CrawlerContext(DbContextOptions<CrawlerContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TODO COLOCAR NO APP SETTINGS
            //optionsBuilder.UseSqlServer("Data Source=localhost\\MSSQLSERVER01; DataBase=StarWarsDestinyCrawler;Integrated Security=True");
            optionsBuilder.UseNpgsql(
                "User ID=kgpfxqphujvjvr;Password=4b0a2cbcd0c0731368e01574230d765e0d9c229dec8ae642c8298add428a981e;Host=ec2-50-19-254-63.compute-1.amazonaws.com;Port=5432;Database=d54k8gn3rvihiv;sslmode=Require;Trust Server Certificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrawlerContext).Assembly);

        public DbSet<Request> Requests { get; set; }
        public DbSet<Robot> Robots { get; set; }
        public DbSet<RobotType> RobotTypes { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
