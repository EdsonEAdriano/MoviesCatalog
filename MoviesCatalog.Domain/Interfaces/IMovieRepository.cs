using MoviesCatalog.Domain.Entities;

namespace MoviesCatalog.Domain.Interfaces;

public interface IMovieRepository : IBaseRepository<Movie>
{
    Task<Movie> GetAsync(Category category);
}