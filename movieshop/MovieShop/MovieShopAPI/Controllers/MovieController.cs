using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        [HttpGet]
        [Route("Top-grossing")]//attribute routing
        public async Task<IActionResult> Get30HighestGrossingMovies()
        {
            var movies = await _movieService.Get30HighestGrossingMovies();
            if (!movies.Any() )
            {
                return NotFound(new { errorMessage="No Movies Found"});
            }
            else
            {
                return Ok(movies);
            }

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovieDetails(int id)//方法里参数要和路由参数一致
        {
            var movie=await _movieService.GetMovieDetails(id);
            if (movie == null)
            {
                return NotFound(new { errorMessage = "No Movie Found for the id " + id });
            }
            else
            {
                return Ok(movie);
            }
        }


    }
}
