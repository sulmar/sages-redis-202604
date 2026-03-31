using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("localhost:6379"));

var app = builder.Build();
app.UseSession();

app.Use(async (context, next) =>
{    
    await next();
});

app.MapGet("/cart", async (HttpContext context, IConnectionMultiplexer muxer) =>
{
    throw new NotImplementedException();

});

app.MapGet("/cart/{productId:int}", async (int productId, HttpContext context, IConnectionMultiplexer muxer) =>
{
    throw new NotImplementedException();

});

app.MapPost("/cart/{productId:int}", async (int productId, [FromQuery] int? quantity, HttpContext context, IConnectionMultiplexer muxer) =>
{
    throw new NotImplementedException();

});

app.MapPut("/cart/{productId:int}", async (int productId, [FromQuery] int? incrementBy, HttpContext context, IConnectionMultiplexer muxer) =>
{
    throw new NotImplementedException();

});

app.MapDelete("/cart/{productId:int}", async (int productId, HttpContext context, IConnectionMultiplexer muxer) =>
{
    throw new NotImplementedException();

});

app.Run();
