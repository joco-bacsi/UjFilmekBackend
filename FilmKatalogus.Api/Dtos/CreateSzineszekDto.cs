using System.ComponentModel.DataAnnotations;

namespace FilmKatalogus.Api.Dtos
{
    public record class CreateSzineszekDto(
    int Id, [Required] string Name
);}
