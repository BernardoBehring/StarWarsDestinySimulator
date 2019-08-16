using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class DiceFaceMap : EntityIdMap<DiceFace>, IEntityTypeConfiguration<DiceFace>
    {
        public new void Configure(EntityTypeBuilder<DiceFace> builder)
        {
            base.Configure(builder);
            builder.ToTable("DiceFace");

            builder.Property(e => e.Value)
                .IsRequired();

            builder.Property(e => e.IsModifier)
                .IsRequired();

            builder.Property(e => e.DiceActionId)
                .IsRequired();

            builder.Property(e => e.Cost)
                .IsRequired();

            builder.Property(e => e.DieId)
                .IsRequired();

            builder.HasOne(d => d.DiceAction)
                .WithMany(p => p.DiceFaces)
                .HasForeignKey(d => d.DiceActionId);

            builder.HasOne(d => d.Die)
                .WithMany(p => p.DiceFaces)
                .HasForeignKey(d => d.DieId);
        }
    }
}
