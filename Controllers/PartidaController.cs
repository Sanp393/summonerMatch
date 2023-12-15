using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult CrearPartida(string title, int tipoPartida)
        {
            var partidaExistente = _context.Partida.FirstOrDefault(p => p.Titulo == title);
            if (partidaExistente != null)
            {
                ModelState.AddModelError(string.Empty, "Ya existe una partida con este título");
                return RedirectToAction("Index", "Home");
            }

            var usuario = HttpContext.Session.GetObject<Usuario>("Usuario");
            Partida nuevaPartida = new Partida
            {
                Titulo = title,
                FechaCreacion = DateTime.Now,
                FechaExpiracion = DateTime.Now.AddMinutes(20),
                FkTipoPartida = tipoPartida,
                FkUsuarioCreador = usuario.IdUsuario,
            };

            _context.Partida.Add(nuevaPartida);
            _context.SaveChanges();

            return RedirectToAction("DetallesPartida", "Partida", new { id = nuevaPartida.IdPartida });
        }

    }
}