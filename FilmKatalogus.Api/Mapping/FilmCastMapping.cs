using FilmKatalogus.Api.Dtos;
using FilmKatalogus.Api.Entities;

namespace FilmKatalogus.Api.Mapping;
public static class FilmCastMapping
{
    public static FilmCastEntities ToDto(this FilmCastEntities filmCast)
    {
        return new FilmCastEntities
        {
            Id = filmCast.Id,
            SzineszId = filmCast.SzineszId,
            filmCim = filmCast.filmCim
        };
    }
    public static FilmCastEntities ToEntity(this CreateFilmCastDto filmCast)
    {
        return new FilmCastEntities
        {
            Id = filmCast.Id,
            SzineszId = filmCast.SzineszId,
            filmCim = filmCast.filmCim
        };
    }
    public static FilmCastEntities ToEntity(this UpdateFilmCastDto filmCast, int id)
    {
        return new FilmCastEntities
        {
            Id = id,
            SzineszId = filmCast.SzineszId,
            filmCim = filmCast.filmCim
        };
    }
    public static FilmCastSummaryDto ToSummaryDto(this FilmCastEntities filmCast)
    {
        return new FilmCastSummaryDto(filmCast.Id, filmCast.SzineszId, filmCast.filmCim);
    }
}