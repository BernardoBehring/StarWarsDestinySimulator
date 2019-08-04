using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class SetStarWarsMap : EntityIdMap<SetStarWars>, IEntityTypeConfiguration<SetStarWars>
    {
        public new void Configure(EntityTypeBuilder<SetStarWars> builder)
        {
            base.Configure(builder);
            builder.ToTable("SetStarWars");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
