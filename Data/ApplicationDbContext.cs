using Microsoft.EntityFrameworkCore;

namespace SummonerMatch;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    // Partida
    public DbSet<Partida>? Partida { get; set; }
    public DbSet<TipoPartida>? TipoPartida { get; set; }
    public DbSet<Equipo>? Equipo { get; set; }
    public DbSet<Torneo>? Torneo { get; set; }

    // Usuario
    public DbSet<Usuario>? Usuario { get; set; }
    public DbSet<Posicion>? Posicion { get; set; }
    public DbSet<Rango>? Rango { get; set; }
    public DbSet<Region>? Region { get; set; }
    public DbSet<Valoracion>? Valoracion { get; set; }
}
