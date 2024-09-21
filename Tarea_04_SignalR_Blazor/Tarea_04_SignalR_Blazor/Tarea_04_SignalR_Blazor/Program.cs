using Microsoft.AspNetCore.SignalR;
using Tarea_04_SignalR_Blazor.Client.Pages;
using Tarea_04_SignalR_Blazor.Components;
using Tarea_04_SignalR_Blazor.Hub;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

//agrego radzen
builder.Services.AddRadzenComponents();
//agrego signalR
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Tarea_04_SignalR_Blazor.Client._Imports).Assembly);


//conexion con mi hub
app.MapHub<VerificationLoginHub>("/hubConnection");

//endpoint de verificacion de usuario.
app.MapGet("/verify/user/{userId}", (string userId,
    ILogger<VerificationLoginHub> logger,
    IHubContext<VerificationLoginHub> hubContext) => {

        logger.LogInformation("Notificando cliente con user id: " + userId);
        //envio una notificacion al usuario que esa conectado (discrimino por ConnectionId).
        hubContext.Clients.Client(userId).SendAsync("userVerifiedSuccesfully", userId);
    });

app.Run();
