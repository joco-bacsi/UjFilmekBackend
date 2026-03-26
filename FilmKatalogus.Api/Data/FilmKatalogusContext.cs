using FilmKatalogus.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace FilmKatalogus.Api.Data;

public class FilmKatalogusContext(DbContextOptions<FilmKatalogusContext> options) : DbContext(options)
{
    public DbSet<Entities.FilmekEntities> Filmek => Set<Entities.FilmekEntities>();
    public DbSet<Entities.SzineszekEntities> Szineszek => Set<Entities.SzineszekEntities>();
    public DbSet<Entities.FilmCastEntities> FilmCast => Set<Entities.FilmCastEntities>();
    public DbSet<Entities.MufajEntities> Mufajok => Set<Entities.MufajEntities>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MufajEntities>().HasData(
            new { Id = 1, Name = "Action" },
            new { Id = 2, Name = "Adventure" },
            new { Id = 3, Name = "Animated" },
            new { Id = 4, Name = "Comedy" },
            new { Id = 5, Name = "Drama" },
            new { Id = 6, Name = "Fantasy" },
            new { Id = 7, Name = "Historical" },
            new { Id = 8, Name = "Horror" },
            new { Id = 9, Name = "Melodrama" },
            new { Id = 10, Name = "Musical" },
            new { Id = 11, Name = "Noir" },
            new { Id = 12, Name = "Romance" },
            new { Id = 13, Name = "Science fiction" },
            new { Id = 14, Name = "Thriller" },
            new { Id = 15, Name = "Western" }
        );
    }
}
