using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesCatalog.Application.DTOs;
using MoviesCatalog.Application.Interfaces;

namespace MoviesCatalog.WebUI.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieService _movieService;
    private readonly ICategoryService _categoryService;
    private readonly IWebHostEnvironment _environment;

    public MoviesController(IMovieService movieService, ICategoryService categoryService, IWebHostEnvironment environment)
    {
        _movieService = movieService;
        _categoryService = categoryService;
        _environment = environment;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var movies = await _movieService.GetAsync();
        return View(movies);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        ViewBag.CategoryId =
            new SelectList(await _categoryService.GetAsync(), "Id", "Name");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(MovieDTO movie)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _movieService.CreateAsync(movie);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(movie);
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var movie = await _movieService.GetAsync(id);

        if (movie == null)
            return NotFound();
        
        ViewBag.CategoryId =
            new SelectList(await _categoryService.GetAsync(), "Id", "Name", movie.CategoryId);
        
        return View(movie);
    }
    
    
    [HttpPost]
    public async Task<IActionResult> Edit(MovieDTO movie)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _movieService.UpdateAsync(movie);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(movie);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var movie = await _movieService.GetAsync(id);

        if (movie == null)
            return NotFound();
        
        return View(movie);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        await _movieService.RemoveAsync(id);
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var movie = await _movieService.GetAsync(id);

        if (movie == null)
            return NotFound();


        var wwwroot = _environment.WebRootPath;
        var image = Path.Combine(wwwroot, "images\\" + movie.ImagePath);
        var exists = System.IO.File.Exists(image);
        ViewBag.ImageExist = exists;
        
        return View(movie);
    }
}