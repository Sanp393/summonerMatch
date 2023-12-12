using System.ComponentModel.DataAnnotations;

namespace SummonerMatch.Models
{
    public class Posicion
    {
        [Key]
        public int IdPosicion { get; set; }
        public string NombrePosicion { get; set; }
    }
}
