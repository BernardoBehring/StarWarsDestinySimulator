using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class UpkeepPhaseMap : EntityIdMap<UpkeepPhase>, IEntityTypeConfiguration<UpkeepPhase>
    {
        public new void Configure(EntityTypeBuilder<UpkeepPhase> builder)
        {
            base.Configure(builder);
            builder.ToTable("UpkeepPhase");

            builder.Property(e => e.RoundId);

            builder.HasOne(d => d.Round)
                .WithOne(p => p.UpkeepPhase)
                .HasForeignKey<UpkeepPhase>(d => d.RoundId);
        }
    }
}
