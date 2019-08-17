using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class PlayerRoundMap : EntityIdMap<PlayerRound>,
        IEntityTypeConfiguration<PlayerRound>
    {
        public new void Configure(EntityTypeBuilder<PlayerRound> builder)
        {
            base.Configure(builder);
            builder.ToTable("PlayerRound");

            builder.Property(e => e.PlayerGameId);

            builder.Property(e => e.RoundGameId);

            builder.Property(e => e.Resources);

            builder.HasOne(d => d.PlayerGame)
                .WithMany(p => p.PlayerRounds)
                .HasForeignKey(d => d.PlayerGameId);

            builder.HasOne(d => d.RoundGame)
                .WithMany(p => p.PlayerRounds)
                .HasForeignKey(d => d.RoundGameId);
        }
    }
}
