using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Crawler.Model;

namespace StarWarsDestiny.Crawler.Repository.Maps
{
    public class RobotTypeMap : EntityIdMap<RobotType>, IEntityTypeConfiguration<RobotType>
    {
        public new void Configure(EntityTypeBuilder<RobotType> builder)
        {
            base.Configure(builder);
            builder.ToTable("RobotType");
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
