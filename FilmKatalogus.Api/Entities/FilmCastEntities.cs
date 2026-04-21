using System;

namespace FilmKatalogus.Api.Entities;

public record class FilmCastEntities{
    public int Id { get; set; }
    public int SzineszId { get; set; }
    public required int filmId { get; set; }
}
