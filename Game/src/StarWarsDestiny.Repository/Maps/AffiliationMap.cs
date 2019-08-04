using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class AffiliationMap : EntityIdMap<Affiliation>, IEntityTypeConfiguration<Affiliation>
    {
        public new void Configure(EntityTypeBuilder<Affiliation> builder)
        {
            base.Configure(builder);
            builder.ToTable("Affiliation");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
