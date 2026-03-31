# HyperLogLog

## Opis

HyperLogLog to struktura danych, która szacuje liczność zbioru. 
Jako probabilistyczna struktura danych, zamiast doskonałej dokładności stawia na efektywność.

Implementacja Redis HyperLogLog wykorzystuje do 12 KB i zapewnia błąd standardowy 0,81%.

## Zastosowanie

- unikalna ilość odwiedzin
- ilość pojazdów

## Przykłady


- Dodanie elementów do zbioru
~~~ 
PFADD visitors alice bob carol
~~~

- Pobranie liczności zbioru
~~~ 
PFCOUNT visitors
~~~

- Łączenie zbiorów
~~~ 
PFADD customers alice dan
PFMERGE everyone visitors customers
PFCOUNT everyone
PFCOUNT visitors customers
~~~



Ciekawostka: prefiks przed komendami "PF" są dla uczczenia pamięci francuskiego informatyka [Philippe Flajolet](http://en.wikipedia.org/wiki/Philippe_Flajolet)


http://antirez.com/news/75