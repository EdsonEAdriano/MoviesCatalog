using MediatR;
using MoviesCatalog.Domain.Entities;

namespace MoviesCatalog.Application.Movies.Commands;

public abstract class MovieCommand : IRequest<Movie>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string? ImagePath { get; set; }
    
    public int CategoryId { get; set; }
}