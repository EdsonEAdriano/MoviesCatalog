using MediatR;
using MoviesCatalog.Application.Movies.Commands;
using MoviesCatalog.Domain.Entities;
using MoviesCatalog.Domain.Interfaces;

namespace MoviesCatalog.Application.Movies.Handlers;

public class MovieUpdateCommandHandler : IRequestHandler<MovieUpdateCommand, Movie>
{
    private readonly IMovieRepository _movieRepository;

    public MovieUpdateCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository ??
                           throw new ArgumentNullException(nameof(movieRepository));
    }


    public async Task<Movie> Handle(MovieUpdateCommand request, 
        CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetAsync(request.Id);
        
        if (movie == null)
        {
            throw new ApplicationException("Entity could not be found.");
        }
        else
        {
            movie.Update(request.Id, request.Title, request.Description, request.ReleaseDate, request.ImagePath);
            movie.CategoryId = request.CategoryId;
            
            return await _movieRepository.UpdateAsync(movie);
        }
    }
}