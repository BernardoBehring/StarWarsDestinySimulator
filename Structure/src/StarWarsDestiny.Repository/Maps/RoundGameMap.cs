using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class RoundGameMap : EntityIdMap<RoundGame>, IEntityTypeConfiguration<RoundGame>
    {
        public new void Configure(EntityTypeBuilder<RoundGame> builder)
        {
            base.Configure(builder);
            builder.ToTable("RoundGame");

            builder.Property(e => e.RoundId);

            builder.Property(e => e.GameId);

            builder.HasOne(d => d.Game)
                .WithMany(p => p.Rounds)
                .HasForeignKey(d => d.GameId);

            builder.HasOne(d => d.Round)
                .WithMany(p => p.RoundGames)
                .HasForeignKey(d => d.RoundId);
        }
    }
}
