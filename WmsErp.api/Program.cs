using Microsoft.Extensions.Options;
using wmserp.api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURAÇÃO DOS SERVIÇOS (CONTAINER) ---

// Ativa o Swagger clássico (Swashbuckle) que gerencia os loops perfeitamente
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do Banco de Dados PostgreSQL
builder.Services.AddDbContext<SistemaWmsComErpContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Impede loops infinitos nas rotas da API
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});


var app = builder.Build();

// --- 2. CONFIGURAÇÃO DO PIPELINE (MIDDLEWARES) ---

if (app.Environment.IsDevelopment())
{
    // Ativa a interface azul clássica do Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// --- 3. ROTAS DA API ---

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