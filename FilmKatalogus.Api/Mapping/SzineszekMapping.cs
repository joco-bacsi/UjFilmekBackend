using System;
using FilmKatalogus.Api.Dtos;
using FilmKatalogus.Api.Entities;

namespace FilmKatalogus.Api.Mapping;

public static class SzineszekMapping
{
    static public SzineszekEntities ToEntity(this CreateSzineszekDto createSzineszekDto)
    {
        return new SzineszekEntities
        {
            Id = createSzineszekDto.Id,
            Name = createSzineszekDto.Name
        };
    }
    static public SzineszekEntities ToEntity(this UpdateSzineszekDto updateSzineszekDto)
    {
        return new SzineszekEntities
        {
            Id = updateSzineszekDto.Id,
            Name = updateSzineszekDto.Name
        };
    }
    static public SzineszekEntities ToEntity(this UpdateSzineszekDto updateSzineszekDto, int id)
    {
        return new SzineszekEntities
        {
            Id = id,
            Name = updateSzineszekDto.Name
        };
    }
    static public SzineszekDto ToDto(this SzineszekEntities szineszek)
    {
        return new SzineszekDto(szineszek.Id, szineszek.Name);
    }
    static public SzineszekSummaryDto ToSummaryDto(this SzineszekEntities szineszek)
    {
        return new SzineszekSummaryDto(szineszek.Id, szineszek.Name);
    }


}
