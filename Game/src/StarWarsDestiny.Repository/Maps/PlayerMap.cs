using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class PlayerMap : EntityIdMap<Player>, IEntityTypeConfiguration<Player>
    {
        public new void Configure(EntityTypeBuilder<Player> builder)
        {
            base.Configure(builder);
            builder.ToTable("Player");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
