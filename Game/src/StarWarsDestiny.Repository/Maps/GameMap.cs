using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class GameMap : EntityIdMap<Game>, IEntityTypeConfiguration<Game>
    {
        public new void Configure(EntityTypeBuilder<Game> builder)
        {
            base.Configure(builder);
            builder.ToTable("Game");

            builder.Property(e => e.BattleFieldId);
            builder.Property(e => e.SetUpId);

            builder.HasOne(d => d.Battlefield)
                .WithOne(p => p.Game)
                .HasForeignKey<Game>(d => d.BattleFieldId);

            builder.HasOne(d => d.SetUp)
                .WithOne(p => p.Game)
                .HasForeignKey<Game>(d => d.SetUpId);
        }
    }
}
