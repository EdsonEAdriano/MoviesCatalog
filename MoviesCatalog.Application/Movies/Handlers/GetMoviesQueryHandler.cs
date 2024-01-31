using MediatR;
using MoviesCatalog.Application.Movies.Queries;
using MoviesCatalog.Domain.Entities;
using MoviesCatalog.Domain.Interfaces;

namespace MoviesCatalog.Application.Movies.Handlers;

public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IEnumerable<Movie>>
{
    private readonly IMovieRepository _movieRepository;

    public GetMoviesQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    

    public async Task<IEnumerable<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        return await _movieRepository.GetAsync();
    }
}