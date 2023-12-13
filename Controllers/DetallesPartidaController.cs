using Microsoft.AspNetCore.Mvc;

namespace SummonerMatch
{
    public class DetallesPartida : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetallesPartida(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(int Id)
        {
            var partidaBuscada = _context.Partida.FirstOrDefault(partida => partida.IdCardPartida == Id);
            return View(partidaBuscada);
        }
        
    }
}