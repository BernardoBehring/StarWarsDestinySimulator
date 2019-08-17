using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class CardLegalityMap : EntityIdMap<CardLegality>, IEntityTypeConfiguration<CardLegality>
    {
        public new void Configure(EntityTypeBuilder<CardLegality> builder)
        {
            base.Configure(builder);
            builder.ToTable("CardLegality");

            builder.Property(e => e.CardId)
                .IsRequired();

            builder.Property(e => e.LegalityId)
                .IsRequired();

            builder.Property(e => e.IsLegal)
                .IsRequired();

            builder.HasOne(d => d.Card)
                .WithMany(p => p.CardLegalities)
                .HasForeignKey(d => d.CardId);

            builder.HasOne(d => d.Legality)
                .WithMany(p => p.CardLegalities)
                .HasForeignKey(d => d.LegalityId);
        }
    }
}
