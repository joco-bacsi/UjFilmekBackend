using FilmKatalogus.Api.Dtos;
using FilmKatalogus.Api.Entities;

namespace FilmKatalogus.Api.Mapping;

public static class FilmekMapping
{
    public static Filmek ToEntity(this FilmCreateDto filmek)
    {
        return new Filmek()
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

    public static Filmek ToEntity(this UpdateFilmDto filmek, int id)
    {
        return new Filmek()
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

    public static FilmekSummaryDto ToFilmekSummaryDto(this Filmek filmek)
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

    public static FilmekDto ToFilmekDetailsDto(this Filmek filmek)
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
