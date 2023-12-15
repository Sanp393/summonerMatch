using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class Region
    {
        [Key]
        public int IdRegion { get; set; }
        public string? NombreRegion { get; set; }
    }
}
