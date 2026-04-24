using System.ComponentModel.DataAnnotations;

namespace FilmKatalogus.Api.Dtos;

public record class FilmCreateDto(
    [Required]string Rendezo, 
    [Required]string Cim, 
    int MufajId,
    int Hossz, 
    [Required]string Nyelv, 
    DateOnly MegjelenesiDatum,
    double ImDbErtekeles, 
    double SajatErtekeles
);