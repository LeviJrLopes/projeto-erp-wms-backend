using Microsoft.Extensions.Options;
using wmserp.api.Models;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore; // Importante para o Scalar funciona

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURAÇÃO DOS SERVIÇOS ---

// Ativa o gerador de documentação oficial do .NET 9
builder.Services.AddOpenApi();

// Configuração do Banco de Dados PostgreSQL
builder.Services.AddDbContext<SistemaWmsComErpContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Impede loops infinitos ao ler dados com relacionamentos
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});


var app = builder.Build();

// --- 2. CONFIGURAÇÃO DO PIPELINE (MIDDLEWARES) ---

if (app.Environment.IsDevelopment())
{
    // Ativa a geração do arquivo contendo os dados da API
    app.MapOpenApi();
    
    // 1ª Opção Visual: Interface Moderna do Scalar
    app.MapScalarApiReference(); 

    // 2ª Opção Visual: Interface Clássica do Swagger (Gerada a partir do OpenAPI do .NET 9)
    
}

app.UseHttpsRedirection();

// --- 3. ROTAS DA API (ENDPOINTS) ---

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");


// Rota para cadastrar novos clientes (Sua Minimal API)
app.MapPost("/api/clientes", async (Cliente novoCliente, SistemaWmsComErpContext context) =>
{
    try
    {
        await context.Clientes.AddAsync(novoCliente);
        await context.SaveChangesAsync();
        return Results.Created($"/api/clientes/{novoCliente.IdCliente}", novoCliente);
    }
    catch(Exception ex)
    {
        return Results.Problem($"Erro ao salvar no banco: {ex.Message}");
    }
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}