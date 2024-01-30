using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesCatalog.Application.Interfaces;
using MoviesCatalog.Application.Mappings;
using MoviesCatalog.Application.Services;
using MoviesCatalog.Domain.Interfaces;
using MoviesCatalog.Infra.Data.Context;
using MoviesCatalog.Infra.Data.Repositories;

namespace MoviesCatalog.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IMovieService, MovieService>();

        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
        
        return services;
    }
}