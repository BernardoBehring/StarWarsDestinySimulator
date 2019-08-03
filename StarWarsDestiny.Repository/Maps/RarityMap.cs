using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class RarityMap : EntityIdMap<Rarity>, IEntityTypeConfiguration<Rarity>
    {
        public new void Configure(EntityTypeBuilder<Rarity> builder)
        {
            base.Configure(builder);
            builder.ToTable("Rarity");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
