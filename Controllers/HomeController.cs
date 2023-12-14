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
            List<Partida> partidas = _context.Partida.Take(10).OrderByDescending(partida => partida.IdCardPartida).ToList();
            return View(partidas);
        }
        
    }
}