using MoviesCatalog.Application.DTOs;

namespace MoviesCatalog.Application.Interfaces;

public interface IMovieService
{
    Task<IEnumerable<MovieDTO>> GetAsync();
    Task<MovieDTO> GetAsync(int? id);
    
    Task CreateAsync(MovieDTO movieDTO);
    Task UpdateAsync(MovieDTO movieDTO);
    Task RemoveAsync(int? id);
}