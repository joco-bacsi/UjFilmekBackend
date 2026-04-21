using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class FilmekClient(HttpClient httpClient)
{
    public async Task<FilmekDetails[]> GetFilmekAsync() 
        => await httpClient.GetFromJsonAsync<FilmekDetails[]>("Filmek") ?? [];

    public async Task AddFilmAsync(FilmekDetails film)
        => await httpClient.PostAsJsonAsync("Filmek", film);

    public async Task<FilmekDetails> GetFilmAsync(int id)
        => await httpClient.GetFromJsonAsync<FilmekDetails>($"Filmek/{id}")
            ?? throw new Exception("Could not find film!");

    public async Task UpdateFilmAsync(FilmekDetails updatedFilm)
        => await httpClient.PutAsJsonAsync($"Filmek/{updatedFilm.Id}", updatedFilm);

    public async Task DeleteFilmAsync(int id)
        => await httpClient.DeleteAsync($"Filmek/{id}");
}
