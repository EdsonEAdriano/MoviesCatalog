using System.Collections;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Application.DTOs;
using MoviesCatalog.Application.Interfaces;
using MoviesCatalog.Domain.Entities;

namespace MoviesCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetAsync();

            if (categories == null || !categories.Any())
                return NotFound("Categories not found");

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetAsync(id);

            if (category == null)
                return NotFound("Category not found.");

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Add([FromBody] CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateAsync(categoryDTO);

                return new CreatedAtRouteResult("GetCategory",
                    new { id = categoryDTO.Id },
                    categoryDTO);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(errors);
            }
        }


        [HttpPut]
        public async Task<ActionResult<CategoryDTO>> Update([FromBody] CategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryService.GetAsync(categoryDTO.Id);

                if (category == null)
                    return NotFound("Category not found.");

                await _categoryService.UpdateAsync(categoryDTO);

                return new CreatedAtRouteResult("GetCategory",
                    new { id = categoryDTO.Id },
                    categoryDTO);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(errors);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<CategoryDTO>> Remove(int id)
        {
            var category = await _categoryService.GetAsync(id);

            if (category == null)
                return NotFound("Category not found.");

            await _categoryService.RemoveAsync(id);

            return Ok(category);
        }
    }
}