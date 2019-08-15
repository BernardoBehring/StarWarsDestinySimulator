using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class ActionMap : EntityIdMap<Action>, IEntityTypeConfiguration<Action>
    {
        public new void Configure(EntityTypeBuilder<Action> builder)
        {
            base.Configure(builder);
            builder.ToTable("Action");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
