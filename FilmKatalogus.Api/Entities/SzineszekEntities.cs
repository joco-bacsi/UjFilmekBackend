using System;

namespace FilmKatalogus.Api.Entities;

public record class SzineszekEntities
{
    public int Id { get; set; }

    public required string Name { get; set; }
}
