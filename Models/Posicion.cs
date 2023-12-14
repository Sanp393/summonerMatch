using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class Posicion
    {
        [Key]
        public int IdPosicion { get; set; }
        public string? NombrePosicion { get; set; }
    }
}
