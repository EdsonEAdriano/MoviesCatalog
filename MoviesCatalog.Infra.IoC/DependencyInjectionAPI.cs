using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesCatalog.Application.Interfaces;
using MoviesCatalog.Application.Mappings;
using MoviesCatalog.Application.Services;
using MoviesCatalog.Domain.Account;
using MoviesCatalog.Domain.Interfaces;
using MoviesCatalog.Infra.Data.Context;
using MoviesCatalog.Infra.Data.Identity;
using MoviesCatalog.Infra.Data.Repositories;

namespace MoviesCatalog.Infra.IoC;

public static class DependencyInjectionAPI
{   
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                , b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IMovieRepository, MovieRepository>();

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IMovieService, MovieService>();
        
        services.AddScoped<IAuthenticate, AuthenticateService>();
        
        services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

        var myhandlers = AppDomain.CurrentDomain.Load("MoviesCatalog.Application");
        services.AddMediatR(myhandlers);
        
        
        return services;
    }
}