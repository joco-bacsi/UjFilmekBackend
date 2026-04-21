using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class MufajClient(HttpClient httpClient)
{
    public async Task<MufajokDetails[]> GetMufajokAsync() 
        => await httpClient.GetFromJsonAsync<MufajokDetails[]>("Mufajok") ?? [];

    public async Task AddMufajAsync(MufajokDetails mufaj)
        => await httpClient.PostAsJsonAsync("Mufajok", mufaj);

    public async Task<MufajokDetails> GetMufajAsync(int id)
        => await httpClient.GetFromJsonAsync<MufajokDetails>($"Mufajok/{id}")
            ?? throw new Exception("Could not find mufaj!");

    public async Task UpdateMufajAsync(MufajokDetails updatedMufaj)
        => await httpClient.PutAsJsonAsync($"Mufajok/{updatedMufaj.Id}", updatedMufaj);

    public async Task DeleteMufajAsync(int id)
        => await httpClient.DeleteAsync($"Mufajok/{id}");
}

