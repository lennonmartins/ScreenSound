using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;

namespace ScreenSound.Banco;

public class ScreenSoundContext : DbContext
{
    private readonly string connectionString = "Host=localhost; Database=ScreenSoundV0; Username=postgres; Password=adm123";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(connectionString)
            .UseLazyLoadingProxies();
    }

    public DbSet<Artista> Artistas { get; set; }
    public DbSet<Musica> Musicas { get; set; }
}