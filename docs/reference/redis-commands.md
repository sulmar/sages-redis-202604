# Commands

> Polish command cheat sheet adapted from the *redis-tutorial* reference. For context, see the module `README.md` files under `src/RedisNetCore` and the theory notes in [redis/](../redis/README.md).

## Connection

| Komenda  | Opis   |
|---|---|
| **AUTH** [password] | Autentykacja do serwera  |
| **PING** [message] | Ping do serwera  |
| **ECHO** message | Wyświetlenie komunikatu |
| **SELECT** index | Zmiana bazy danych |
| **SWAPDB** index index | Zamiana baz danych |
| **QUIT** | Zamknięcie połączenia |
| **INFO** [section] | Wyświetlenie informacji |

## Podstawowe

| Komenda  | Opis   |
|---|---|
| **EXISTS** key  | Sprawdzenie czy klucz istnieje |
| **RENAME** key newkey | Zmiana nazwy klucza |
| **MOVE** key db | Przesunięcie klucza do innej bazy danych |
| **DEL** key  | Usunięcie klucza  |
| **RANDOMKEY** | Pobranie losowego klucza |
| **DUMP** key  | Pobranie serializowanej wartości klucza  |
| **TYPE** key  | Pobranie typu klucza |
| **EXPIRE** key seconds  | Ustawienie czasu wygaśnięcia klucza |
| **EXPIREAT** key timestamp  | Ustawienie daty wygaśnięcia klucza |
| **TTL** key | Pobranie pozostałego czasu do wygaśnięcia klucza w sekundach |
| **PTTL** key | Pobranie pozostałego czasu do wygaśnięcia klucza w milisekundach 
| **PERSIST** key | Wyłączenie wygasania klucza |
| **KEYS** pattern | Pobranie wszystkich nazw kluczy według wzorca |
| **SCAN** cursor [MATCH pattern] [COUNT count] [TYPE type] | Pobranie określonej ilości nazw kluczy na podstawie wzorca lub typu |


## Strings

| Komenda  | Opis   |
|---|---|
| **SET** key value | Ustawienie wartości klucza  |
| **GET** key  | Pobranie wartości klucza |
| **GETRANGE** key start end  | Pobranie fragmentu wartości klucza |
| **APPEND** key value | Dołączenie wartości do wartości klucza |
| **MSET** key1 value1 [key2 value2] | Ustawienie wielu wartości kluczy  |
| **MGET** key1 [key2] | Pobranie wielu wartości kluczy  |
| **STRLEN** key | Pobranie długości wartości klucza  |
| **INCR** key | Zwiększenie wartości klucza o 1  |
| **INCRBY** key increment | Zwiększenie wartości klucza o podaną wartość |
| **INCRBYFLOAT** key increment | Zwiększenie wartości klucza o podaną wartość ułamkową |
| **DECR** key | Zmniejszenie wartości klucza o 1 |
| **DECRBY** key increment | Zmniejsze wartości klucza o podaną wartość |


## Hashes

| Komenda  | Opis   |
|---|---|
| **HSET** key field value | Ustawienie wartości pola danego klucza  |
| **HMSET** key field value | Ustawienie wielu wartości pola danego klucza  |
| **HGET** key field  | Pobranie wartości pola danego klucza |
| **HMGET** key field [field ...] | Pobranie wartości wybranych pól danego klucza |
| **HGETALL** key  | Pobranie wszystkich pól danego klucza |
| **HKEYS** key  | Pobranie kluczy danego klucza |
| **HVALS** key  | Pobranie wartości danego klucza |
| **HINCRBY** key field increment  | Inkrementacja wartości pola |
| **HDEL** key field | Usunięcie pola danego klucza |
| **HEXISTS** key field | Sprawdzenie czy pole istnieje w danym kluczu |
| **HSCAN** key cursor | Pobranie pól i wartości kluczy |
| **HSTRLEN** key field | Pobranie długości wartości pola |


## Sets

| Komenda  | Opis   |
|---|---|
| **SADD** key member [member] | Dodanie elementu do zbioru  |
| **SMEMBERS** key | Pobranie elementów ze zbioru |
| **SCARD** key | Pobranie ilości elementów w zbiorze |
| **SMOVE** source destination member | Przesunięcie elementu pomiędzy zbiorami |
| **SISMEMBER** key member | Sprawdzenie czy wartość jest elementem zbioru |
| **SREM** key member | Usunięcie elementu ze zbioru |
| **SPOP** key [count] | Usunięcie i pobranie pojedyńczego lub większej ilości losowych elementów ze zbioru |
| **SRANDMEMBER** key [count] | Pobranie pojedyńczego lub większej ilości losowych elementów ze zbioru |
| **SUNION** key [key] | Suma zbiorów |
| **SUNIONSTORE** destination key [key] | Suma zbiorów i zapisanie ich pod nowym kluczem |
| **SINTER** key [key] | Część wspólna zbiorów |
| **SINTERSTORE** desitination key [key] | Część wspólna zbiorów i zapisanie ich pod nowym kluczem |
| **SDIFF** key [key] | Różnica zbiorów |
| **SDIFFSTORE** desitination key [key] | Różnica zbiorów i zapisanie ich pod nowym kluczem |

## Sorted Sets

| Komenda  | Opis   |
|---|---|
| **ZADD** key score member | Dodanie elementu do zbioru  |
| **ZREM** key member | Usunięcie elementu ze zbioru |
| **ZINCRBY** key increment member | Zwiększego wartości klucza w zbiorze  |
| **ZSCORE** key member | Pobranie wyniku elementu ze zbioru |
| **ZSCAN** key cursor | Pobranie elementów ze zbioru |
| **ZCARD** key | Pobranie ilości elementów ze zbioru |
| **ZCOUNT** key min max | Pobranie ilości elementów ze zbioru, których wynik jest pomiędzy wartościami min i max |
| **ZRANK** key member | Pobranie rankingu na podstawie wyniku od najniższej wartości |
| **ZREVRANK** key member | Pobranie rankingu na podstawie wyniku od najwyższej wartości |
| **ZRANGEBYSCORE** key min max [withscores] | Pobranie elementów w zakresie rankingu |
