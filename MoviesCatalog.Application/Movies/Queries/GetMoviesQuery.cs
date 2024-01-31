using MediatR;
using MoviesCatalog.Domain.Entities;

namespace MoviesCatalog.Application.Movies.Queries;

public class GetMoviesQuery : IRequest<IEnumerable<Movie>>
{
    
}