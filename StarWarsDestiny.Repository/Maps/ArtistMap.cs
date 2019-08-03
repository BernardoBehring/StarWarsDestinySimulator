using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class ArtistMap : EntityIdMap<Artist>, IEntityTypeConfiguration<Artist>
    {
        public new void Configure(EntityTypeBuilder<Artist> builder)
        {
            base.Configure(builder);
            builder.ToTable("Artist");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
