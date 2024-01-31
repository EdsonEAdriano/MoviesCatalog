using AutoMapper;
using MediatR;
using MoviesCatalog.Application.DTOs;
using MoviesCatalog.Application.Interfaces;
using MoviesCatalog.Application.Movies.Commands;
using MoviesCatalog.Application.Movies.Queries;
using MoviesCatalog.Domain.Entities;
using MoviesCatalog.Domain.Interfaces;

namespace MoviesCatalog.Application.Services;

public class MovieService : IMovieService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public MovieService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MovieDTO>> GetAsync()
    {
        var query = new GetMoviesQuery();

        if (query == null)
            throw new Exception("Entity could not be loaded.");
        
        var result = await _mediator.Send(query);
        
        return _mapper.Map<IEnumerable<MovieDTO>>(result);
    }

    public async Task<MovieDTO> GetAsync(int? id)
    {
        var query = new GetMovieByIdQuery(id.Value);
        
        if (query == null)
            throw new Exception("Entity could not be loaded.");

        var result = await _mediator.Send(query);

        return _mapper.Map<MovieDTO>(result);
    }
    
    public async Task CreateAsync(MovieDTO movieDTO)
    {
        var query = _mapper.Map<MovieCreateCommand>(movieDTO);
        await _mediator.Send(query);
    }
    
    public async Task UpdateAsync(MovieDTO movieDTO)
    {
        var query = _mapper.Map<MovieUpdateCommand>(movieDTO);
        await _mediator.Send(query);
    }
    
    public async Task RemoveAsync(int? id)
    {
        var query = new MovieRemoveCommand(id.Value);
        await _mediator.Send(query);
    }
}