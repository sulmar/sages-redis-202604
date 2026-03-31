# Pub/Sub


## Opis



## Zastosowania


## Przykłady

- Utworzenie subskrypcji
~~~
subscribe sensors:temp1
~~~

- Wysłanie wiadomości
~~~
publish sensors:temp1 54.21
~~~

- Usunięcie subskrypcji
~~~
UNSUBSCRIBE
~~~

Utworzenie subskrypcji ze wzorcem 
~~~
psubscribe sensors.temp*
~~~

- Obsługiwane wzorce
~~~
? - pojedynczy znak
* - dowolny ilość znaków
[ae] - zbiór znaków
~~~