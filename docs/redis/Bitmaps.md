# Bitmaps


## Opis



## Zastosowania


## Przykłady
- Ustawienie bitu na 1 na określonej pozycji
~~~
SETBIT article1:today 5 1
SETBIT article2:today 5 1
SETBIT article2:today 3 1
SETBIT article2:today 2 1
SETBIT article1:today 2 1
~~~

Pobranie bitu
~~~
GETBIT article1:today 5
~~~

Operacja AND
~~~
BITOP AND readbotharticles article1:today article2:today
GETBIT readbotharticles 2
GETBIT readbotharticles 3
GETBIT readbotharticles 5
~~~

Operacja OR
~~~
BITOP OR readanyarticle article1:today article2:today
GETBIT readanyarticle 2
GETBIT readanyarticle 3
GETBIT readanyarticle 5
~~~

Obliczenie ilości ustawionych bitów na 1
~~~
BITCOUNT readbotharticles
~~~

### Przykład: Śledzenie aktywności użytkownika

1. Ustawienie aktywności użytkownika

Każdy bit w bajcie reprezentuje jeden dzień miesiąca. Jeśli użytkownik był aktywny w określonym dniu, ustawiamy odpowiedni bit na 1.

- Ustaw aktywność dla użytkownika o ID 1234 na 15 stycznia
```
SETBIT user:1234:activity 14 1
```

2. Sprawdzenie aktywności użytkownika

Aby sprawdzić, czy użytkownik był aktywny w danym dniu, użyj polecenia GETBIT.

- Sprawdź, czy użytkownik o ID 1234 był aktywny 15 stycznia
```
GETBIT user:1234:activity 14
```

3. Liczenie dni aktywności

Aby policzyć, ile dni użytkownik był aktywny w danym miesiącu, użyj polecenia BITCOUNT.

- Policz liczbę dni aktywności użytkownika
```
BITCOUNT user:1234:activity
```

4. Przesunięcia bitowe (BITFIELD)

Możesz użyć przesunięć bitowych do manipulacji większymi porcjami danych. Na przykład możesz przesunąć całą historię aktywności na przyszły miesiąc.

- Przesuń dane o jeden bit w prawo
```
BITFIELD user:1234:activity INCRBY i64 0 1
```

### Operacje na parkingu
1. Rezerwacja miejsca parkingowego

Użytkownik zajmuje miejsce nr 5.
```
SETBIT parking 4 1  # Ustaw bit 4 na wartość 1 (miejsce zajęte)
```

2. Sprawdzenie dostępności miejsca

- Sprawdzamy, czy miejsce nr 5 jest wolne:

```
GETBIT parking 4
```

- Wynik: 1 (miejsce zajęte) lub 0 (miejsce wolne)

3. Zwolnienie miejsca parkingowego
Użytkownik opuszcza miejsce nr 5:
```
SETBIT parking 4 0  # Ustaw bit 4 na wartość 0 (miejsce wolne)
```

4. Zliczenie liczby wolnych/zajętych miejsc

- Zliczamy wszystkie zajęte miejsca na parkingu:

```
BITCOUNT parking
```
- Wynik: liczba zajętych miejsc

Aby obliczyć liczbę wolnych miejsc, wystarczy znać całkowitą liczbę miejsc parkingowych:

5. Znalezienie pierwszego wolnego miejsca

Redis umożliwia wyszukanie pierwszego wolnego miejsca parkingowego za pomocą BITPOS:
```
BITPOS parking 0
```

- Wynik: indeks pierwszego wolnego miejsca (np. 4 oznacza miejsce nr 5)

6. Efektywne zarządzanie całym parkingiem

Jeśli parking jest podzielony na sekcje (np. A, B, C), możemy przechowywać stan każdej sekcji jako osobny klucz:

# Stan sekcji A (32 miejsca)
```
SETBIT parking:A 0 1  # Miejsce 1 zajęte
SETBIT parking:A 1 0  # Miejsce 2 wolne
```

- Zliczamy zajęte miejsca w sekcji A:

```
BITCOUNT parking:A
```
- Wynik: liczba zajętych miejsc w sekcji A
