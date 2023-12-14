using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class Equipo
    {
        [Key]
        public int IdEquipo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public string? JugadorTop { get; set; }
        public string? JugadorJungle { get; set; }
        public string? JugadorMid { get; set; }
        public string? JugadorSupport { get; set; }
        public string? JugadorAdc { get; set; }
        public string? FkPartida { get; set; }
    }
}
