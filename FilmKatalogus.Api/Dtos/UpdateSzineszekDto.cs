using System.ComponentModel.DataAnnotations;

namespace FilmKatalogus.Api.Dtos
{
    public record class UpdateSzineszekDto(
    int Id, [Required] string Name
);}
