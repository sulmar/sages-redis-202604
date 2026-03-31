# Ranking szachowy

## Wprowadzenie

Celem tego zadania jest stworzenie aplikacji, która zarządza rankingiem szachowym graczy przy użyciu bazy danych Redis. Aplikacja powinna umożliwić dodawanie nowych graczy do rankingu, aktualizowanie ich pozycji oraz wyświetlanie najlepszych graczy na podstawie ich rankingu. 



## Zadanie 

Utwórz aplikację, która realizuje następujące funkcjonalności:

1. **Wczytanie danych:**
3. **Wyświetlenie najlepszych graczy:** 


## Wymagania


1. Załaduj dane graczy z pliku `ranking.txt` do Redis.

```cs
var ranks = File.ReadAllLines("ranking.txt")
    .Skip(1)
    .Select(line => line.Split('\t'))
    .Select(columns => new { Rank = int.Parse(columns[1]), Name = columns[2] });
```

2. Wyświetl najlepszych 10 graczy.



