using GameStore.Frontend.Clients;
using GameStore.Frontend.Components;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddCircuitOptions(options =>
    {
        options.DisconnectedCircuitMaxRetained = 5;
        // ReconnectInterval is not available in this API; Blazor Server reconnection is handled by the client JS layer.
        // To keep circuits open a bit longer, use DisconnectedCircuitRetentionPeriod if available:
        // options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(1);
    });

builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Services.AddServerSideBlazor(options => 
{
    options.DetailedErrors = true; // This allows the browser to see the actual C# exception
});

var gameStoreApiUrl = builder.Configuration["GameStoreApiUrl"] ?? 
    throw new Exception("GameStoreApiUrl is not set");

builder.Services.AddHttpClient<FilmekClient>(
    client => client.BaseAddress = new Uri(gameStoreApiUrl)); 
builder.Services.AddHttpClient<SzineszekClient>(
    client => client.BaseAddress = new Uri(gameStoreApiUrl));
builder.Services.AddHttpClient<MufajClient>(
    client => client.BaseAddress = new Uri(gameStoreApiUrl));
builder.Services.AddHttpClient<Film_castClient>(
    client => client.BaseAddress = new Uri(gameStoreApiUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
