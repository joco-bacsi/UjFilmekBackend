using FilmKatalogus.Api.Dtos;
using FilmKatalogus.Api.Entities;

namespace FilmKatalogus.Api.Mapping;
public static class FilmCastMapping
{  
    public static FilmCastEntities ToEntity(this CreateFilmCastDto filmCast)
    {
        return new FilmCastEntities
        {            
            SzineszId = filmCast.SzineszId,
            filmId = filmCast.filmId
        };
    }
    public static FilmCastEntities ToEntity(this UpdateFilmCastDto filmCast, int id)
    {
        return new FilmCastEntities
        {
            Id = id,
            SzineszId = filmCast.SzineszId,
            filmId = filmCast.filmId
        };
    }
    public static FilmCastSummaryDto ToSummaryDto(this FilmCastEntities filmCast)
    {
        return new (filmCast.Id, filmCast.SzineszId, filmCast.filmId);
    }
}