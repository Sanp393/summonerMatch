using Microsoft.AspNetCore.Mvc;

namespace SummonerMatch
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["TiposPartida"] = _context.TipoPartida.ToList();
            ViewData["Rangos"] = _context.Rango.ToList();
            List<Partida> partidas = _context.Partida.Take(10).OrderByDescending(partida => partida.IdPartida).ToList();
            return View(partidas);
        }

        public IActionResult OrdenarPartidas(string filtroOrden, string filtroRango, string filtroTipoPartida)
        {
            List<Partida> partidas = _context.Partida.ToList();

            if(string.IsNullOrEmpty(filtroOrden) && string.IsNullOrEmpty(filtroRango) && string.IsNullOrEmpty(filtroTipoPartida))
            {
                return RedirectToAction("Index");
            }

            if (!string.IsNullOrEmpty(filtroOrden))
            {
                switch (filtroOrden)
                {
                    case "relevancia":
                        break;
                    case "menosJugadores":
                        partidas = _context.Partida.OrderBy(p => p.NumJugadores).ToList();
                        break;
                    case "masJugadores":
                        partidas = _context.Partida.OrderByDescending(p => p.NumJugadores).ToList();
                        break;
                    case "fecha":
                        partidas = _context.Partida.OrderByDescending(p => p.FechaExpiracion).ToList();
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filtroRango))
            {
                switch(filtroRango)
                {
                    case "iron":
                        partidas = partidas.Where(p => p.FkRango == 1).ToList();
                        break;
                    case "bronze":
                        partidas = partidas.Where(p => p.FkRango == 2).ToList();
                        break;
                    case "silver":
                        partidas = partidas.Where(p => p.FkRango == 3).ToList();
                        break;
                    case "gold":
                        partidas = partidas.Where(p => p.FkRango == 4).ToList();
                        break;
                    case "platinum":
                        partidas = partidas.Where(p => p.FkRango == 5).ToList();
                        break;
                    case "emerald":
                        partidas = partidas.Where(p => p.FkRango == 6).ToList();
                        break;
                    case "diamond":
                        partidas = partidas.Where(p => p.FkRango == 7).ToList();
                        break;
                    case "master":
                        partidas = partidas.Where(p => p.FkRango == 8).ToList();
                        break;
                    case "grandMaster":
                        partidas = partidas.Where(p => p.FkRango == 9).ToList();
                        break;
                    case "challenger":
                        partidas = partidas.Where(p => p.FkRango == 10).ToList();
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filtroTipoPartida))
            {
                switch (filtroTipoPartida)
                {
                    case "casual":
                        partidas = partidas.Where(p => p.FkTipoPartida == 1).ToList();
                        break;
                    case "ranked":
                        partidas = partidas.Where(p => p.FkTipoPartida == 2).ToList();
                        break;
                    case "aram":
                        partidas = partidas.Where(p => p.FkTipoPartida == 3).ToList();
                        break;
                }
            }

            ViewData["TiposPartida"] = _context.TipoPartida.ToList();
            ViewData["Rangos"] = _context.Rango.ToList();
            return View("Index", partidas);
        }
    }
}