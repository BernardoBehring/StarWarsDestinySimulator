using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class CharacterCardMap : IEntityTypeConfiguration<CharacterCard>
    {
        public new void Configure(EntityTypeBuilder<CharacterCard> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("CharacterCard");

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
