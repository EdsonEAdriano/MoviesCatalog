using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesCatalog.Domain.Entities;

namespace MoviesCatalog.Infra.Data.EntitiesConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();

        builder.HasData(
            new Category(1, "Ficção"),
            new Category(2, "Suspense"),
            new Category(3, "Terror"),
            new Category(4, "Comédia")
        );
    }
}