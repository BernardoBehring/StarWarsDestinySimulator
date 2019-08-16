using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class PlayerRoundCardInPlayUpgradeMap : EntityIdMap<PlayerRoundCardInPlayUpgrade>,
        IEntityTypeConfiguration<PlayerRoundCardInPlayUpgrade>
    {
        public new void Configure(EntityTypeBuilder<PlayerRoundCardInPlayUpgrade> builder)
        {
            base.Configure(builder);
            builder.ToTable("PlayerRoundCardInPlayUpgrade");

            builder.Property(e => e.PlayerRoundCardInPlayId);

            builder.Property(e => e.Exausted);

            builder.Property(e => e.CanBeExausted);

            builder.HasOne(d => d.PlayerRoundCardInPlay)
                .WithMany(p => p.Upgrades)
                .HasForeignKey(d => d.PlayerRoundCardInPlayId);
        }
    }
}
