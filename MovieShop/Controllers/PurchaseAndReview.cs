using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class PurchaseAndReviewController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Buy(int movieId, string title, decimal price)
        { 
            ViewBag.MovieId = movieId;
            ViewBag.Title = title;
            ViewBag.Price = price;

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int movieId, string title, decimal rating, string reviewText)
        {
            ViewBag.MovieId = movieId;
            ViewBag.Title = title;
            ViewBag.Rating = rating;
            ViewBag.ReviewText = reviewText;

            return View();
        }
    }
}
