using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SummonerMatch
{
    public class PartidaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartidaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult DetallesPartida(int Id)
        {
            var partidaBuscada = _context.Partida.FirstOrDefault(partida => partida.IdPartida == Id);
            return View(partidaBuscada);
        }

        public IActionResult UnirsePosicion(int idPartida, string posicion, string usuarioLoL)
        {
            var partidaBuscada = _context.Partida.FirstOrDefault(partida => partida.IdPartida == idPartida);

            switch (posicion)
            {
                case "top":
                    partidaBuscada.JugadorTop = usuarioLoL;
                    partidaBuscada.NumJugadores++;
                    break;
                case "jungle":
                    partidaBuscada.JugadorJungle = usuarioLoL;
                    partidaBuscada.NumJugadores++;
                    break;
                case "mid":
                    partidaBuscada.JugadorMid = usuarioLoL;
                    partidaBuscada.NumJugadores++;
                    break;
                case "support":
                    partidaBuscada.JugadorSupport = usuarioLoL;
                    partidaBuscada.NumJugadores++;
                    break;
                case "adc":
                    partidaBuscada.JugadorAdc = usuarioLoL;
                    partidaBuscada.NumJugadores++;
                    break;
            }

            _context.SaveChanges();

            return RedirectToAction("DetallesPartida", "Partida", new { Id = idPartida });
        }

        [HttpPost]
        public IActionResult CrearPartida(string title, int tipoPartida, int rango)
        {
            var partidaExistente = _context.Partida.FirstOrDefault(p => p.Titulo == title);
            if (partidaExistente != null)
            {
                ModelState.AddModelError(string.Empty, "Ya existe una partida con este t�tulo");
                return RedirectToAction("Index", "Home");
            }

            var usuario = HttpContext.Session.GetObject<Usuario>("Usuario");
            Partida nuevaPartida = new Partida
            {
                Titulo = title,
                FechaCreacion = DateTime.Now,
                FechaExpiracion = DateTime.Now.AddDays(7),
                // FechaExpiracion = DateTime.Now.AddMinutes(20),
                FkTipoPartida = tipoPartida,
                FkUsuarioCreador = usuario.IdUsuario,
                FkRango = rango
            };

            _context.Partida.Add(nuevaPartida);
            _context.SaveChanges();

            return RedirectToAction("DetallesPartida", "Partida", new { id = nuevaPartida.IdPartida });
        }

        [HttpPost]
        public IActionResult AbandonarPartida(int idPartida)
        {
            var partidaAbandonada = _context.Partida.FirstOrDefault(partida => partida.IdPartida == idPartida);
            var UsuarioLol = HttpContext.Session.GetObject<Usuario>("Usuario");

            partidaAbandonada.JugadorTop = (partidaAbandonada.JugadorTop == UsuarioLol.UsuarioLoL) ? null : partidaAbandonada.JugadorTop;
            partidaAbandonada.JugadorMid = (partidaAbandonada.JugadorMid == UsuarioLol.UsuarioLoL) ? null : partidaAbandonada.JugadorMid;
            partidaAbandonada.JugadorSupport = (partidaAbandonada.JugadorSupport == UsuarioLol.UsuarioLoL) ? null : partidaAbandonada.JugadorSupport;
            partidaAbandonada.JugadorJungle = (partidaAbandonada.JugadorJungle == UsuarioLol.UsuarioLoL) ? null : partidaAbandonada.JugadorJungle;
            partidaAbandonada.JugadorAdc = (partidaAbandonada.JugadorAdc == UsuarioLol.UsuarioLoL) ? null : partidaAbandonada.JugadorAdc;

            partidaAbandonada.NumJugadores--;

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

        public IActionResult EliminarPartida(int idPartida)
        {
            var partidaEliminada = _context.Partida.FirstOrDefault(partida => partida.IdPartida == idPartida);
            _context.Partida.Remove(partidaEliminada);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult EliminarPartidaPerfil(int idPartida)
        {
            var partidaEliminada = _context.Partida.FirstOrDefault(partida => partida.IdPartida == idPartida);
            _context.Partida.Remove(partidaEliminada);
            _context.SaveChanges();

            return RedirectToAction("Profile", "Account");
        }
    }
}