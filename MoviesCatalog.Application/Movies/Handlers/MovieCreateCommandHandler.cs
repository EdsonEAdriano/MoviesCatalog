using MediatR;
using MoviesCatalog.Application.Movies.Commands;
using MoviesCatalog.Domain.Entities;
using MoviesCatalog.Domain.Interfaces;

namespace MoviesCatalog.Application.Movies.Handlers;

public class MovieCreateCommandHandler : IRequestHandler<MovieCreateCommand, Movie>
{
    private readonly IMovieRepository _movieRepository;

    public MovieCreateCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }


    public async Task<Movie> Handle(MovieCreateCommand request, 
        CancellationToken cancellationToken)
    {
        var movie = new Movie(request.Title, request.Description, request.ReleaseDate, request.ImagePath);

        if (movie == null)
        {
            throw new ApplicationException("Error creating entity.");
        }
        else
        {
            movie.CategoryId = request.CategoryId;
            return await _movieRepository.CreateAsync(movie);
        }
    }
}