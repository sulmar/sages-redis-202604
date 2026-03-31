# Streams


## Opis



## Zastosowania


## Przykłady

- Pisanie do strumienia
~~~
xadd events * user john action login
xadd events * user john action visit page index.htm
xadd events * user john action purchase item computer
xadd events * user john action purchase item monitor
xadd events * user john action paid amount 1000
~~~

- Czytanie ze strumienia
~~~
xread count 2 streams events 0
xread count 2 streams events 1572983745546-0
~~~