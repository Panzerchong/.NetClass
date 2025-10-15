using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }


        //http://movieshop.com/movies/details/1
        //public IActionResult Details(int id)
        public async Task<IActionResult> Details(int id)//Task<int>; void->Task
        {
            //等待数据库返回结果
            var movieDetails = await _movieService.GetMovieDetails(id);
            return View(movieDetails);
        }

    }
}
