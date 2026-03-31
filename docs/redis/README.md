# Redis concepts (training notes)

**Language:** Polish — theory and CLI examples adapted from the companion *redis-tutorial* documentation.

For the **.NET client API** (`StackExchange.Redis`), see [dotnet-stackexchange-redis.md](../dotnet-stackexchange-redis.md). For how modules map to this course, see [curriculum.md](../curriculum.md).

## Topic index

| File | Topic |
|------|--------|
| [Strings.md](Strings.md) | Strings |
| [Hashes.md](Hashes.md) | Hashes |
| [Sets.md](Sets.md) | Sets |
| [SortedSets.md](SortedSets.md) | Sorted sets |
| [Lists.md](Lists.md) | Lists |
| [HyperLogLog.md](HyperLogLog.md) | HyperLogLog |
| [Geo.md](Geo.md) | Geospatial |
| [Bitmaps.md](Bitmaps.md) | Bitmaps |
| [PubSub.md](PubSub.md) | Pub/Sub |
| [Streams.md](Streams.md) | Streams |
| [Database.md](Database.md) | Database / keyspace |
| [Scripts.md](Scripts.md) | Lua scripts |

---

# Wprowadzenie

Redis posiada wiele struktur danych. Wszystkie zbudowane są na zasadzie klucz-wartość.
Klucz to zawsze tekst, natomiast wartość może mieć różną postać zależnie od struktury.

Poznaj poszczególne struktury! 


## Struktury danych

| Nazwa  | Wartość   |
|---|---|
| **String** | hello world  |
| **Bitmap** | 011011010110111101101101 |
| **Hash**   | {a:"hello", b:"world"} |
| **List**   | [ A > B > C > D] |
| **Set**   | {A, B, C} |
| **Sorted Set**   | {A:1, B:2, C:3} |
| **Geospatial**   | {A: (52.01, 21.05)} |
| **Hyperplog** | {A, B, C ... N}  |
| **Stream** | {id1=time1.seq({a:"foo", a:"bar"})} |
