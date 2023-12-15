using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Login(string nombreUsuario, string contrasena)
        {
            var usuario = _context.Usuario.FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena);

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
            ViewData["Regiones"] = _context.Region.ToList();
            ViewData["Posiciones"] = _context.Posicion.ToList();
            
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Register(string nombreUsuario, string usuarioLoL, string correoElectronico, string contrasena, int rango, int region, int posicion)
        {
            var usuarioExistente = _context.Usuario.FirstOrDefault(u => u.NombreUsuario == nombreUsuario);

            if (usuarioExistente != null)
            {
                ModelState.AddModelError(string.Empty, "El nombre de usuario ya está en uso");
                return RedirectToAction("Register");
            }

            Usuario nuevoUsuario = new Usuario{
                EsAdministrador = false,
                NombreUsuario = nombreUsuario,
                UsuarioLoL = usuarioLoL,
                CorreoElectronico = correoElectronico,
                Contrasena = contrasena,
                FkRegion = region,
                FkRango = rango,
                FkPosicion = posicion,
                ImagenPerfil = "~/assets/images/imgProfile/LogoLoL.jpg",
            };

            _context.Usuario.Add(nuevoUsuario);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            ViewData["Rangos"] = _context.Rango.ToList();
            ViewData["Regiones"] = _context.Region.ToList();
            ViewData["Posiciones"] = _context.Posicion.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult UpdateProfile(string nickname, int rango, int region, int posicion)
        {        
            var usuario = HttpContext.Session.GetObject<Usuario>("Usuario");
            
            usuario.UsuarioLoL = nickname;
            usuario.FkRango = rango;
            usuario.FkRegion = region;
            usuario.FkPosicion = posicion;
            
            _context.Update(usuario);
            _context.SaveChanges();

            HttpContext.Session.SetObject("Usuario", usuario);

            return RedirectToAction("Profile", "Account");
            //return View("Profile");
        }

        // Controlador
        [HttpPost]
        public IActionResult CambiarImagePerfil(string imgPerfil)
        {
            var usuario = HttpContext.Session.GetObject<Usuario>("Usuario");
            usuario.ImagenPerfil = imgPerfil;

            _context.Update(usuario);
            _context.SaveChanges();
            HttpContext.Session.SetObject("Usuario", usuario);

            return RedirectToAction("Profile", "Account");
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("Usuario");

            return RedirectToAction("LogIn", "Account");
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
