using System.Diagnostics;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;


        public MoviesController(ILogger<MoviesController> logger, IMovieService movieService, IGenreService genreService)
        {
            _logger = logger;
            _movieService = movieService;
            _genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {
            List<MovieCardModel> movies = await _movieService.GetAllMovies();

            return View(movies);
        }


        public async Task<IActionResult> Top()
        {
            List<MovieCardModel> movies = await _movieService.Top30Movies();

            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> MovieDetails(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);

            return View(movie);
        } 


        [HttpPost]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = _movieService.GetMovieDetails(id);

            if(movie == null)
            {
                return NotFound();
            }

            _movieService.DeleteMovie(id);
            return RedirectToAction("Index", "Movies");
        }

        [HttpGet("genre/{id}")]
        public  async Task<IActionResult> ByGenre(int id, int page = 1, int pageSize = 100)
        {
            var movies = await _genreService.GetMovies(id, page, pageSize);
            return View(movies);
        }

        public async Task<IActionResult> Search(string q, int page = 1, int pageSize = 30)
        {
            q = (q ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(q))
                return RedirectToAction(nameof(Top));

            List<MovieCardModel> movies = await _movieService.SearchMovies(q, page, pageSize);
            ViewBag.Query = q;
            return View("Index",movies);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
