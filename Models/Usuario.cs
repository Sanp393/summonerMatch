using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public bool? EsAdministrador { get; set; }
        public string? NombreUsuario { get; set; }
        public string? UsuarioLoL { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contrasena { get; set; }
        public string? ImagenPerfil { get; set; }
        public int? FkPosicion { get; set; }
        public int? FkRango { get; set; }
        public int? FkRegion { get; set; }
        public int? FkValoracion { get; set; }
    }
}
