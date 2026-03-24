using System;

namespace FilmKatalogus.Api.Models;

public class Nyelv
{
    public int Id { get; set; }
    public required string Nev { get; set; } = string.Empty;
}
