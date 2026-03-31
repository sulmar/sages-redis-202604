# Course documentation

Training materials for **Redis for .NET Developers** live alongside the code in this repository.

## Contents

| Document | Description |
|----------|-------------|
| [curriculum.md](curriculum.md) | Module map: folders in `src/RedisNetCore` and learning goals |
| [setup.md](setup.md) | Environment: Docker (Redis Stack), ports, CLI, RedisInsight |
| [redis/](redis/README.md) | Redis concepts and CLI-oriented guides (Polish; adapted from the *redis-tutorial* companion material) |
| [dotnet-stackexchange-redis.md](dotnet-stackexchange-redis.md) | StackExchange.Redis: `ConnectionMultiplexer`, `IDatabase`, patterns |
| [aspnet-core-integration.md](aspnet-core-integration.md) | ASP.NET Core: registering Redis, minimal APIs, caching hooks |
| [reference/redis-commands.md](reference/redis-commands.md) | Command cheat sheet (Polish) |
| [reference/redis-config.md](reference/redis-config.md) | Essential configuration (e.g. memory limits) |

## Prerequisites

- [.NET SDK 10](https://dotnet.microsoft.com/en-us/download/dotnet/10.0) matching the course projects (`net10.0` — see `TargetFramework` in each `.csproj` if this changes).
- [Docker](https://docs.docker.com/get-docker/) for local Redis Stack.
- Clone of this repository and the solution file [`src/RedisNetCore.sln`](../src/RedisNetCore.sln).

## Environment setup (short)

From the repository root:

```bash
docker compose up -d
```

Details: [setup.md](setup.md) and the root [README.md](../README.md).
