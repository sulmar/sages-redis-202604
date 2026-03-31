

using icd10_api;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// dotnet add package StackExchange.Redis

builder.Services.AddHostedService<CD10HostedService>();

builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = ConfigurationOptions.Parse("localhost:6379");
    return ConnectionMultiplexer.Connect(configuration);
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/icd10", (IConnectionMultiplexer redis) => { 

    var db = redis.GetDatabase();

    var key = "icd10";

    // SMEMBERS
    var values = db.SetMembers(key);

    return values.Select(v => v.ToString().Split("|")).ToArray();

});


// SADD icd10


app.Run();
