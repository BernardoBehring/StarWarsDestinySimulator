using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class CardTypeMap : EntityIdMap<CardType>, IEntityTypeConfiguration<CardType>
    {
        public new void Configure(EntityTypeBuilder<CardType> builder)
        {
            base.Configure(builder);
            builder.ToTable("CardType");

            builder.Property(e => e.CardId)
                .IsRequired();

            builder.Property(e => e.TypeId)
                .IsRequired();

            builder.HasOne(d => d.Card)
                .WithMany(p => p.CardTypes)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Type)
                .WithMany(p => p.CardTypes)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
