using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class TurnMap : EntityIdMap<Turn>, IEntityTypeConfiguration<Turn>
    {
        public new void Configure(EntityTypeBuilder<Turn> builder)
        {
            base.Configure(builder);
            builder.ToTable("Turn");

            builder.Property(e => e.Number);

            builder.Property(e => e.ActionPhaseId);

            builder.HasOne(d => d.ActionPhase)
                .WithMany(p => p.Turn)
                .HasForeignKey(d => d.ActionPhaseId);
        }
    }
}
