using System.ComponentModel.DataAnnotations;

namespace SummonerMatch.Models
{
    public class TipoPartida
    {
        [Key]
        public int IdTipoPartida { get; set; }
        public string NombreTipo { get; set; }
    }
}
