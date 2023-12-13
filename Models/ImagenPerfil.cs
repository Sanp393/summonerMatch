using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class ImagenPerfil
    {
        [Key]
        public int IdImagenPerfil { get; set; }
        public byte[]? ArchivoImagen { get; set; }
    }
}
