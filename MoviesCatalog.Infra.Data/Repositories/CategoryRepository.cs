using MoviesCatalog.Domain.Entities;
using MoviesCatalog.Domain.Interfaces;
using MoviesCatalog.Infra.Data.Context;

namespace MoviesCatalog.Infra.Data.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    { }

}