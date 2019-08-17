using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class PlayerRoundRolledDiceMap : EntityIdMap<PlayerRoundRolledDice>,
        IEntityTypeConfiguration<PlayerRoundRolledDice>
    {
        public new void Configure(EntityTypeBuilder<PlayerRoundRolledDice> builder)
        {
            base.Configure(builder);
            builder.ToTable("PlayerRoundRolledDice");

            builder.Property(e => e.PlayerRoundId);

            builder.Property(e => e.DieId);

            builder.Property(e => e.DiceFaceId);

            builder.HasOne(d => d.DiceFace)
                .WithMany(p => p.PlayerRoundRolledDices)
                .HasForeignKey(d => d.DiceFaceId);

            builder.HasOne(d => d.Die)
                .WithMany(p => p.PlayerRoundRolledDices)
                .HasForeignKey(d => d.DieId);

            builder.HasOne(d => d.PlayerRound)
                .WithMany(p => p.DicePool)
                .HasForeignKey(d => d.PlayerRoundId);
        }
    }
}
