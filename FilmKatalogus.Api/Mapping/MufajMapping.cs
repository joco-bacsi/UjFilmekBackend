using FilmKatalogus.Api.Dtos;
using FilmKatalogus.Api.Entities;

namespace FilmKatalogus.Api.Mapping;

public static class MufajMapping
{
    public static Mufaj ToEntity(this MufajDto mufaj)
    {
        return new Mufaj()
        {
            Id = mufaj.Id,
            Name = mufaj.Name
        };
    }

    public static MufajDto ToMufajDto(this Mufaj mufaj)
    {
        return new MufajDto(mufaj.Id, mufaj.Name);
    }
}

