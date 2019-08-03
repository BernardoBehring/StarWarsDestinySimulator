using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class DiceActionMap : EntityIdMap<DiceAction>, IEntityTypeConfiguration<DiceAction>
    {
        public new void Configure(EntityTypeBuilder<DiceAction> builder)
        {
            base.Configure(builder);
            builder.ToTable("DiceAction");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
