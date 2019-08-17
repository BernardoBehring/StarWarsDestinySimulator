using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class PlayerRoundCardInLimboMap : EntityIdMap<PlayerRoundCardInLimbo>,
        IEntityTypeConfiguration<PlayerRoundCardInLimbo>
    {
        public new void Configure(EntityTypeBuilder<PlayerRoundCardInLimbo> builder)
        {
            base.Configure(builder);
            builder.ToTable("PlayerRoundCardInLimbo");

            builder.Property(e => e.PlayerRoundId);

            builder.Property(e => e.CardId);

            builder.HasOne(d => d.Card)
                .WithMany(p => p.PlayerRoundCardInLimbo)
                .HasForeignKey(d => d.CardId);

            builder.HasOne(d => d.PlayerRound)
                .WithMany(p => p.Limbo)
                .HasForeignKey(d => d.PlayerRoundId);
        }
    }
}
