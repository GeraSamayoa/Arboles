using Arboles;
using Arboles.Services; // Agrega esta línea para poder acceder al espacio de nombres de ArbolBinarioBusqueda
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ArbolBinarioBusqueda>(); // Agrega esta línea para registrar el servicio

await builder.Build().RunAsync();