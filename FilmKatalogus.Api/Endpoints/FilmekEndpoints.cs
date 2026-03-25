using System;
using FilmKatalogus.Api.Data;
using FilmKatalogus.Api.Dtos;
using Microsoft.EntityFrameworkCore;
using FilmKatalogus.Api.Entities;
using FilmKatalogus.Api.Mapping;

namespace FilmKatalogus.Api.Endpoints;

public static class FilmekEndpoints
{
    const string GetFilmById = "GetFilmById";
const string GetSzineszById = "GetSzineszById";
const string GetFilmCastById = "GetFilmCastById";
    /*private static readonly List<FilmekDto> filmek = new List<FilmekDto>
    {
        new FilmekDto(1, "Christopher Nolan", "Inception", "Sci-Fi", new TimeOnly(2, 28), "English", new DateOnly(2010, 7, 16), 8.8, 9.0),
        new FilmekDto(2, "Quentin Tarantino", "Pulp Fiction", "Crime", new TimeOnly(2, 34), "English", new DateOnly(1994, 10, 14), 8.9, 9.5),
        new FilmekDto(3, "Steven Spielberg", "Jurassic Park", "Adventure", new TimeOnly(2, 7), "English", new DateOnly(1993, 6, 11), 8.1, 8.5)
    };*/
    
        private static readonly List<SzineszekDto> szineszek = new List<SzineszekDto>
    {
        new SzineszekDto(1, "Leonardo DiCaprio"),
        new SzineszekDto(2, "Samuel L. Jackson"),
        new SzineszekDto(3, "Jeff Goldblum")
    };

    private static readonly List<FilmCastDto> cast = new List<FilmCastDto>
    {
        new FilmCastDto(1, "Inception"), // Leonardo DiCaprio in Inception
        new FilmCastDto(2, "Pulp Fiction"), // Samuel L. Jackson in Pulp Fiction
        new FilmCastDto(3, "Jurassic Park")  // Jeff Goldblum in Jurassic Park
    };

    public static void MapFilmekEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("filmek")
                       .WithParameterValidation();

        // GET /games
        group.MapGet("/", async (FilmKatalogusContext dbContext) => 
        await dbContext.Filmek.Include(f => f.Mufaj).ToListAsync());

//GetById
group.MapGet("/{id}", async (int id, FilmKatalogusContext dbContext) =>
        {
            FilmekEntities? film = await dbContext.Filmek.FindAsync(id);

            return film is null ? 
                Results.NotFound() : Results.Ok(film);
        })
        .WithName(GetFilmById);
//Post
group.MapPost("/", async (FilmCreateDto ujFilm, FilmKatalogusContext dbContext) =>
        {
            FilmekEntities film = new FilmekEntities
            {
                Rendezo = ujFilm.Rendezo,
                Cim = ujFilm.Cim,
                MufajId = ujFilm.MufajId,
                Hossz = ujFilm.Hossz,
                Nyelv = ujFilm.Nyelv,
                MegjelenesiDatum = ujFilm.MegjelenesiDatum,
                ImDbErtekeles = ujFilm.ImDbErtekeles,
                SajatErtekeles = ujFilm.SajatErtekeles
            };

            dbContext.Filmek.Add(film);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetFilmById, 
                new { id = film.Id }, 
                film);
        });
//Put
group.MapPut("/{id}", async (int id, UpdateFilmDto updatedFilm, FilmKatalogusContext dbContext) =>
        {
            var existingFilm = await dbContext.Filmek.FindAsync(id);

            if (existingFilm is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingFilm).CurrentValues.SetValues(updatedFilm.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });
//delete
group.MapDelete("/{id}", async (int id, FilmKatalogusContext dbContext) =>
        {
            await dbContext.Filmek
                     .Where(film => film.Id == id)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });

//GET all szinesz
app.MapGet("/szineszek", () => szineszek);

//GET szinesz by id
app.MapGet("/szineszek/{id}", (int id) =>
{
    var szinesz = szineszek.FirstOrDefault(s => s.Id == id);
    return szinesz is not null ? Results.Ok(szinesz) : Results.NotFound();
}).WithName(GetSzineszById);

//POST szinesz
app.MapPost("/szineszek", (CreateSzineszekDto ujSzinesz) =>
{
    if(string.IsNullOrEmpty(ujSzinesz.Name))
    {
        return Results.BadRequest("A színész neve nem lehet üres.");
    }
    int newId = szineszek.Max(s => s.Id) + 1;
    var szinesz = new SzineszekDto(newId, ujSzinesz.Name);
    szineszek.Add(szinesz);
    return Results.CreatedAtRoute(GetSzineszById, new { id = newId }, szinesz);
});

//PUT szinesz
app.MapPut("/szineszek/{id}", (int id, UpdateSzineszekDto frissitettSzinesz) =>
{
    var szinesz = szineszek.FirstOrDefault(s => s.Id == id);
    if (szinesz is null)
    {
        return Results.NotFound();
    }
    var index = szineszek.IndexOf(szinesz);
    var updatedSzinesz = new SzineszekDto(id, frissitettSzinesz.Name);
    szineszek[index] = updatedSzinesz;
    return Results.Ok(updatedSzinesz);
});

//DELETE szinesz
app.MapDelete("/szineszek/{id}", (int id) =>
{
    var szinesz = szineszek.FirstOrDefault(s => s.Id == id);
    if (szinesz is null)
    {
        return Results.NotFound();
    }
    szineszek.Remove(szinesz);
    return Results.NoContent();
});

//GET filmcast
app.MapGet("/filmcast", () => cast);

//GET filmcast by id
app.MapGet("/filmcast/{id}", (int id) =>
{
    var filmcast = cast.FirstOrDefault(fc => fc.SzineszId == id);
    return filmcast is not null ? Results.Ok(filmcast) : Results.NotFound();
}).WithName(GetFilmCastById);
//POST filmcast
app.MapPost("/filmcast", (CreateFilmCastDto ujFilmCast) =>
{
    if(string.IsNullOrEmpty(ujFilmCast.filmCim))
    {
        return Results.BadRequest("A film címe nem lehet üres.");
    }
    var filmcast = new FilmCastDto(ujFilmCast.SzineszId, ujFilmCast.filmCim);
    cast.Add(filmcast);
    return Results.CreatedAtRoute(GetFilmCastById, new { id = ujFilmCast.SzineszId }, filmcast);
});
//PUT filmcast
app.MapPut("/filmcast/{id}", (int id, UpdateFilmCastDto frissitettFilmCast) =>
{
    var filmcast = cast.FirstOrDefault(fc => fc.SzineszId == id);
    if (filmcast is null)
    {
        return Results.NotFound();
    }
    var index = cast.IndexOf(filmcast);
    var updatedFilmCast = new FilmCastDto(id, frissitettFilmCast.filmCim);
    cast[index] = updatedFilmCast;
    return Results.Ok(updatedFilmCast);
});

}}
