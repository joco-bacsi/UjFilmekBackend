using System.ComponentModel.DataAnnotations;

namespace FilmKatalogus.Api.Dtos;

public record class FilmCreateDto(
    [Required]string Rendezo, 
    [Required]string Cim, 
    [Required]string Mufaj, 
    TimeOnly Hossz, 
    [Required]string Nyelv, 
    DateOnly MegjelenesiDatum,
    double ImDbErtekeles, 
    double SajatErtekeles
);