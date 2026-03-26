using FilmKatalogus.Api.Data;
using FilmKatalogus.Api.Endpoints;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connsectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FilmKatalogusContext>(options =>
    options.UseMySql(connsectionString, ServerVersion.AutoDetect(connsectionString)));

var app = builder.Build();


app.MapFilmekEndpoints();
app.MapMufajEndpoints();


app.Run();
