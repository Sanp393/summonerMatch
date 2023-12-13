using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class Valoracion
    {
        [Key]
        public int IdValoracion { get; set; }
        public float? Media { get; set; }
        public int? NumValoraciones { get; set; }
        public int? FkUsuario { get; set; }
    }
}
