using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.Application.DTOs;
using MoviesCatalog.Application.Interfaces;

namespace MoviesCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> Get()
        {
            var movies = await _movieService.GetAsync();

            if (movies == null || !movies.Any())
                return NotFound("Movies not found");

            return Ok(movies);
        }

        [HttpGet("{id:int}", Name = "GetMovie")]
        public async Task<ActionResult<MovieDTO>> Get(int id)
        {
            var movie = await _movieService.GetAsync(id);

            if (movie == null)
                return NotFound("Movie not found.");

            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDTO>> Add([FromBody] MovieDTO movieDTO)
        {
            if (ModelState.IsValid)
            {
                await _movieService.CreateAsync(movieDTO);

                return new CreatedAtRouteResult("GetMovie",
                    new { id = movieDTO.Id },
                    movieDTO);
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
        public async Task<ActionResult<MovieDTO>> Update([FromBody] MovieDTO movieDTO)
        {
            if (ModelState.IsValid)
            {
                var category = await _movieService.GetAsync(movieDTO.Id);

                if (category == null)
                    return NotFound("Movie not found.");

                await _movieService.UpdateAsync(movieDTO);

                return new CreatedAtRouteResult("GetMovie",
                    new { id = movieDTO.Id },
                    movieDTO);
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
        public async Task<ActionResult<MovieDTO>> Remove(int id)
        {
            var category = await _movieService.GetAsync(id);

            if (category == null)
                return NotFound("Movie not found.");

            await _movieService.RemoveAsync(id);

            return Ok(category);
        }
    }
}
