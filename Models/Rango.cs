using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class Rango
    {
        [Key]
        public int IdRango { get; set; }
        public string? NombreRango { get; set; }
    }
}
