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
            var usuario = new Usuario();
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Login(string nombreUsuario, string password)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.nombreUsuario == nombreUsuario && u.password == password);

            if (usuario != null)
            {
                bool usuarioAutenticado = true;
                ViewBag.UsuarioAutenticado = usuarioAutenticado;

                return View("./../Home/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Credenciales inválidas");
                return View();
            }
        }
    }
}
