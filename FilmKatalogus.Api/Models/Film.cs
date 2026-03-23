using System;

namespace FilmKatalogus.Api.Models;

public class Film
{
    public int Id { get; set; }
    public required string Rendezo { get; set; }
    public required string Cim { get; set; }
    public required Mufaj? Mufaj { get; set; }
    public int MufajId { get; set; }
    public required TimeOnly Hossz { get; set; }
    public required Nyelv? Nyelv { get; set; }
    public int NyelvId { get; set; }
    public required DateOnly MegjelenesiDatum { get; set; }
    public double? ImDbErtekeles { get; set; }
    public double? SajatErtekeles { get; set; }
}
