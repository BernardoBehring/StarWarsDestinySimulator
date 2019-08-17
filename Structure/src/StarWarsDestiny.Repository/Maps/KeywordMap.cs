using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class KeywordMap : EntityIdMap<Keyword>, IEntityTypeConfiguration<Keyword>
    {
        public new void Configure(EntityTypeBuilder<Keyword> builder)
        {
            base.Configure(builder);
            builder.ToTable("Keyword");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Text)
                .IsRequired()
                .IsUnicode(false);
        }
    }
}
