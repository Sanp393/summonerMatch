using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class Partida
    {
        [Key]
        public int IdPartida { get; set; }
        public string? Titulo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaExpiracion { get; set; }
        public string? JugadorTop { get; set; }
        public string? JugadorJungle { get; set; }
        public string? JugadorMid { get; set; }
        public string? JugadorSupport { get; set; }
        public string? JugadorAdc { get; set; }
        public int? FkUsuarioCreador { get; set; }
        public int? FkTipoPartida { get; set; }
        public int? FkTorneo { get; set; }
        public int? FkRango { get; set; }
        public int NumJugadores { get; set; }
    }
}
