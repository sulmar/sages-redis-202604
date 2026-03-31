# Config

> Adapted from the *redis-tutorial* notes. See also the official Redis documentation for your server version.

## Limit pamięci

Domyślnie nie jest ustawiony żaden limit i jesteśmy tylko ograniczeni wielkością pamięci komputera.
Natomiast możemy ustawić limit pamięci na 3 sposoby:

1. Poprzez linię poleceń

```bash
docker run --name redis -d -p 6379:6379 --maxmemory 4mb 
```

2. W pliku konfiguracyjnym _redis.conf_

```
maxmemory 4mb
```

3. Podczas działania za pomocą polecenia

```
CONFIG SET maxmemory 4mb
```

Sam silnik REDISa bez kluczy zajmuje ok. 3 MB. W powyższym przykładzie z limitem 4 MB na klucze zostaje ok. 1 MB.

**Uwaga:** nie ustawiaj mniejszego limitu niż ok. 3 MB dla sensownej pracy.

- Wyłączenie limitu pamięci (przywrócenie do domyślnego ustawienia):

```
CONFIG SET maxmemory 0
```

- Sprawdzenie zajętości pamięci:

```
INFO memory
```
