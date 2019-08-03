using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class LegalityMap : EntityIdMap<Legality>, IEntityTypeConfiguration<Legality>
    {
        public new void Configure(EntityTypeBuilder<Legality> builder)
        {
            base.Configure(builder);
            builder.ToTable("Legality");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
