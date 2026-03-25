using System;

namespace FilmKatalogus.Api.Entities;

public record class FilmCastEntities{
    public int SzineszId { get; set; }
    public required string filmCim { get; set; }
}
