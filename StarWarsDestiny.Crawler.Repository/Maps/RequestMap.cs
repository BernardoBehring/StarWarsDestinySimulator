using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Crawler.Model;

namespace StarWarsDestiny.Crawler.Repository.Maps
{
    public class RequestMap : EntityIdMap<Request>, IEntityTypeConfiguration<Request>
    {
        public new void Configure(EntityTypeBuilder<Request> builder)
        {
            base.Configure(builder);
            builder.ToTable("Request");
            builder.Property(x => x.StatusId);
            builder.Property(x => x.RobotId);
            builder.Property(x => x.RegisterDate).HasColumnType("datetime");
            builder.Property(x => x.StartDateExecution).HasColumnType("datetime");
            builder.Property(x => x.EndDateExecution).HasColumnType("datetime");
            builder.Property(x => x.Response);
            builder.Property(x => x.AttemptQty);
            
            builder.HasOne(d => d.Robot)
                .WithMany(p => p.Requests)
                .HasForeignKey(d => d.RobotId);

            builder.HasOne(d => d.Status)
                .WithMany(p => p.Requests)
                .HasForeignKey(d => d.StatusId);
        }
    }
}
