using FilmKatalogus.Api.Dtos;
using FilmKatalogus.Api.Entities;

namespace FilmKatalogus.Api.Mapping;

public static class FilmekMapping
{
    public static FilmekEntities ToEntity(this FilmCreateDto filmek)
    {
        return new FilmekEntities()
        {
            Rendezo = filmek.Rendezo,
            Cim = filmek.Cim,
            Mufaj = filmek.Mufaj,
            Hossz = filmek.Hossz,
            Nyelv = filmek.Nyelv,
            MegjelenesiDatum = filmek.MegjelenesiDatum,
            ImDbErtekeles = filmek.ImDbErtekeles,
            SajatErtekeles = filmek.SajatErtekeles
        };
    }

    public static FilmekEntities ToEntity(this UpdateFilmDto filmek, int id)
    {
        return new FilmekEntities()
        {
            Id = id,
            Rendezo = filmek.Rendezo,
            Cim = filmek.Cim,
            Mufaj = filmek.Mufaj,
            Hossz = filmek.Hossz,
            Nyelv = filmek.Nyelv,
            MegjelenesiDatum = filmek.MegjelenesiDatum,
            ImDbErtekeles = filmek.ImDbErtekeles,
            SajatErtekeles = filmek.SajatErtekeles
        };
    }    

    public static FilmekSummaryDto ToFilmekSummaryDto(this FilmekEntities filmek)
    {
        return new(
            filmek.Id,
            filmek.Cim,
            filmek.Rendezo,
            filmek.Mufaj,
            filmek.Hossz,
            filmek.Nyelv,
            filmek.MegjelenesiDatum,
            filmek.ImDbErtekeles,
            filmek.SajatErtekeles
        );
    }

    public static FilmekDto ToFilmekDetailsDto(this FilmekEntities filmek)
    {
        return new(
            filmek.Id,
            filmek.Cim,
            filmek.Rendezo,
            filmek.Mufaj,
            filmek.Hossz,
            filmek.Nyelv,
            filmek.MegjelenesiDatum,
            filmek.ImDbErtekeles,
            filmek.SajatErtekeles
        );
    }    
}
