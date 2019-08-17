using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class EffectMap : EntityIdMap<Effect>, IEntityTypeConfiguration<Effect>
    {
        public new void Configure(EntityTypeBuilder<Effect> builder)
        {
            base.Configure(builder);
            builder.ToTable("Effect");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
