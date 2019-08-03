using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class BalanceForceMap : EntityIdMap<BalanceForce>, IEntityTypeConfiguration<BalanceForce>
    {
        public new void Configure(EntityTypeBuilder<BalanceForce> builder)
        {
            base.Configure(builder);
            builder.ToTable("BalanceForce");

            builder.Property(e => e.CardId)
                .IsRequired();

            builder.Property(e => e.LegalityId)
                .IsRequired();

            builder.Property(e => e.Health)
                .HasColumnName("Health")
                .IsRequired();

            builder.Property(e => e.ElitePoints)
                .HasColumnName("ElitePoints");

            builder.Property(e => e.Points)
                .HasColumnName("Points");

            builder.HasOne(d => d.Card)
                .WithMany(p => p.BalanceForces)
                .HasForeignKey(d => d.CardId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Legality)
                .WithMany(p => p.BalanceForces)
                .HasForeignKey(d => d.LegalityId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
