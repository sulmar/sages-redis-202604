# Lists


## Opis

Uporządkowane zbiory elementów. Każdemu elementowi można przypisać wagę (score).

## Zastosowania
- kolejka
- stos
- topN
- ostatnie wiadomości


## Przykłady
- Wstawienie elementów na początek listy
~~~
LPUSH people "John"
LPUSH people "Tom"
LPUSH people "Jenny"
~~~

- Pobranie wszystkich elementów
~~~
 LRANGE people 0 -1
~~~


- Pobranie zakresu elementów
~~~
 LRANGE people 1 2
~~~

- Pobranie elementu z listy o podanym indeksie
~~~
LINDEX people 2
~~~

- Ustawienie wartości pod podanym indeksem
~~~
LSET people 1 Jerry
~~~

- Wstawienie elementów na koniec listy
~~~
RPUSH people Harry
~~~

- Pobranie ilości elementów listy
~~~
LLEN people
~~~

- Pobranie i usunięcie elementu z góry
~~~
LPOP people
~~~

- Pobranie i usunięcie elementu z dołu
~~~
RPOP people 
~~~

- Wstawienie elementu do listy
~~~
LINSERT people BEFORE "John" "Kate"
~~~

Usunięcie określonej ilości elementów z listy począwszy od podanej wartości
~~~
LREM people 2 John 
~~~

Wycina fragment listy
~~~
LTRIM
~~~

- Usunięcie ostatniego elementu z listy, dołączenie go do innej listy i zwrócenie

~~~
LPUSH ordered "order-1"
LPUSH ordered "order-2"
LPUSH ordered "order-3"
RPOPLPUSH ordered delivered
~~~