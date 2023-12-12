using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SummonerMatch.Models;



namespace SummonerMatch;


public class ApplicationDbContext : IdentityDbContext<Usuario>
//public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    

    public DbSet<Equipo> Equipo { get; set; }
    public DbSet<ImagenPerfil> ImagenPerfil { get; set; }
    public DbSet<Partida> Partida { get; set; }
    public DbSet<Posicion> Posicion { get; set; }
    public DbSet<Rango> Rango { get; set; }
    public DbSet<RegionServidor> RegionServidor { get; set; }
    public DbSet<TipoPartida> TipoPartida { get; set; }
    public DbSet<Torneo> Torneo { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<Valoracion> Valoracion { get; set; }
}
