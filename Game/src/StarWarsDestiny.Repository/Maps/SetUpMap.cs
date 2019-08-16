using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class SetUpMap : EntityIdMap<SetUp>, IEntityTypeConfiguration<SetUp>
    {
        public new void Configure(EntityTypeBuilder<SetUp> builder)
        {
            base.Configure(builder);
            builder.ToTable("SetUp");

            builder.Property(e => e.GameId);

            builder.Property(e => e.BattlefieldChoosedId);

            builder.HasOne(d => d.Game)
                .WithOne(p => p.SetUp)
                .HasForeignKey<SetUp>(d => d.GameId);

            builder.HasOne(d => d.BattlefieldChoosed)
                .WithMany(p => p.SetUps)
                .HasForeignKey(d => d.BattlefieldChoosedId);
        }
    }
}
