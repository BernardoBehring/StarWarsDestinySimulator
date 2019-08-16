using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class RoundMap : EntityIdMap<Round>, IEntityTypeConfiguration<Round>
    {
        public new void Configure(EntityTypeBuilder<Round> builder)
        {
            base.Configure(builder);
            builder.ToTable("Round");

            builder.Property(e => e.UpkeepPhaseId);

            builder.Property(e => e.ActionPhaseId);

            builder.Property(e => e.BattleFieldClaimed);

            builder.Property(e => e.PlayerGameIdClaimedBattlefield);

            builder.HasOne(d => d.ActionPhase)
                .WithOne(p => p.Round)
                .HasForeignKey<Round>(d => d.ActionPhaseId);

            builder.HasOne(d => d.PlayerGameClaimedBattleField)
                .WithMany(p => p.RoundsClaimedBattleField)
                .HasForeignKey(d => d.PlayerGameIdClaimedBattlefield);

            builder.HasOne(d => d.UpkeepPhase)
                .WithOne(p => p.Round)
                .HasForeignKey<Round>(d => d.UpkeepPhaseId);
        }
    }
}
