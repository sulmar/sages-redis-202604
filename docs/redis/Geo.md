# Geospatial


## Opis

Interaktywna wizualizacja geohash: [Geohash Explorer](https://geohash.softeng.co/t5f5) (przykład: `t5f5`).

## Zastosowania


## Przykłady
~~~
GEOADD vehicles 52.361389 19.115556 Vehicle1
GEOADD vehicles 52.361389 19.115556 Vehicle2
GEOADD vehicles 52.361389 19.115556 Vehicle3
GEOADD vehicles 52.361389 19.115556 Vehicle4
~~~

- Pobranie pozycji określonego klucza
~~~
GEOPOS vehicles Vehicle2
~~~

- Obliczenie dystansu pomiędzy dwoma pozycjami
~~~ 
GEODIST vehicles Vehicle1 Vehicle4 km
~~~

- Wyszukanie pozycji w określonym promieniu
~~~
GEORADIUS vehicles 0 0 200 km
~~~

- Usunięcie elementu
~~~
ZREM vehicles Vehicle2
~~~