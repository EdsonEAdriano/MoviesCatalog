using MoviesCatalog.Domain.Entities;

namespace MoviesCatalog.Domain.Interfaces;

public interface IMovieRepository : IBaseRepository<Movie>
{
    Task<Movie> GetMovieCategoryAsync(int? id);
}