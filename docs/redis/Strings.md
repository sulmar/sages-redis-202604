# Strings

## Opis

Strings — struktura danych przechowująca dane w tablicy. Możesz przechowywać tekst, liczby całkowite, liczby zmiennoprzecinkowe, obrazki JPEG lub zserializowane obiekty.

![An image](https://redis.com/wp-content/uploads/2019/07/data-structures-_strings.svg)

## Zastosowanie
- sesje
- pamięć podręczna
- token
- rozproszone blokady
- ograniczenie ilości zapytań

## Przykłady

### Wartości tekstowe

- Ustawienie wartości klucza (string)
~~~ 
SET message Hello
~~~

- Pobranie wartości klucza
~~~ 
GET message
~~~

- Ustawienie wartości klucza ze spacjami
~~~ 
SET message "Hello World"
~~~

- Nadpisanie zawartości klucza
~~~ 
SET message "Hello Redis"
~~~ 

- Sprawdzenie czy klucz istnieje
~~~ 
EXISTS message
~~~ 

- Wyświetlenie wszystkich kluczy
~~~ 
KEYS *
~~~


- Zmiana nazwy klucza
~~~ 
RENAME message greetings
~~~

- Usunięcie klucza
~~~ 
DEL greetings
~~~

- Usunięcie klucza bez blokowania
~~~
UNLINK greetings
~~~

- Dodawanie wartości do klucza
~~~ 
SET message Hello
APPEND message " World"
~~~

- Pobranie zakresu wartości
~~~
GETRANGE message 0 4
GETRANGE message 6 10
~~~


### Wartości liczbowe

- Ustawienie wartości klucza (liczba całkowita)
~~~ 
SET points 100
GET points
~~~ 

- Inkrementacja wartości
~~~ 
INCR points
GET points
~~~ 

- Dekrementacja wartości o podaną wartość
~~~ 
DECRBY points 10
GET points
~~~ 

- Ustawienie wartości klucza (liczba rzeczywista)
~~~ 
SET temp 21.01
GET temp
~~~

- Inkrementacja liczby rzeczywistej
~~~
INCRBYFLOAT temp 0.5
~~~

- Dekrementacja liczby rzeczywistej
~~~
INCRBYFLOAT temp -0.25
~~~

### Przestrzenie nazw kluczy

- Przestrzenie nazw kluczy
~~~ 
SET defaulttheme light
GET defaulttheme
~~~

~~~ 
SET user:1:theme dark
GET user:1:theme
~~~ 

~~~ 
SET user:2:theme light
GET user:1:theme
~~~ 

### Wiele kluczy

- Ustawienie wielu kluczy
~~~ 
MSET user:3:theme dark user:4:theme dark user:5:theme light
~~~ 

~~~ 
MGET user:3:theme user:4:theme user:5:theme
~~~ 

~~~ 
KEYS user:*:theme
~~~ 

~~~ 
SET server:name server1
GET server:name
SET server:port 5000
GET server:port
~~~ 

### Opcje

- Ustawienie wartości klucza tylko jeśli wcześniej nie istniał
~~~ 
SET token Lorem NX
SET token Ipsum NX
~~~ 

- wersja skrócona

~~~ 
DEL token
SETNX token Lorem
SETNX token Ipsum

~~~ 

- Ustawienie wartości tylko istniejącego klucza. Nie tworzy nowego klucza.
~~~ 
SET greetings "Hello World" XX
~~~ 


### Klucze tymczasowe

- Ustawienie wartości klucza tymczasowego
~~~
SET token "ABC123" EX 60
~~~

- Pobranie pozostałego czasu życia klucza
~~~
TTL token
~~~

- Ustawienie wartości klucza tymczasowego (składnia skrócona)
~~~
SETEX token 60 "ABC123"
TTL token
~~~

- Ustawienie istniejącego wygaśnięcia klucza
~~~
SET token "Lorem"
EXPIRE token 60
TTL token
~~~

- Nadpisanie wartości klucza tymczasowego z zachowaniem czasu
~~~
SET token "Ipsum" KEEPTTL
~~~
Bez parametru KEEPTTL klucz zostałby nadpisany i ustawiony czas odliczałbym od początku.

- Ustawienie klucza tymczasowego, który wygaśnie o dokładnie podanej dacie i godzinie.
~~~
SET ticket "redis"
EXPIREAT ticket 1573041600
TTL ticket
~~~
Czas podawany jest w formacie Unix timestamp (ilość sekund od 1970-01-01) 
Wskazówka: skorzystaj z konwertera [epochconverter](https://www.epochconverter.com/)

- Utrwalenie tymczasowego klucza (usunięcie czasu wygaśnięcia)
~~~
PERSIST greeting
TTL greeting
~~~


### Diagnostyka

- Ustawienie reguły
~~~
CONFIG SET maxmemory-policy allkeys-lfu
~~~

- Pobranie częstotliwości dostępu do klucza
~~~
OBJECT FREQ mykey
~~~

- Sprawdzenie rozmiaru klucza
~~~
MEMORY USAGE mykey
~~~