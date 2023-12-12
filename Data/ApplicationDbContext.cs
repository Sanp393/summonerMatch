using Microsoft.EntityFrameworkCore;
using SummonerMatch.Models;



namespace SummonerMatch;


public class ApplicationDbContext : IdentityDbContext<Usuario>
//public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    

    public DbSet<Equipo> Equipos { get; set; }
    public DbSet<ImagenPerfil> ImagenPerfiles { get; set; }
    public DbSet<Partida> Partidas { get; set; }
    public DbSet<Posicion> Posiciones { get; set; }
    public DbSet<Rango> Rangos { get; set; }
    public DbSet<RegionServidor> RegionServidores { get; set; }
    public DbSet<TipoPartida> TipoPartidas { get; set; }
    public DbSet<Torneo> Torneos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Valoracion> Valoraciones { get; set; }
}
