using System;

namespace FilmKatalogus.Api.Dtos;

public record class CreateFilmCastDto(int Id, int SzineszId, string filmCim);
