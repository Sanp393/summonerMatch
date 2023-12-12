using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SummonerMatch.Models;

namespace SummonerMatch._Controllers
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
            /*
            List<Partida> Partidas = _context.Partidas.ToList();
            return View(Partidas);
            */
            return View();
        }
        
    }
}