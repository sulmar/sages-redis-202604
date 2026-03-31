# Hashes


## Opis
Typy rekordowy przechowywany jako para pole-wartość.


## Zastosowanie
- koszyk zakupowy

## Przykłady

- Dodanie wartości
~~~
HSET user:marcin name "Marcin Sulecki"
HSET user:marcin email marcin.sulecki@gmail.com
HSET user:marcin score 10
~~~

- Dodanie wielu wartości
~~~
HMSET user:john name "John Smith" email john@gmail.com score 5
~~~

- Pobranie wybranego pola
~~~
HGET user:marcin email
~~~

- Pobranie wybranych pól
~~~
HMGET user:marcin name score
~~~

- Pobranie wszystkich pól
~~~
HGETALL user:marcin
~~~

- Pobranie kluczy
~~~
HKEYS user:marcin
~~~

- Pobranie wartości
~~~
HVALS user:marcin
~~~

- Inkrementacja pola
~~~
HINCRBY user:marcin score 5
~~~

- Usunięcie klucza
~~~
HDEL user:john
~~~
