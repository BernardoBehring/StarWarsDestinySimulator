using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class PlayerRoundCardInPlayMap : EntityIdMap<PlayerRoundCardInPlay>,
        IEntityTypeConfiguration<PlayerRoundCardInPlay>
    {
        public new void Configure(EntityTypeBuilder<PlayerRoundCardInPlay> builder)
        {
            base.Configure(builder);
            builder.ToTable("PlayerRoundCardInPlay");

            builder.Property(e => e.PlayerRoundId);

            builder.Property(e => e.CardId);

            builder.HasOne(d => d.Card)
                .WithMany(p => p.PlayerRoundCardsInPlay)
                .HasForeignKey(d => d.CardId);

            builder.HasOne(d => d.PlayerRound)
                .WithMany(p => p.CardsInPlay)
                .HasForeignKey(d => d.PlayerRoundId);
        }
    }
}
