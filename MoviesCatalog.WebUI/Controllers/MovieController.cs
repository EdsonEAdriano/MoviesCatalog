using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Application.Interfaces;

namespace MoviesCatalog.WebUI.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var movies = await _movieService.GetAsync();
        return View(movies);
    }
}