using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Crawler.Model;

namespace StarWarsDestiny.Crawler.Repository.Maps
{
    public class SiteMap : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            //builder.ToTable("Site");
            //builder.Property(x => x.Id).ValueGeneratedOnAdd();
            //builder.Property(x => x.Name);
            //builder.Property(x => x.Url);
            //builder.HasMany(x => x.Robots).WithOne(x => x.Site).HasForeignKey(x => x.);
        }
    }
}
