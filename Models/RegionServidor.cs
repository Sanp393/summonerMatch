using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class RegionServidor
    {
        [Key]
        public int IdRegionServidor { get; set; }
        public string? NombreRegion { get; set; }
    }
}
