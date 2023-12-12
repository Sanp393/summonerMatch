using System.ComponentModel.DataAnnotations;

namespace SummonerMatch.Models
{
    public class Equipo
    {
        [Key]
        public int IdEquipo { get; set; }
        public bool PosicionTop { get; set; }
        public bool PosicionMid { get; set; }
        public bool PosicionJungla { get; set; }
        public bool PosicionSupport { get; set; }
        public bool PosicionAdc { get; set; }
        public int? FkRangoEquipo { get; set; }
        public int IdPartida { get; set; }
    }
}
