using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class PlayerRoundCardInDiscardMap : EntityIdMap<PlayerRoundCardInDiscard>,
        IEntityTypeConfiguration<PlayerRoundCardInDiscard>
    {
        public new void Configure(EntityTypeBuilder<PlayerRoundCardInDiscard> builder)
        {
            base.Configure(builder);
            builder.ToTable("PlayerRoundCardInDiscard");

            builder.Property(e => e.PlayerRoundId);

            builder.Property(e => e.CardId);

            builder.HasOne(d => d.Card)
                .WithMany(p => p.PlayerRoundCardInDiscards)
                .HasForeignKey(d => d.CardId);

            builder.HasOne(d => d.PlayerRound)
                .WithMany(p => p.DiscardPile)
                .HasForeignKey(d => d.PlayerRoundId);
        }
    }
}
