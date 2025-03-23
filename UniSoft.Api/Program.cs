using UniSoft.Infrastructure.Configurations;
using UniSoft.Application.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() // Autoriser toutes les origines
                   .AllowAnyMethod() // Autoriser toutes les méthodes (GET, POST, etc.)
                   .AllowAnyHeader(); // Autoriser tous les en-têtes
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configuration de l'infrastructure (Dapper, SQLite, Repositories)
builder.Services.ConfigureInfrastructure(builder.Configuration);

// Configuration de l'application
builder.Services.ConfigureApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
// Utiliser la politique CORS
app.UseCors("AllowAllOrigins");
app.MapControllers();
app.Run();
