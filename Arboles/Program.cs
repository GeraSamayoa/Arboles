using Arboles; // Asegúrate de incluir el namespace correcto para la clase App si es diferente
using ArbolBalanceado.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Registro del servicio HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Registro del servicio ArbolBalanceadoNodo<int>
builder.Services.AddSingleton<ArbolBalanceadoNodo<int>>();

await builder.Build().RunAsync();
