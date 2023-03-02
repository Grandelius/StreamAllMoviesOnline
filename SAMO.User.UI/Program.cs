

using SAMO.Common.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddHttpClient<AdminHttpClient>(client =>
client.BaseAddress = new Uri("https://localhost:6001/api/"));

await builder.Build().RunAsync();
