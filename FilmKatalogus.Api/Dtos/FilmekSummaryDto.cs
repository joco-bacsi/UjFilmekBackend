namespace FilmKatalogus.Api.Dtos;

    public record class FilmekSummaryDto(
    int Id, 
    string Rendezo, 
    string Cim, 
    string Mufaj, 
    TimeOnly Hossz, 
    string Nyelv, 
    DateOnly MegjelenesiDatum,
    double ImDbErtekeles, 
    double SajatErtekeles
);