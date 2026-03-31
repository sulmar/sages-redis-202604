


# Redis for .NET Developers

## Introduction

Welcome! This is the course repository for the Redis for .NET Developers.

To take this course you'll need the following.

1. The [.NET SDK 10](https://dotnet.microsoft.com/en-us/download/dotnet/10.0).
2. Clone this git repository from GitHub.
3. Get a [Redis Stack](https://redis.io/docs/stack/) instance running locally in docker.


## Clone the Course Git Repository

```
git clone https://github.com/sulmar/redis-dotnet-course-template.git
```

## Redis Setup

**Option 1** below uses the official Redis image [`redis/redis`](https://hub.docker.com/r/redis/redis) with port **6379** only. **Options 2 and 3** use [Redis Stack](https://redis.io/docs/stack/) (`redis/redis-stack:latest`) and also expose **8001** (RedisInsight web UI).

Pick one of the options below.

### Option 1: Docker CLI only (`docker pull` / `docker run`)

Use plain Docker commands (no Compose file):

1. Pull the image:

```bash
docker pull redis/redis
```

2. Run the container (name `redis-dotnet`, port **6379**):

```bash
docker run -d --name redis-dotnet -p 6379:6379 redis/redis
```

3. When you are done, stop and remove the container:

```bash
docker stop redis-dotnet
docker rm redis-dotnet
```

If a container named `redis-dotnet` already exists from a previous run, remove it first (`docker rm -f redis-dotnet`) or choose another `--name`.

### Option 2: Docker Compose (recommended)

From the repository root, start the stack in the background:

```bash
docker-compose up -d
```

Stop and remove the container:

```bash
docker-compose down
```

### Option 3: Docker Compose V2 (`docker compose` plugin)

If you use Docker’s built-in Compose plugin (no hyphen), from the repository root:

```bash
docker compose up -d
```

Stop and remove:

```bash
docker compose down
```

### Verify the container is running

```bash
docker ps
```

You should see output similar to the following (with **Option 1**, the `IMAGE` is `redis/redis` and `PORTS` lists only **6379**; with **Options 2 or 3**, the image is `redis/redis-stack:latest` and **8001** is mapped too):

```
CONTAINER ID   IMAGE                      COMMAND            CREATED         STATUS        PORTS                   
                         NAMES
13eb07093f67   redis/redis-stack:latest   "/entrypoint.sh"   10 seconds ago   Up 1 second   0.0.0.0:6379->6379/tcp, 0.0.0.0:8001->8001/tcp   redis-dotnet
```

Leave this container running while you work through the course.

## Connect to Redis

### Option 1: Use the redis-cli
```bash
docker exec -it redis-dotnet redis-cli
```

You can check the status of connection with the following command:

```bash
PING
```

Leave this server:
```bash
EXIT
```


### Option 2: Use the Web Interface

Only if you started **Redis Stack** via Docker Compose above (**Redis Setup** options 2 or 3). Open the browser at `http://localhost:8001/`.



## Redis Cluster Setup

- Create Redis Cluster:
```bash
docker-compose -f docker-compose-redis-cluster.yml up -d
```

- Connect to master

```bash
docker exec -it redis_1 redis-cli -c
```
**note: remember about -c parameter!**

- Display information about Redis Cluster
```
CLUSTER INFO
```

tip: make sure `cluster_state:ok`

- Display node information with ranges of hash slots:
```
CLUSTER NODES
```

- Display information about slots
```
 CLUSTER SHARDS
```

- When you want to remove cluster, use this command:

```bash
docker-compose -f docker-compose-redis-cluster.yml down
```
