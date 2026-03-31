# Environment setup

This is a short checklist. Full step-by-step instructions are in the repository [README.md](../README.md) at the project root.

## .NET SDK

Install the [.NET SDK 10](https://dotnet.microsoft.com/en-us/download/dotnet/10.0). All sample projects target **`net10.0`** (see `TargetFramework` in each `.csproj`).

Verify:

```bash
dotnet --version
```

## Redis Stack in Docker (this course)

This repository uses **Redis Stack** (`redis/redis-stack:latest`) so you get Redis plus modules and **RedisInsight** on port **8001**.

From the **repository root**:

```bash
docker compose up -d
```

Ports (see [`docker-compose.yml`](../docker-compose.yml)):

- **6379** — Redis protocol (`redis-cli`, clients).
- **8001** — RedisInsight web UI: [http://localhost:8001/](http://localhost:8001/).

Stop:

```bash
docker compose down
```

### Difference from generic “redis-tutorial” quickstarts

Many tutorials use the plain **`redis`** image (`redis:latest`) with only the core server. Here we intentionally use **Redis Stack** for the extra tooling (Insight) and a stack closer to production exploration. The Redis commands you learn still apply to plain Redis.

## redis-cli

```bash
docker exec -it redis-dotnet redis-cli
```

Test:

```
PING
```

Exit: `EXIT` or Ctrl+D.

## Redis Cluster (optional)

If you use a multi-node cluster for advanced exercises, follow the **Redis Cluster Setup** section in the root [README.md](../README.md). That flow expects a separate compose file (e.g. `docker-compose-redis-cluster.yml`) when it exists in the repo; if the file is not present, use the cluster instructions only when your instructor provides the compose file.
