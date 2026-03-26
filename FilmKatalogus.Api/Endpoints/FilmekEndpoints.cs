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
var szinesz = app.MapGroup("szineszek")
                       .WithParameterValidation();

        // GET /games
        szinesz.MapGet("/", async (FilmKatalogusContext dbContext) => 
        await dbContext.Szineszek.ToListAsync());

//GET szinesz by id
szinesz.MapGet("/{id}", async (int id, FilmKatalogusContext dbContext) =>
        {
            SzineszekEntities? szinesz = await dbContext.Szineszek.FindAsync(id);

            return szinesz is null ? 
                Results.NotFound() : Results.Ok(szinesz);
        })
        .WithName(GetSzineszById);

//POST szinesz
szinesz.MapPost("/", async (CreateSzineszekDto ujSzinesz, FilmKatalogusContext dbContext) =>
        {
            SzineszekEntities szinesz = new SzineszekEntities
            {
                Name = ujSzinesz.Name
            };

            dbContext.Szineszek.Add(szinesz);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetSzineszById,
                new { id = szinesz.Id },
                szinesz);
        });

//PUT szinesz
szinesz.MapPut("/", async (int id, UpdateSzineszekDto frissitettSzinesz, FilmKatalogusContext dbContext) =>
{
    var existingSzinesz = await dbContext.Szineszek.FindAsync(id);

    if (existingSzinesz is null)
    {
        return Results.NotFound();
    }

    dbContext.Entry(existingSzinesz).CurrentValues.SetValues(frissitettSzinesz.ToEntity(id));

    await dbContext.SaveChangesAsync();

    return Results.NoContent();
});

//DELETE szinesz
szinesz.MapDelete("/{id}", async (int id, FilmKatalogusContext dbContext) =>
        {
            await dbContext.Szineszek
                     .Where(szinesz => szinesz.Id == id)
                     .ExecuteDeleteAsync();

            return Results.NoContent();
        });

//GET filmcast
var cast = app.MapGroup("filmcast")
                       .WithParameterValidation();


//GET filmcast by id
cast.MapGet("/{id}", async (int id, FilmKatalogusContext dbContext) =>
        {
            FilmCastEntities? filmcast = await dbContext.FilmCast.FindAsync(id);

            return filmcast is null ? 
                Results.NotFound() : Results.Ok(filmcast);
        })
        .WithName(GetFilmCastById);
//POST filmcast
cast.MapPost("/", async (CreateFilmCastDto ujFilmCast, FilmKatalogusContext dbContext) =>
        {
            FilmCastEntities filmcast = new FilmCastEntities
            {
                SzineszId = ujFilmCast.SzineszId,
                filmCim = ujFilmCast.filmCim
            };

            dbContext.FilmCast.Add(filmcast);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute(
                GetFilmCastById,
                new { id = filmcast.Id },
                filmcast);
        });
//PUT filmcast
cast.MapPut("/", async (int id, UpdateFilmCastDto frissitettFilmCast, FilmKatalogusContext dbContext) =>
{
    var existingFilmCast = await dbContext.FilmCast.FindAsync(id);

    if (existingFilmCast is null)
    {
        return Results.NotFound();
    }

    dbContext.Entry(existingFilmCast).CurrentValues.SetValues(frissitettFilmCast.ToEntity(id));

    await dbContext.SaveChangesAsync();

    return Results.NoContent();
});

}}
