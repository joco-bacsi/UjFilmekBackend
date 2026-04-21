using System;

namespace GameStore.Frontend.Models;

public class FilmekDetails
{
    public int Id {get; set;}
    public required string Rendezo {get; set;}
    public required string Cim {get; set;}
    public int MufajId {get; set;}
    public TimeOnly Hossz {get; set;}
    public required string Nyelv {get; set;}
    public DateOnly MegjelenesiDatum {get; set;} = DateOnly.FromDateTime(DateTime.Now);
    public double ImDbErtekeles {get; set;}
    public double SajatErtekeles {get; set;}
}    
