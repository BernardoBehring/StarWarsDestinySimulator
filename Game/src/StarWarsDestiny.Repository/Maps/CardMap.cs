using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWarsDestiny.Common.Repository.Map;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Repository.Maps
{
    public class CardMap : EntityIdMap<Card>, IEntityTypeConfiguration<Card>
    {
        public new void Configure(EntityTypeBuilder<Card> builder)
        {
            base.Configure(builder);
            builder.ToTable("Card");

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Subtitle)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Text)
                .IsUnicode(false);

            builder.Property(e => e.ArtistId);

            builder.Property(e => e.AffiliationId);

            builder.Property(e => e.FactionId);

            builder.Property(e => e.ColorId);

            builder.Property(e => e.RarityId);

            builder.Property(e => e.DieId);

            builder.Property(e => e.SetStarWarsId);

            builder.Property(e => e.Url)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(e => e.DataCode)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Points);

            builder.Property(e => e.ElitePoints);

            builder.Property(e => e.Health);

            builder.Property(e => e.Cost);

            builder.Property(e => e.IsCharacter);

            builder.Property(e => e.IsUnique);

            builder.Property(e => e.Flavor)
                .IsUnicode(false);

            builder.HasOne(d => d.Affiliation)
                .WithMany(p => p.Cards)
                .HasForeignKey(d => d.AffiliationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Artist)
                .WithMany(p => p.Cards)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Color)
                .WithMany(p => p.Cards)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Die)
                .WithOne(p => p.Card)
                .HasForeignKey<Card>(d => d.DieId);

            builder.HasOne(d => d.Faction)
                .WithMany(p => p.Cards)
                .HasForeignKey(d => d.FactionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Rarity)
                .WithMany(p => p.Cards)
                .HasForeignKey(d => d.RarityId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.SetStarWars)
                .WithMany(p => p.Cards)
                .HasForeignKey(d => d.SetStarWarsId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
