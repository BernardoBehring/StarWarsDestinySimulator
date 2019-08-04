using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Crawler.Model;

namespace StarWarsDestiny.Crawler.Repository.Maps
{
    public class SiteMap : EntityIdMap<Site>, IEntityTypeConfiguration<Site>
    {
        public new void Configure(EntityTypeBuilder<Site> builder)
        {
            base.Configure(builder);
            builder.ToTable("Site");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Url)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
