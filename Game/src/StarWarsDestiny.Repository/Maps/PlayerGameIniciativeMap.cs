using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class PlayerGameIniciativeMap : EntityIdMap<PlayerGameIniciative>,
        IEntityTypeConfiguration<PlayerGameIniciative>
    {
        public new void Configure(EntityTypeBuilder<PlayerGameIniciative> builder)
        {
            base.Configure(builder);
            builder.ToTable("PlayerGameIniciative");

            builder.Property(e => e.SetUpId);

            builder.Property(e => e.PlayerGameId);

            builder.Property(e => e.Iniciative);

            builder.HasOne(d => d.PlayerGame)
                .WithMany(p => p.PlayerGameIniciatives)
                .HasForeignKey(d => d.PlayerGameId);

            builder.HasOne(d => d.SetUp)
                .WithMany(p => p.PlayerGameIniciatives)
                .HasForeignKey(d => d.SetUpId);
        }
    }
}
