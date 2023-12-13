using Microsoft.AspNetCore.Mvc;

namespace SummonerMatch
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string nombreUsuario, string password)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.nombreUsuario == nombreUsuario && u.password == password);

            if (usuario != null)
            {
                bool usuarioAutenticado = true;
                // ViewBag.UsuarioAutenticado = usuarioAutenticado;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Credenciales inválidas");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Profile()
        {
            ViewData["Rangos"] = _context.Rango.ToList();
            ViewData["Regiones"] = _context.RegionServidor.ToList();
            ViewData["Posiciones"] = _context.Posicion.ToList();
            return View();
        }
    }
}
