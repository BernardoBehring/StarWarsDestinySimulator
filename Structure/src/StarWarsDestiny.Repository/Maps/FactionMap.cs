using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class FactionMap : EntityIdMap<Faction>, IEntityTypeConfiguration<Faction>
    {
        public new void Configure(EntityTypeBuilder<Faction> builder)
        {
            base.Configure(builder);
            builder.ToTable("Faction");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
