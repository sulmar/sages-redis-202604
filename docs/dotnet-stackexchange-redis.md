# StackExchange.Redis essentials

The samples under `src/RedisNetCore/03_ASPNETCore` use the [StackExchange.Redis](https://github.com/StackExchange/StackExchange.Redis) package (see `PackageReference` in the corresponding `.csproj` files). Console modules under `02_DataStructures` are a good place to experiment before wiring Redis into ASP.NET Core.

## Connection

Create a single **`ConnectionMultiplexer`** per process (it is expensive and thread-safe). Prefer **`ConnectAsync`** in async startup paths.

```csharp
var muxer = await ConnectionMultiplexer.ConnectAsync("localhost:6379");
```

Configuration string can include password, SSL, and multiple endpoints for cluster/sentinel; see the library documentation for the full URI format.

Resolve a database (logical DB index, default **0**):

```csharp
IDatabase db = muxer.GetDatabase();
```

## Keys and values

- Redis keys are **strings** (binary-safe).
- Values are **`RedisValue`** (implicit conversions from `string`, `byte[]`, numerics).
- Prefer **key naming conventions** with colons, e.g. `user:42:profile`, `cart:session-id:items`.

## Core APIs by type

Rough mapping from Redis concepts (see [redis/](redis/)) to `IDatabase` usage:

| Redis type | Typical methods |
|------------|-----------------|
| String | `StringSet`, `StringGet`, `StringIncrement`, `StringAppend` |
| Hash | `HashSet`, `HashGet`, `HashGetAll`, `HashIncrement` |
| Set | `SetAdd`, `SetMembers`, `SetCombine`, `SetContains` |
| Sorted set | `SortedSetAdd`, `SortedSetRangeByRank`, `SortedSetRangeByScore`, `SortedSetCombine` |
| List | `ListLeftPush`, `ListRightPop`, `ListRange` |
| Bitmap | `StringSetBit`, `StringGetBit`, `StringBitCount` |
| Pub/Sub | `ISubscriber` from `muxer.GetSubscriber()` |
| Stream | `StreamAdd`, `StreamRead`, `StreamConsumerGroup` (API surface evolves with Redis version) |

All network I/O is **asynchronous** where `Async` overloads exist; use them in ASP.NET Core request paths.

## Batching and pipelines

- **`IBatch`**: queue multiple operations, then `batch.Execute()` once.
- **`IConnectionMultiplexer` pipelining** is built into the multiplexer; batches are the usual high-level tool for explicit pipelines in application code.

Maps to the **Pipelining** module: `01_Introduction/02_Pipelining`.

## Transactions

`IDatabase.CreateTransaction()` provides a **`RedisTransaction`** with `AddCondition` and `ExecuteAsync` for optimistic checks (`WATCH`-style behavior). See `02_DataStructures/07_RedisTransactions`.

## Disposal

Hold the multiplexer for the application lifetime; call **`Dispose`** on shutdown (singleton registration handles this in DI).

## Where to look in this repo

Paths are relative to [`src/RedisNetCore/`](../src/RedisNetCore/).

| Area | Location |
|------|-----------|
| Singleton registration | `03_ASPNETCore/02_RedisHashes/Program.cs`, `03_ASPNETCore/03_RedisSets/Program.cs` |
| Sorted-set autocomplete | `03_ASPNETCore/04_RedisSortedSets/Infrastructure/RedisCompletionService.cs` |
| Data-structure playgrounds | `02_DataStructures/*` |
