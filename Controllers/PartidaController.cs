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
        
    }
}