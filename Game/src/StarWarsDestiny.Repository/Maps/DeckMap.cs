using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class DeckMap : EntityIdMap<Deck>, IEntityTypeConfiguration<Deck>
    {
        public new void Configure(EntityTypeBuilder<Deck> builder)
        {
            base.Configure(builder);
            builder.ToTable("Deck");

            builder.Property(e => e.Url)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
