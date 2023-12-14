using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
                HttpContext.Session.SetObject("Usuario", usuario);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Credenciales inválidas");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {

            ViewData["Rangos"] = _context.Rango.ToList();
            ViewData["Regiones"] = _context.RegionServidor.ToList();
            ViewData["Posiciones"] = _context.Posicion.ToList();

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string nomUsr, string nickNm, string eM, string pass, int ran, int reg, int pos)
        {
            var usuarioExistente = _context.Usuario.FirstOrDefault(u => u.nombreUsuario == nomUsr);

            if (usuarioExistente != null)
            {
                ModelState.AddModelError(string.Empty, "El nombre de usuario ya está en uso");
                return RedirectToAction("Register");
            }

            Usuario nuevoUsuario = new Usuario {
                admin = false,
                nombreUsuario = nomUsr,
                userNickname = nickNm,
                correoElectonico = eM,
                password = pass,
                fkRegionServidor = reg,
                fkRango = ran,
                fkPosicion = pos,
                imagenPerfil = "LogoLoL",

            };

            _context.Usuario.Add(nuevoUsuario);
            _context.SaveChanges();

            return RedirectToAction("Login");
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

    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            var json = JsonSerializer.Serialize(value);
            session.SetString(key, json);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var json = session.GetString(key);
            return json == null ? default : JsonSerializer.Deserialize<T>(json);
        }
    }
}
