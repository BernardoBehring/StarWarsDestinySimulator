using Microsoft.EntityFrameworkCore;
using StarWarsDestiny.Crawler.Model;

namespace StarWarsDestiny.Crawler.Repository.Context
{
    public class CrawlerContext : DbContext
    {
        public CrawlerContext(DbContextOptions<CrawlerContext> options) : base(options)
        {

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
