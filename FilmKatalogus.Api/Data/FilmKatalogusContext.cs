using Microsoft.EntityFrameworkCore;

namespace FilmKatalogus.Api.Data;

public class FilmKatalogusContext(DbContextOptions<FilmKatalogusContext> options) : DbContext(options)
{
    public DbSet<Models.Film> Filmek => Set<Models.Film>();
    public DbSet<Models.Mufaj> Mufajok => Set<Models.Mufaj>();
}
