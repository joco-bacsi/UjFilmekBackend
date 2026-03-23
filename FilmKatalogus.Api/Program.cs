using FilmKatalogus.Api.Dtos;
using FilmKatalogus.Api.Endpoints;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
var app = builder.Build();


app.MapFilmekEndpoints();

app.Run();
