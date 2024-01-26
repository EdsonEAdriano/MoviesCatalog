using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesCatalog.Domain.Entities;

namespace MoviesCatalog.Infra.Data.EntitiesConfiguration;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Title).HasMaxLength(100).IsRequired();
        builder.Property(m => m.Description).HasMaxLength(200).IsRequired();
        
        builder.Property(m => m.ReleaseDate).IsRequired();

        builder.HasOne(m => m.Category)
            .WithMany(c => c.Movies)
            .HasForeignKey(m => m.CategoryId);
    }
}