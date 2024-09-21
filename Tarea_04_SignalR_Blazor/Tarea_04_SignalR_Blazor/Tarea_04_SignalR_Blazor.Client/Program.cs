using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

//de este lado importo del lado del cliente signalR y radzen usando el archivo _Imports.razor (notese diferencia respecto al del servidor)
var builder = WebAssemblyHostBuilder.CreateDefault(args);

//agrego radzen del lado del cliente
builder.Services.AddRadzenComponents();

await builder.Build().RunAsync();
