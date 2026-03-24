using FilmKatalogus.Api.Data;
using FilmKatalogus.Api.Entities;
using FilmKatalogus.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace FilmKatalogus.Api.Endpoints;

public static class MufajEndpoints
{
    public static RouteGroupBuilder MapMufajEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("mufajok").WithTags("Mufajok");

        group.MapGet("/", async (FilmKatalogusContext dbContext) =>
            await dbContext.Mufajok
                           .Select(mufaj => mufaj.ToMufajDto())
                           .AsNoTracking()
                           .ToListAsync());

        return group;
    }
}