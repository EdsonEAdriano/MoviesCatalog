using MediatR;
using MoviesCatalog.Application.Movies.Queries;
using MoviesCatalog.Domain.Entities;
using MoviesCatalog.Domain.Interfaces;

namespace MoviesCatalog.Application.Movies.Handlers;

public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie>
{
    private readonly IMovieRepository _movieRepository;

    public GetMovieByIdQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    

    public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        return await _movieRepository.GetAsync(request.Id);
    }
}