using AutoMapper;
using MoviesCatalog.Application.DTOs;
using MoviesCatalog.Application.Movies.Commands;

namespace MoviesCatalog.Application.Mappings;

public class DTOToCommandMappingProfile : Profile
{
    public DTOToCommandMappingProfile()
    {
        CreateMap<MovieDTO, MovieCreateCommand>();
        CreateMap<MovieDTO, MovieUpdateCommand>();
    }
}