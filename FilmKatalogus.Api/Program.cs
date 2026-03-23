using FilmKatalogus.Api.Dtos;
using FilmKatalogus.Api.Endpoints;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();


app.MapFilmekEndpoints();

app.Run();
