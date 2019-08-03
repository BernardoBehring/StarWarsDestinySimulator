using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Common.Repository.Map
{
    public class EntityIdMap<T> : IEntityTypeConfiguration<T> where T : EntityId
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.InsertedIn).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.UpdatedIn).HasColumnType("datetime");
            builder.Property(x => x.DeletedIn).HasColumnType("datetime");
        }
    }
}
