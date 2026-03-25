namespace FilmKatalogus.Api.Dtos;

    public record class UpdateFilmDto(
    int Id, 
    string Rendezo, 
    string Cim, 
    int MufajId, 
    TimeOnly Hossz, 
    string Nyelv, 
    DateOnly MegjelenesiDatum,
    double ImDbErtekeles, 
    double SajatErtekeles
);
