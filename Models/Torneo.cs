using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class Torneo
    {
        [Key]
        public int IdTorneo { get; set; }
        public string? NombreTorneo { get; set; }
        public string? DescripcionTorneo { get; set; }
        public int? CantEquipos { get; set; }
        public int? FkIdCreador { get; set; }
    }
}
