using FilmKatalogus.Api.Data;
using FilmKatalogus.Api.Entities;
using FilmKatalogus.Api.Mapping;
using Microsoft.EntityFrameworkCore;





namespace FilmKatalogus.Api.Endpoints;

public static class MufajEndpoints
{
    public static RouteGroupBuilder MapMufajEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("mufajok");

        group.MapGet("/", async (FilmKatalogusContext dbContext) =>
        {
            var mufajok = await dbContext.Mufajok.ToListAsync();
            return mufajok.Select(m => m.ToDto());
        }).WithName("GetMufajok").WithTags("Mufajok");

        return group;
    }
}