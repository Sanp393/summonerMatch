using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class Partida
    {
        [Key]
        public int IdCardPartida { get; set; }
        public DateTime? HoraCreacion { get; set; }
        public DateTime? HoraExpiracion { get; set; }
        public int? FkIdCreador { get; set; }
        public int? FkTipoPartida { get; set; }
        public int? FKIdTorneo { get; set; }
    }
}
