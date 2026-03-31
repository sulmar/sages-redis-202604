# Curriculum and module map

Projects live under [`src/RedisNetCore/`](../src/RedisNetCore/). Open the solution [`src/RedisNetCore.sln`](../src/RedisNetCore.sln) in your IDE.

Run a project from its folder, for example:

```bash
cd src/RedisNetCore/02_DataStructures/01_RedisStrings
dotnet run
```

Paths below are relative to `src/RedisNetCore/`.

## Part 1 — Introduction

| Module | Path | Focus |
|--------|------|--------|
| Connect | `01_Introduction/01_Connect` | Connecting to Redis; baseline commands (see module `README` and [reference](reference/redis-commands.md)). |
| Pipelining | `01_Introduction/02_Pipelining` | Batching commands to reduce round trips. |

## Part 2 — Data structures (console samples)

| Module | Path | Focus |
|--------|------|--------|
| Strings | `02_DataStructures/01_RedisStrings` | String keys, `SET`/`GET`, counters. |
| Hashes | `02_DataStructures/02_RedisHashes` | Field/value maps, `HSET`/`HGET`. |
| Sets | `02_DataStructures/03_RedisSets` | Uniqueness, set algebra. |
| Sorted sets | `02_DataStructures/04_RedisSortedSets` | Scores, ranges, rankings. |
| Lists | `02_DataStructures/05_RedisLists` | Queues, stacks, `LPUSH`/`RPOP`. |
| Bitmaps | `02_DataStructures/06_RedisBitmaps` | Bit-level counters and flags. |
| Transactions | `02_DataStructures/07_RedisTransactions` | `MULTI`/`EXEC`, optimistic patterns. |
| Pub/Sub | `02_DataStructures/08_RedisPubSub` | Channels and messaging. |
| Streams | `02_DataStructures/09_RedisStreams` | Append-only logs, consumer groups. |
| Geo | `02_DataStructures/10_RedisGeo` | Coordinates, radius queries. |

**Theory and CLI drills:** see [redis/README.md](redis/README.md) and topic files in [redis/](redis/) (Strings, Hashes, Sets, …).

## Part 3 — ASP.NET Core

| Module | Path | Focus |
|--------|------|--------|
| Strings + HTTP cache | `03_ASPNETCore/01_RedisStrings` | Minimal API, external API proxy, SQLite + repository; **TODO** markers for caching. |
| Hashes + session/cart | `03_ASPNETCore/02_RedisHashes` | `IConnectionMultiplexer`, cart-style routes (implement handlers). |
| Sets + faceted search | `03_ASPNETCore/03_RedisSets` | Product filters by attributes (sets / intersections). |
| Sorted sets + autocomplete | `03_ASPNETCore/04_RedisSortedSets` | Lexicographic completion (`RedisCompletionService`, sample data). |

**Integration patterns:** [aspnet-core-integration.md](aspnet-core-integration.md) and [dotnet-stackexchange-redis.md](dotnet-stackexchange-redis.md).

## Suggested order

1. Complete **Part 1**, then **Part 2** in numeric order (or skip ahead if you already know a topic).
2. Use **Part 3** after you are comfortable with `IConnectionMultiplexer` and the relevant data types from Part 2.
