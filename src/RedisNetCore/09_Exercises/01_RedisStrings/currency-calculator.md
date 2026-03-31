# Kalkulator walutowy

## Wprowadzenie
Celem projektu jest stworzenie aplikacji konsolowej umożliwiającej użytkownikowi interakcję w celu obliczenia wartości kwoty w wybranej walucie na podstawie aktualnego kursu pobranego z API Narodowego Banku Polskiego (NBP). Aplikacja powinna ograniczyć liczbę zapytań do API poprzez wykorzystanie mechanizmu przechowywania danych w pamięci.


## Zadanie 
Utwórz aplikację konsolową, która umożliwia użytkownikowi:

1. Wybranie waluty.
2. Podanie kwoty do przeliczenia.
3. Sprawdzenie aktualnego kursu waluty z tabeli A korzystając z API NBP.
4. Przeliczenie podanej kwoty na podstawie pobranego kursu.

Adres usługi API dla pobierania kursu waluty {code} z tabeli {table}:
```
https://api.nbp.pl/api/exchangerates/rates/{table}/{code}/
```

Przykład: Pobranie kursu dla euro (EUR):
```bash
curl -X GET "https://api.nbp.pl/api/exchangerates/rates/a/eur/"
```


## Wymagania
1. Interakcja z użytkownikiem
- Zapytaj użytkownika o kod waluty (np. "EUR", "USD").
- Zapytaj o kwotę, którą chce przeliczyć.
2. Pobieranie kursu waluty
- Pobierz aktualny kurs dla wybranej waluty z tabeli A korzystając z API NBP.
3. Obliczanie wartości
- Oblicz wartość w złotówkach na podstawie podanej kwoty i kursu.
4. Ograniczenie liczby zapytań
- Przechowuj pobrane kursy w pamięci na czas działania aplikacji.
- Używaj zapisanych kursów, o ile nie są przestarzałe.
5. Obsługa błędów
- Poinformuj użytkownika w przypadku wprowadzenia nieprawidłowego kodu waluty lub braku dostępu do API.
- Zapewnij możliwość ponowienia akcji.


