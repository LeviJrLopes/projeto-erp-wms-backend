using Microsoft.Extensions.Options;
using wmserp.api.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//o builder.Services serve para gerar a doc da api, o swagger. ele permite fazer testes nos endpoints direto pelo navegador
builder.Services.AddOpenApi();

//conf do banco de dados
//tudo o que o sistema precisa, devemos colocar dentro do buider.services logo na inicialização
//esse trecho vai ate o appsettings.json e procura pela chave DefaultConnection e le o texto dela
builder.Services.AddDbContext<SistemaWmsComErpContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
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



//o codigo abaixo cria uma rota api para testar a insercao de dados na tabela

app.MapPost("/api/clientes", async (Cliente novoCliente, SistemaWmsComErpContext context) =>
{
    try
    {
        await context.Clientes.AddAsync(novoCliente);
        await context.SaveChangesAsync();
        return Results.Created($"/api/clientes{novoCliente.IdCliente}", novoCliente);

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
