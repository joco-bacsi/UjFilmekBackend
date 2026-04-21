using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class Film_castClient(HttpClient httpClient)
{
    public async Task<Film_castDetails[]> GetFilm_castokAsync() 
        => await httpClient.GetFromJsonAsync<Film_castDetails[]>("filmcast") ?? [];

    public async Task AddFilm_castAsync(Film_castDetails film)
        => await httpClient.PostAsJsonAsync("filmcast", film);

    public async Task<Film_castDetails> GetFilm_castAsync(int id)
        => await httpClient.GetFromJsonAsync<Film_castDetails>($"filmcast/{id}")
            ?? throw new Exception("Could not find film!");

    public async Task UpdateFilm_castAsync(Film_castDetails updatedFilm)
        => await httpClient.PutAsJsonAsync($"filmcast/{updatedFilm.id}", updatedFilm);

    public async Task DeleteFilmAsync(int id)
        => await httpClient.DeleteAsync($"filmcast/{id}");
}

