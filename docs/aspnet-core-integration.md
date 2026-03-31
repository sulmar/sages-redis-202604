# ASP.NET Core integration

Part 3 of the course (`src/RedisNetCore/03_ASPNETCore`) shows how to use Redis next to minimal APIs, SQLite, and HTTP clients.

## Registering `IConnectionMultiplexer`

Register the multiplexer as a **singleton** so one connection factory is shared:

```csharp
builder.Services.AddSingleton<IConnectionMultiplexer>(
    _ => ConnectionMultiplexer.Connect("localhost:6379"));
```

Example in the repo: [`02_RedisHashes/Program.cs`](../src/RedisNetCore/03_ASPNETCore/02_RedisHashes/Program.cs).

In production, read the connection string from configuration (`IConfiguration`) or user secrets instead of hard-coding `localhost:6379`.

## Injecting into endpoints

Minimal APIs can take `IConnectionMultiplexer` as a parameter:

```csharp
app.MapGet("/example", async (IConnectionMultiplexer muxer) =>
{
    var db = muxer.GetDatabase();
    // await db.StringGetAsync("key");
});
```

Use **`GetDatabase()`** and async methods (`*Async`) to avoid blocking threads.

## Session and cart sample (`02_RedisHashes`)

The template wires **distributed memory cache** and **session** middleware and maps cart routes that accept `IConnectionMultiplexer`. Handlers are left as `NotImplementedException` so you implement Redis-backed storage (often hashes: `cart:{sessionId}` with product fields or JSON blobs).

## Product search (`03_RedisSets`)

[`03_RedisSets/Program.cs`](../src/RedisNetCore/03_ASPNETCore/03_RedisSets/Program.cs) seeds data and leaves TODOs for filtering by attributes (colors, sizes). Sets or set intersections fit **faceted** filters.

## Caching external HTTP responses (`01_RedisStrings`)

[`01_RedisStrings/Program.cs`](../src/RedisNetCore/03_ASPNETCore/01_RedisStrings/Program.cs) calls JSONPlaceholder and exposes `/users` and `/users/{id}`. Comments mark **`// TODO: Add cache`** — a typical exercise is to cache JSON strings under keys like `users:all` or `users:{id}` with TTL.

The same project uses **`ICustomerRepository`** and EF Core SQLite for “customers”; Redis can cache read-through results per id.

## Sorted sets and autocomplete (`04_RedisSortedSets`)

The **04** sample includes a **console** program that demonstrates `RedisCompletionService` and sorted-set lexicographic autocomplete. Study [`Infrastructure/RedisCompletionService.cs`](../src/RedisNetCore/03_ASPNETCore/04_RedisSortedSets/Infrastructure/RedisCompletionService.cs) for production-style prefix search; you can later expose similar logic from an API endpoint.

## Optional: `IDistributedCache`

ASP.NET Core’s `IDistributedCache` has a Redis implementation (`AddStackExchangeRedisCache`). It is ideal for opaque byte/string cache segments. For **structured data**, **direct `IDatabase` use** is often clearer (hashes, sets, sorted sets).

## See also

- [dotnet-stackexchange-redis.md](dotnet-stackexchange-redis.md)
- [curriculum.md](curriculum.md)
