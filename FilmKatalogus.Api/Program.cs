using FilmKatalogus.Api.Dtos;
using FilmKatalogus.Api.Endpoints;


var builder = WebApplication.CreateBuilder(args);


var connsectionString = builder.Configuration.GetConnectionString("FilmKatalogusDb");
builder.Services.AddSqlite<FilmKatalogus.Api.Data.FilmKatalogusContext>(connsectionString);

var app = builder.Build();


app.MapFilmekEndpoints();

app.Run();
