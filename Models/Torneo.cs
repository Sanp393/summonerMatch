using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class Torneo
    {
        [Key]
        public int IdTorneo { get; set; }
        public string? Titulo { get; set; }
        public int? CantidadEquipos { get; set; }
    }
}
