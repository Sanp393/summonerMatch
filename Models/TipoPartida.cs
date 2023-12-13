using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class TipoPartida
    {
        [Key]
        public int IdTipoPartida { get; set; }
        public string? NombreTipo { get; set; }
    }
}
