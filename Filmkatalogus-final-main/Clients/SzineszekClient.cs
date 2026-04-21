using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;


public class SzineszekClient(HttpClient httpClient)
{
    public async Task<SzineszekDetails[]> GetSzineszekAsync() 
        => await httpClient.GetFromJsonAsync<SzineszekDetails[]>("szineszek") ?? [];

    public async Task AddSzineszAsync(SzineszekDetails szinesz)
        => await httpClient.PostAsJsonAsync("szineszek", szinesz);

    public async Task<SzineszekDetails> GetSzineszAsync(int id)
        => await httpClient.GetFromJsonAsync<SzineszekDetails>($"szineszek/{id}")
            ?? throw new Exception("Could not find szinesz!");

    public async Task UpdateSzineszAsync(SzineszekDetails updatedSzinesz)
        => await httpClient.PutAsJsonAsync($"szineszek/{updatedSzinesz.Id}", updatedSzinesz);

    public async Task DeleteSzineszAsync(int id)
        => await httpClient.DeleteAsync($"szineszek/{id}");
}
                                                    