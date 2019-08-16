using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class PlayerGameMap : EntityIdMap<PlayerGame>, IEntityTypeConfiguration<PlayerGame>
    {
        public new void Configure(EntityTypeBuilder<PlayerGame> builder)
        {
            base.Configure(builder);
            builder.ToTable("PlayerGame");

            builder.Property(e => e.GameId);

            builder.Property(e => e.PlayerId);

            builder.Property(e => e.DeckId);

            builder.HasOne(d => d.Deck)
                .WithMany(p => p.PlayerGames)
                .HasForeignKey(d => d.DeckId);

            builder.HasOne(d => d.Game)
                .WithMany(p => p.PlayerGames)
                .HasForeignKey(d => d.GameId);

            builder.HasOne(d => d.Player)
                .WithMany(p => p.PlayerGames)
                .HasForeignKey(d => d.PlayerId);
        }
    }
}
