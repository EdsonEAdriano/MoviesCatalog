using AutoMapper;
using MoviesCatalog.Application.DTOs;
using MoviesCatalog.Application.Interfaces;
using MoviesCatalog.Domain.Entities;
using MoviesCatalog.Domain.Interfaces;

namespace MoviesCatalog.Application.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public MovieService(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository ??
                            throw new ArgumentNullException(nameof(movieRepository));
        
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieDTO>> GetAsync()
    {
        var categories = await _movieRepository.GetAsync();

        return _mapper.Map<IEnumerable<MovieDTO>>(categories);
    }

    public async Task<MovieDTO> GetAsync(int? id)
    {
        var movie = await _movieRepository.GetAsync(id);
        
        return _mapper.Map<MovieDTO>(movie);
    }

    public async Task<MovieDTO> GetMovieCategoryAsync(int? id)
    {
        var movie = await _movieRepository.GetMovieCategoryAsync(id);
        
        return _mapper.Map<MovieDTO>(movie);
    }

    public async Task CreateAsync(MovieDTO movieDTO)
    {
        var movie = _mapper.Map<Movie>(movieDTO);

        await _movieRepository.CreateAsync(movie);
    }

    public async Task UpdateAsync(MovieDTO movieDTO)
    {
        var movie = _mapper.Map<Movie>(movieDTO);

        await _movieRepository.UpdateAsync(movie);
    }

    public async Task RemoveAsync(int? id)
    {
        var movie = _movieRepository.GetAsync(id).Result;

        await _movieRepository.RemoveAsync(movie);
    }
}