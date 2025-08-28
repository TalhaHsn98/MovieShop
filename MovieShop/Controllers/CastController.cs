using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;

        public CastController(ICastService cast)
        {
            _castService = cast;
        }
        public async Task<IActionResult> Details(int id)
        {

            var castdetails = await _castService.GetCastDetails(id);
            if(castdetails == null) return NotFound();
            return View(castdetails);
        }
    }
}
