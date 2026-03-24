using System;
using Microsoft.EntityFrameworkCore;

namespace FilmKatalogus.Api.Models;

public class Mufaj
{
    public int Id{ get; set; }
    public required string Nev { get; set; } = string.Empty;
}
