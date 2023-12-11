using System.ComponentModel.DataAnnotations;

namespace SummonerMatch.Models
{
    public class ImagenPerfil
    {
        [Key]
        public int IdImagenPerfil { get; set; }
        public byte[] ArchivoImagen { get; set; }
    }
}
