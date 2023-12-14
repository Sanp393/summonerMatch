using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class Valoracion
    {
        [Key]
        public int IdValoracion { get; set; }
        public float? PuntuacionMedia { get; set; }
        public int? CantidadValoraciones { get; set; }
    }
}
