using FilmKatalogus.Api.Data;
using FilmKatalogus.Api.Dtos;
using FilmKatalogus.Api.Endpoints;


var builder = WebApplication.CreateBuilder(args);

var connsectionString = builder.Configuration.GetConnectionString("FilmKatalogusDb");
builder.Services.AddSqlite<FilmKatalogusContext>(connsectionString);

var app = builder.Build();


app.MapFilmekEndpoints();
app.MapMufajEndpoints();


app.Run();
