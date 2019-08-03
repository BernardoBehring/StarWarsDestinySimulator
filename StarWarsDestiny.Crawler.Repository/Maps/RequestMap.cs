using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Crawler.Model;

namespace StarWarsDestiny.Crawler.Repository.Maps
{
    public class RequestMap : EntityIdMap<Request>, IEntityTypeConfiguration<Request>
    {
        public new void Configure(EntityTypeBuilder<Request> builder)
        {
            base.Configure(builder);
            //builder.ToTable("Site");
            builder.Property(x => x.Name);
            builder.Property(x => x.Url);
            builder.HasMany(x => x.Robots).WithOne(x => x.Site).HasForeignKey(x => x.);
        }
    }
}
