using MediatR;
using MoviesCatalog.Domain.Entities;

namespace MoviesCatalog.Application.Movies.Queries;

public class GetMovieByIdQuery : IRequest<Movie>
{
    public int Id { get; set; }

    public GetMovieByIdQuery(int id)
    {
        Id = id;
    }
}