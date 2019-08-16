using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Crawler.Model;

namespace StarWarsDestiny.Crawler.Repository.Maps
{
    public class RobotMap : EntityIdMap<Robot>, IEntityTypeConfiguration<Robot>
    {
        public new void Configure(EntityTypeBuilder<Robot> builder)
        {
            base.Configure(builder);
            builder.ToTable("Robot");
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(x => x.RobotTypeId);
            builder.Property(x => x.SiteId);

            builder.HasOne(d => d.RobotType)
                .WithMany(p => p.Robots)
                .HasForeignKey(d => d.RobotTypeId);

            builder.HasOne(d => d.Site)
                .WithMany(p => p.Robots)
                .HasForeignKey(d => d.SiteId);
        }
    }
}
