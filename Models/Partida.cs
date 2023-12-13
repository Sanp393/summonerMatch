using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class Partida
    {
        [Key]
        public int IdCardPartida { get; set; }
        public string? tituloPartida { get; set; }
        public DateTime? HoraCreacion { get; set; }
        public DateTime? HoraExpiracion { get; set; }
        public string? posicionTop { get; set; }
        public string? posicionJungle { get; set; }
        public string? posicionMid { get; set; }
        public string? posicionSupport { get; set; }
        public string? posicionAdc { get; set; }
        public int? FkIdCreador { get; set; }
        public int? FkTipoPartida { get; set; }
        public int? FKIdTorneo { get; set; }
    }
}
