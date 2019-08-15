using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class ActionPhaseMap : EntityIdMap<ActionPhase>, IEntityTypeConfiguration<ActionPhase>
    {
        public new void Configure(EntityTypeBuilder<ActionPhase> builder)
        {
            base.Configure(builder);
            builder.ToTable("ActionPhase");

            builder.Property(e => e.RoundId);

            builder.HasOne(d => d.Round)
                .WithOne(p => p.ActionPhase)
                .HasForeignKey<ActionPhase>(d => d.RoundId);
        }
    }
}
