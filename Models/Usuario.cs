using System.ComponentModel.DataAnnotations;

namespace SummonerMatch
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }
        public bool? admin { get; set; }
        public string? nombreUsuario { get; set; }
        public string? userNickname { get; set; }
        public string? correoElectonico { get; set; }
        public string? password { get; set; }
        public int? fkRegionServidor { get; set; }
        public int? fkRango { get; set; }
        public int? fkPosicion { get; set; }
        public int? fkImagenPerfil { get; set; }
        public int? fkIdEquipo { get; set; }

        public string imagenPerfil { get; set; } 

        public bool usuarioAutenticado = false;
    }
}
