using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Domain.Entities;
using MoviesCatalog.Domain.Interfaces;
using MoviesCatalog.Infra.Data.Context;

namespace MoviesCatalog.Infra.Data.Repositories;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(ApplicationDbContext context) : base(context)
    { }
    
    public async Task<Movie> GetMovieCategoryAsync(int? id)
    {
        return await _context
            .Movies
            .Include(m => m.Category)
            .SingleOrDefaultAsync(m => m.Id == id);
    }
}