using SummonerMatch.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SummonerMatch.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<Usuario> _signInManager;

        public AccountController(SignInManager<Usuario> signInManager)
        {
            _signInManager = signInManager;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Usuario model)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
                catch (Exception ex)
                {
                    // Loguear o imprimir la excepción para obtener más información.
                    Console.WriteLine($"Excepción durante el inicio de sesión: {ex.ToString()}");
                    ModelState.AddModelError(string.Empty, "Error durante el inicio de sesión.");
                    return View(model);
                }

            }
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
