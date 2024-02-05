using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Application.DTOs;
using MoviesCatalog.Application.Interfaces;

namespace MoviesCatalog.WebUI.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAsync();
        return View(categories);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CategoryDTO category)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _categoryService.CreateAsync(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return RedirectToAction(nameof(Index));
        }
        
        return View(category);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var category = await _categoryService.GetAsync(id);

        if (category == null)
            return NotFound();
        
        return View(category);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit(CategoryDTO category)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _categoryService.UpdateAsync(category);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(category);
    }
    
    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var category = await _categoryService.GetAsync(id);

        if (category == null)
            return NotFound();
        
        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        await _categoryService.RemoveAsync(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
            return NotFound();

        var category = await _categoryService.GetAsync(id);

        if (category == null)
            return NotFound();
        
        return View(category);
    }
}