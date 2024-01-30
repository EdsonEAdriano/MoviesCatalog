using AutoMapper;
using MoviesCatalog.Application.DTOs;
using MoviesCatalog.Domain.Entities;

namespace MoviesCatalog.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<Category, CategoryDTO>().ReverseMap();
        CreateMap<Movie, MovieDTO>().ReverseMap();
    }
}
