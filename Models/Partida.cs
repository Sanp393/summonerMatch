using System.ComponentModel.DataAnnotations;

namespace SummonerMatch.Models
{
    public class Partida
    {
        [Key]
        public int IdCardPArtida { get; set; }
        public DateTime HoraCreacion { get; set; }
        public DateTime HoraExpiracion { get; set; }
        public int FkIdCreador { get; set; }
        public int FkTipoPartida { get; set; }
        public int? FKIdTorneo { get; set; }
    }
}
