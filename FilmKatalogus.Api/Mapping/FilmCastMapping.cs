using FilmKatalogus.Api.Dtos;
using FilmKatalogus.Api.Entities;

namespace FilmKatalogus.Api.Mapping;
public static class FilmCastMapping
{
    public static FilmCastEntities ToDto(this FilmCastEntities filmCast)
    {
        return new FilmCastEntities
        {
            SzineszId = filmCast.SzineszId,
            filmCim = filmCast.filmCim
        };
    }
    public static FilmCastEntities ToEntity(this CreateFilmCastDto filmCast)
    {
        return new FilmCastEntities
        {
            SzineszId = filmCast.SzineszId,
            filmCim = filmCast.filmCim
        };
    }
    public static FilmCastEntities ToEntity(this UpdateFilmCastDto filmCast)
    {
        return new FilmCastEntities
        {
            SzineszId = filmCast.SzineszId,
            filmCim = filmCast.filmCim
        };
    }
    public static FilmCastSummaryDto ToSummaryDto(this FilmCastEntities filmCast)
    {
        return new FilmCastSummaryDto(filmCast.SzineszId, filmCast.filmCim);
    }
}