
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDaprClient();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCloudEvents();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapSubscribeHandler());

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");


app.MapPost("/counter", async (DaprClient client,[FromBody] int counter) =>{
    Console.WriteLine($"Updating counter: {counter}");
    await client.SaveStateAsync("statestore", "count", counter);
    return Results.Accepted("/", counter);
}).WithTopic("pubsub", "counter");

app.Run();

record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}