using Microsoft.OpenApi.Models;
using System.Reflection;
using Taller.NET_Tarea02_a.Models;

var builder = WebApplication.CreateBuilder(args);


// documentación clase Builder
// https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.webapplicationbuilder?view=aspnetcore-8.0

//Agrego logger
builder.Logging.AddConsole();

// Add services to the container.

//builder.Services.AddControllers();

builder.Services.AddSingleton<TaskClass>();
builder.Services.AddMvc().AddControllersAsServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//Swagger habilitado para documentar con XML
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Tareas API",
        Description = "Una API en ASP.NET Core Web para gestionar Tareas",
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
