using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class DieMap : EntityIdMap<Die>, IEntityTypeConfiguration<Die>
    {
        public new void Configure(EntityTypeBuilder<Die> builder)
        {
            base.Configure(builder);
            builder.ToTable("Die");

            builder.Property(e => e.CardId)
                .IsRequired();
        }
    }
}
