using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class BattleFieldMap : EntityIdMap<Battlefield>, IEntityTypeConfiguration<Battlefield>
    {
        public new void Configure(EntityTypeBuilder<Battlefield> builder)
        {
            base.Configure(builder);
            builder.ToTable("BattleField");

            builder.Property(e => e.BattlefieldCardId);

            builder.Property(e => e.GameId);

            builder.HasOne(d => d.BattlefieldCard)
                .WithMany(p => p.Battlefields)
                .HasForeignKey(d => d.BattlefieldCardId);

            builder.HasOne(d => d.Game)
                .WithOne(p => p.Battlefield)
                .HasForeignKey<Battlefield>(d => d.GameId);
        }
    }
}
