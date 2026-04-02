# Zadanie szkoleniowe: Monitorowanie ekspresów kawowych z wykorzystaniem Redis

## Wprowadzenie

Firma serwisująca ekspresy kawowe chce usprawnić proces monitorowania ich stanu technicznego. Każdy ekspres przechodzi regularne testy diagnostyczne, które pozwalają wykryć potencjalne usterki i zapobiec awariom u klientów.

Twoim zadaniem jest zaprojektowanie systemu, który umożliwi przechowywanie oraz analizowanie wyników takich testów z wykorzystaniem Redis.

---

## Cel zadania

Zbuduj rozwiązanie, które:

- zapisuje wyniki testów diagnostycznych dla wielu ekspresów,
- pozwala analizować ich stan techniczny,
- umożliwia szybkie sprawdzenie, czy dany ekspres działa poprawnie.

---

## Zakres funkcjonalny

### 1. Rejestrowanie wyników testów

Każdy ekspres może przejść zestaw testów diagnostycznych, takich jak:

- sprawdzenie zasilania (powerOk),
- weryfikacja minimalnej temperatury (temperatureOk),
- test działania pompy (pumpOk),
- test działania młynka (grinderOk).

Wyniki tych testów powinny być zapisywane w Redis w sposób umożliwiający ich późniejsze odczytywanie i analizę.

---

### 2. Analiza stanu technicznego

System powinien umożliwiać:

- sprawdzenie wyników testów dla konkretnego ekspresu,
- określenie, czy ekspres przeszedł wszystkie testy,
- identyfikację testów, które zakończyły się niepowodzeniem,
- analizę wielu ekspresów (np. znalezienie wszystkich ekspresów z problemem pompy).

---

## Wymagania funkcjonalne

- System obsługuje wiele ekspresów (każdy posiada unikalny identyfikator).
- Dla każdego ekspresu można zapisać wyniki wielu testów.
- Wyniki testów zawierają informację, czy test zakończył się sukcesem oraz ewentualne dodatkowe dane (np. zmierzona temperatura).
- System pozwala na agregację wyników i ocenę stanu ekspresu.

---

## Przykładowe przypadki testowe (bez kodu)

### Przypadek 1 – Ekspres w pełni sprawny

Ekspres `EXP-001`:

- Zasilanie: OK
- Temperatura: 92°C (w normie)
- Pompa: OK
- Młynek: OK

**Wynik analizy:** ekspres sprawny – wszystkie testy zakończone sukcesem.

---

### Przypadek 2 – Problem z temperaturą

Ekspres `EXP-002`:

- Zasilanie: OK
- Temperatura: 78°C (poniżej minimum)
- Pompa: OK
- Młynek: OK

**Wynik analizy:** ekspres niesprawny – niezaliczony test temperatury.

---

### Przypadek 3 – Awaria pompy i młynka

Ekspres `EXP-003`:

- Zasilanie: OK
- Temperatura: 90°C
- Pompa: FAIL
- Młynek: FAIL

**Wynik analizy:** ekspres niesprawny – problemy z pompą i młynkiem.

---

### Przypadek 4 – Brak zasilania

Ekspres `EXP-004`:

- Zasilanie: FAIL
- Temperatura: brak danych
- Pompa: brak danych
- Młynek: brak danych

**Wynik analizy:** ekspres niesprawny – brak zasilania uniemożliwia wykonanie testów.

---

### Przypadek 5 – Analiza zbiorcza

Dla zestawu ekspresów system powinien umożliwić odpowiedzi na pytania:

- Ile ekspresów ma problem z pompą?
- Które ekspresy nie spełniają wymagań temperatury?
- Które ekspresy są w pełni sprawne?

---

## Wymagania techniczne

- **.NET** (Minimal API lub Controller)
- **Redis** jako magazyn danych
- zaprojektuj strukturę kluczy i typów danych Redis tak, aby zapytania analityczne (w tym zbiorcze) były wykonalne bez niepotrzebnego pełnego skanowania całej bazy, o ile to możliwe

---

## Dodatkowe pytanie (obowiązkowe)

Opisz w kilku zdaniach:

- jakie typy struktur Redis (np. hash, set, sorted set, stream) wybrałeś i dlaczego,
- jak rozwiązujesz przypadek „brak danych” dla testu zależnego od zasilania,
- jak ograniczasz koszt zapytań przy rosnącej liczbie ekspresów.
