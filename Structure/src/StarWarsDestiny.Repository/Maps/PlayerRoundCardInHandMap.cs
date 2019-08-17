using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class PlayerRoundCardInHandMap : EntityIdMap<PlayerRoundCardInHand>,
        IEntityTypeConfiguration<PlayerRoundCardInHand>
    {
        public new void Configure(EntityTypeBuilder<PlayerRoundCardInHand> builder)
        {
            base.Configure(builder);
            builder.ToTable("PlayerRoundCardInHand");

            builder.Property(e => e.PlayerRoundId);

            builder.Property(e => e.CardId);

            builder.HasOne(d => d.Card)
                .WithMany(p => p.PlayerRoundCardInHands)
                .HasForeignKey(d => d.CardId);

            builder.HasOne(d => d.PlayerRound)
                .WithMany(p => p.CardsInHand)
                .HasForeignKey(d => d.PlayerRoundId);
        }
    }
}
