using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

[Route("account")]
public class AccountController : Controller
{
    [HttpGet("login")]
    public IActionResult Login() => View();

    [ValidateAntiForgeryToken]
    [HttpPost("login")]
    public IActionResult Login(LoginViewModel model)
    {
        return RedirectToAction("Top", "Movies");
    }

    [HttpGet("register")]
    public IActionResult Register() => View();

    [ValidateAntiForgeryToken]
    [HttpPost("register")]
    public IActionResult Register(RegisterViewModel model)
    {
        return RedirectToAction("Top", "Movies");
    }
}