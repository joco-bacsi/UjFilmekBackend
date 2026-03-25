using System;
using FilmKatalogus.Api.Dtos;

namespace FilmKatalogus.Api.Endpoints;

public static class FilmekEndpoints
{
    const string GetFilmById = "GetFilmById";
const string GetSzineszById = "GetSzineszById";
const string GetFilmCastById = "GetFilmCastById";
    private static readonly List<FilmekDto> filmek = new List<FilmekDto>
    {
        new FilmekDto(1, "Christopher Nolan", "Inception", "Sci-Fi", new TimeOnly(2, 28), "English", new DateOnly(2010, 7, 16), 8.8, 9.0),
        new FilmekDto(2, "Quentin Tarantino", "Pulp Fiction", "Crime", new TimeOnly(2, 34), "English", new DateOnly(1994, 10, 14), 8.9, 9.5),
        new FilmekDto(3, "Steven Spielberg", "Jurassic Park", "Adventure", new TimeOnly(2, 7), "English", new DateOnly(1993, 6, 11), 8.1, 8.5)
    };

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
        //GetAll
app.MapGet("/filmek", () => filmek);

//GetById
app.MapGet("/filmek/{id}", (int id) =>
{
    var film = filmek.FirstOrDefault(f => f.Id == id);
    return film is not null ? Results.Ok(film) : Results.NotFound();
}).WithName(GetFilmById);
//Post
app.MapPost("/filmek", (FilmCreateDto ujFilm) =>
{
    if( string.IsNullOrEmpty(ujFilm.Rendezo) || string.IsNullOrEmpty(ujFilm.Cim) || string.IsNullOrEmpty(ujFilm.Mufaj) || string.IsNullOrEmpty(ujFilm.Nyelv))
    {
        return Results.BadRequest("Minden mező kitöltése kötelező.");
    }
    int newId = filmek.Max(f => f.Id) + 1;
    var film = new FilmekDto(newId, ujFilm.Rendezo, ujFilm.Cim, ujFilm.Mufaj, ujFilm.Hossz, ujFilm.Nyelv, ujFilm.MegjelenesiDatum, ujFilm.ImDbErtekeles, ujFilm.SajatErtekeles);
    filmek.Add(film);
    return Results.CreatedAtRoute(GetFilmById, new { id = newId }, film);
});
//Put
app.MapPut("/filmek/{id}", (int id, UpdateFilmDto frissitettFilm) =>
{
    var film = filmek.FirstOrDefault(f => f.Id == id);
    if (film is null)
    {
        return Results.NotFound();
    }
    var index = filmek.IndexOf(film);
    var updatedFilm = new FilmekDto(id, frissitettFilm.Rendezo, frissitettFilm.Cim, frissitettFilm.Mufaj, frissitettFilm.Hossz, frissitettFilm.Nyelv, frissitettFilm.MegjelenesiDatum, frissitettFilm.ImDbErtekeles, frissitettFilm.SajatErtekeles);
    filmek[index] = updatedFilm;
    return Results.Ok(updatedFilm);
});
//delete
app.MapDelete("/filmek/{id}", (int id) =>
{
    var film = filmek.FirstOrDefault(f => f.Id == id);
    if (film is null)
    {
        return Results.NotFound();
    }
    filmek.Remove(film);
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

}}
