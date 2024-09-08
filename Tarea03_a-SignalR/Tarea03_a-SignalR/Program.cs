using Microsoft.AspNetCore.SignalR;
using Tarea03_a_SignalR.Hub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR(); //agregro servicio signalR

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.MapHub<VerificationLoginHub>("/login"); //me permite conectarme al hub en esta ruta

app.MapGet("/verify/user/{userId}", (string userId, 
    ILogger<VerificationLoginHub> logger,
    IHubContext<VerificationLoginHub> hubContext) => {

        logger.LogInformation("Notificando cliente con user id: " + userId);
        //envio una notificacion al usuario que esa conectado (discrimino por ConnectionId).
        hubContext.Clients.Client(userId).SendAsync("userVerifiedSuccesfully", userId); 
});


app.Run();
