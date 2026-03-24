using FilmKatalogus.Api.Dtos;
using FilmKatalogus.Api.Entities;

namespace FilmKatalogus.Api.Mapping;

public static class MufajMapping
{
    public static MufajDto ToDto(this MufajEntities mufaj)
    {
        return new MufajDto(mufaj.Id, mufaj.Name);
    }
}
