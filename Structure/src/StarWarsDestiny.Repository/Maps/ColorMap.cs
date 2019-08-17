using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class ColorMap : EntityIdMap<Color>, IEntityTypeConfiguration<Color>
    {
        public new void Configure(EntityTypeBuilder<Color> builder)
        {
            base.Configure(builder);
            builder.ToTable("Color");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
