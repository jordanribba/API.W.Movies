using API.W.Movies.Services;
using API.W.Movies.DAL.Dtos.Movie;
using Microsoft.AspNetCore.Mvc;

namespace API.W.Movies.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMoviesAsync()
        {
            var movies = await _movieService.GetMoviesAsync();
            return Ok(movies);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieDto>> GetMovieAsync(int id)
        {
            var movie = await _movieService.GetMovieAsync(id);
            if (movie == null)
                return NotFound("Movie not found.");
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDto>> CreateMovieAsync(MovieCreateDto dto)
        {
            try
            {
                var movie = await _movieService.CreateMovieAsync(dto);
                return CreatedAtAction(nameof(GetMovieAsync), new { id = movie.Id }, movie);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<MovieDto>> UpdateMovieAsync(int id, MovieCreateDto dto)
        {
            try
            {
                var movie = await _movieService.UpdateMovieAsync(id, dto);
                return Ok(movie);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMovieAsync(int id)
        {
            var deleted = await _movieService.DeleteMovieAsync(id);
            if (!deleted)
                return NotFound("Movie not found.");
            return NoContent();
        }
    }
}
