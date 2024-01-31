using MediatR;
using MoviesCatalog.Application.Movies.Commands;
using MoviesCatalog.Domain.Entities;
using MoviesCatalog.Domain.Interfaces;

namespace MoviesCatalog.Application.Movies.Handlers;

public class MovieRemoveCommandHandler : IRequestHandler<MovieRemoveCommand, Movie>
{
    private readonly IMovieRepository _movieRepository;

    public MovieRemoveCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository ??
                           throw new ArgumentNullException(nameof(movieRepository));
    }


    public async Task<Movie> Handle(MovieRemoveCommand request,
        CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetAsync(request.Id);

        if (movie == null)
        {
            throw new ApplicationException("Entity could not be found.");
        }
        else
        {
            return await _movieRepository.RemoveAsync(movie);
        }
    }
}