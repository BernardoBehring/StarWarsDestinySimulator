using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class CardDeckMap : EntityIdMap<CardDeck>, IEntityTypeConfiguration<CardDeck>
    {
        public new void Configure(EntityTypeBuilder<CardDeck> builder)
        {
            base.Configure(builder);
            builder.ToTable("CardDeck");

            builder.Property(e => e.CardId);

            builder.Property(e => e.DeckId);

            builder.HasOne(d => d.Card)
                .WithMany(p => p.CardDecks)
                .HasForeignKey(d => d.CardId);

            builder.HasOne(d => d.Deck)
                .WithMany(p => p.CardDecks)
                .HasForeignKey(d => d.DeckId);
        }
    }
}
