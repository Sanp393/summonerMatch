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
            List<Partida> partidas = _context.Partida.Take(10).OrderByDescending(partida => partida.IdPartida).ToList();
            return View(partidas);
        }
        
    }
}