using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Domain.Entities;
using MoviesCatalog.Domain.Interfaces;
using MoviesCatalog.Infra.Data.Context;

namespace MoviesCatalog.Infra.Data.Repositories;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(ApplicationDbContext context) : base(context)
    { }
    
    public async Task<Movie> GetAsync(Category category)
    {
        return await _context
            .Movies
            .Include(m => m.Category)
            .SingleOrDefaultAsync(m => m.Id == category.Id);
    }
}