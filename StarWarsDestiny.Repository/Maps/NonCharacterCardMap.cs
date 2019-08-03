using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class NonCharacterCardMap : EntityIdMap<NonCharacterCard>, IEntityTypeConfiguration<NonCharacterCard>
    {
        public new void Configure(EntityTypeBuilder<NonCharacterCard> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("NonCharacterCard");

            builder.Property(e => e.Id)
                .HasColumnName("CardId")
                .ValueGeneratedNever();

            builder.Property()

            builder.HasOne(d => d.Card)
                .WithOne(p => p.CharacterCard)
                .HasForeignKey<CharacterCard>(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
