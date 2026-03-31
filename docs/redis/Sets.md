# Sets

## Opis

Zbiory - nieuporządkowane, unikalne elementy

![An image](https://redis.com/wp-content/uploads/2019/07/data-structures-_sets.svg)

## Zastosowanie
- przechowywanie relacji (znajomi, followers)
- zarządzanie pojazdami (w ruchu, zaparkowane, uszkodzone)

## Przykłady


### Podstawowe

- Dodanie elementów do zbioru
~~~ 
SADD members John
SADD members Bob
SADD members Ann
~~~

- Pobranie elementów ze zbioru
~~~
SMEMBERS members
~~~

- Pobranie ilości elementów
~~~
SCARD members
~~~

- Przesunięcie elementu pomiędzy zbiorami
~~~
SADD online user1 user2 user3
SADD offline user4 user5
SMOVE online offline user1
~~~

- Sprawdzenie czy wartość jest elementem zbioru
~~~
SISMEMBER online user2
~~~

- Usunięcie elementu ze zbioru
~~~
SREM online user1
~~~

- Pobranie losowego elementu ze zbioru 
~~~
SADD users user1 user2 user3 user4 user5 
SRANDMEMBER users
~~~

- Pobranie i usunięcie losowego elementu ze zbioru 
~~~
SPOP users
~~~

### Operacje na zbiorach

- Suma zbiorów
~~~
SUNION online offline
~~~

- Suma zbiorów i zapisanie ich pod nowym kluczem
~~~
SUNIONSTORE all online offline
~~~

- Część wspólna zbiorów
~~~
SADD warszawa company1 company2 company3 company4
SADD bydgoszcz company2 company3 company5 
SINTER warszawa bydgoszcz
~~~

- Część wspólna zbiorów i zapisanie ich pod nowym kluczem
~~~
SINTERSTORE common online offline
~~~

- Różnica zbiorów
~~~
SDIFF warszawa bydgoszcz
~~~

- Różnica zbiorów i zapisanie ich pod nowym kluczem
~~~
SDIFFSTORE diff online offline
~~~

