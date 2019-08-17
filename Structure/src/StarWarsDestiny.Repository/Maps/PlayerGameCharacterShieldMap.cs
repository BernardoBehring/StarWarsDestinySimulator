using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class PlayerGameCharacterShieldMap : EntityIdMap<PlayerGameCharacterShield>,
        IEntityTypeConfiguration<PlayerGameCharacterShield>
    {
        public new void Configure(EntityTypeBuilder<PlayerGameCharacterShield> builder)
        {
            base.Configure(builder);
            builder.ToTable("PlayerGameCharacterShield");

            builder.Property(e => e.SetUpId);

            builder.Property(e => e.PlayerGameId);

            builder.Property(e => e.CharacterCardId);

            builder.Property(e => e.QtyShield);

            builder.HasOne(d => d.CharacterCard)
                .WithMany(p => p.PlayerGameCharacterShields)
                .HasForeignKey(d => d.CharacterCardId);

            builder.HasOne(d => d.PlayerGame)
                .WithMany(p => p.PlayerGameCharacterShields)
                .HasForeignKey(d => d.PlayerGameId);

            builder.HasOne(d => d.SetUp)
                .WithMany(p => p.PlayerGameCharacterShields)
                .HasForeignKey(d => d.SetUpId);
        }
    }
}
