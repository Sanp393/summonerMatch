using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SummonerMatch.Models
{
    public class Usuario : IdentityUser
    {
        [Key]
        public int idUsuario { get; set; }
        public bool admin { get; set; }
        public string userName { get; set; }
        public string userNickname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int? fkRegionServidor { get; set; }
        public int? fkRango { get; set; }
        public int? fkPosicion { get; set; }
        public int fkImagenPerfil { get; set; }
        public int? fkIdEquipo { get; set; }
    }
}
