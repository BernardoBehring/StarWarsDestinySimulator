using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class TypeMap : EntityIdMap<Type>, IEntityTypeConfiguration<Type>
    {
        public new void Configure(EntityTypeBuilder<Type> builder)
        {
            base.Configure(builder);
            builder.ToTable("Type");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
