using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SummonerMatch.Models
{
    public class Usuario : IdentityUser
    {
        [Key]
        public int IdUsuario { get; set; }
        public bool Admin { get; set; }
        public string UserName { get; set; }
        public string UserNickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? FkRegionServidor { get; set; }
        public int? FkRango { get; set; }
        public int? FkPosicion { get; set; }
        public int FkImagenPerfil { get; set; }
        public int? FkIdEquipo { get; set; }
    }
}
