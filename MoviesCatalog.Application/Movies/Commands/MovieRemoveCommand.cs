using MediatR;
using MoviesCatalog.Domain.Entities;

namespace MoviesCatalog.Application.Movies.Commands;

public class MovieRemoveCommand : IRequest<Movie>
{
    public int Id { get; set; }

    public MovieRemoveCommand(int id)
    {
        Id = id;
    }
}