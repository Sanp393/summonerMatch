using System.ComponentModel.DataAnnotations;

namespace SummonerMatch.Models
{
    public class RegionServidor
    {
        [Key]
        public int IdRegionServidor { get; set; }
        public string NombreRegion { get; set; }
    }
}
