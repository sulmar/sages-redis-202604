# Sorted Sets

## Opis

Uporządkowane zbiory elementów. Każdemu elementowi można przypisać wagę (score).

## Zastosowania
- listy rankingowe
- wyszukiwarki

## Przykłady

- Dodanie elementów
~~~
ZADD skills:john 100 redis
ZADD skills:john 99 sql
ZADD skills:john 94 nosql
ZADD skills:john 70 csharp
ZADD skills:john 30 javascript
ZADD skills:john 1 python
ZADD skills:john -10 basic
~~~

- Pobranie ilości elementów
~~~
ZCARD skills:john 
~~~

- Pobranie rankingu podanego klucza 
~~~
ZSCORE skills:john redis
~~~


### Przedziały

- Pobranie elementów wg rankingu
~~~
ZRANGEBYSCORE skills:john 50 100
~~~

- Przedział lewostronnie otwarty (wartości > 1 i <=100)
~~~
ZRANGEBYSCORE skills:john (1 100
~~~

- Przedział prawostronnie otwarty (wartości >= 1 i <100)
~~~
ZRANGEBYSCORE skills:john 1 (100
~~~

- Przedział lewostronnie i prawostronnie otwarty (wartości > 1 i <100)
~~~
ZRANGEBYSCORE skills:john (1 (100
~~~

- Przedział od minus nieskończoności do 100
~~~
ZRANGEBYSCORE skills:john -inf 100
~~~

- Dodawanie wartości nieskończonych
~~~
ZADD skills:john -inf birds
ZADD skills:john +inf football
ZRANGEBYSCORE skills:john -inf +inf
ZRANGEBYSCORE skills:john (-inf (+inf
~~~

- Przedział od minus nieskończoności do plus nieskończoności
~~~
ZRANGEBYSCORE skills:john -inf +inf
~~~

- Zwiększenie rankingu 
~~~ 
ZINCRBY skills:john 1 nosql  
~~~

- Usunięcie elementu ze zbioru
~~~
ZREM skills:john javascript
~~~

- Agregacja zbiorów
~~~
ZADD rezults:mens:100m:round:1 9.99 Runner1 10.00 Runner2 10.03 Runner3
ZADD rezults:mens:100m:round:2 10.99 Runner1 9.99 Runner2 10.03 Runner3
ZUNION 2 rezults:mens:100m:round:1 rezults:mens:100m:round:2 AGGREGATE MIN WITHSCORES 
~~~


- Przykład
Bieg mężczyzn na 100m.
Zawodnik Runner3 został zdyskwalifikowany zatem przyjmujemy +inf
~~~
ZADD rezults:mens:100m:final 9.99 Runner1 10.00 Runner2 +inf Runner3
~~~

- Wyświetlenie wyników wszystkich biegaczy
~~~
ZRANGEBYSCORE rezults:men100m:final -inf +inf WITHSCORES
~~~

- Wyświetlenie wyników, którzy ukończyli bieg
~~~
ZRANGEBYSCORE rezults:men100m:final -inf (+inf WITHSCORES
~~~