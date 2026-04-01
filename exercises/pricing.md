# Zadanie: Cennik okien (nieregularne zakresy)

Klient dostarczył cennik okien w postaci macierzy:

- **kolumny** → zakresy szerokości (X)
- **wiersze** → zakresy wysokości (Y)
- **na przecięciu** → cena

---

## Wejście (przykład cennika)

### Zakresy

| Y \\ X | 0–100 | 100–200 | powyżej 200 |
|--------|-------|---------|-------------|
| 0–80   | 90    | 140     | 190         |
| 80–150 | 110   | 160     | 210         |
| 150–260 | 130  | 180     | 230         |
| powyżej 260 | 150 | 200 | 250     |

**Uwagi:**

- zakresy Y są nieregularne
- ostatni zakres = „powyżej 260”

---

## Wymagania funkcjonalne

### 1. Zapis cennika

System powinien umożliwiać zapis:

- zakresów X
- zakresów Y (nieregularnych)
- cen dla przecięć

**Endpoint:** `POST /pricing`

```json
{
  "xRanges": [100, 200],
  "yRanges": [80, 150, 260],
  "prices": [
    [90, 140, 190],
    [110, 160, 210],
    [130, 180, 230],
    [150, 200, 250]
  ]
}
```

**Interpretacja:**

- zakresy to **górne granice**
- ostatni zakres = „powyżej ostatniej wartości”

---

### 2. Pobranie ceny

**Endpoint:** `GET /pricing?x=150&y=140`

---

## Scenariusze testowe

| Warunek | Oczekiwany zakres X | Oczekiwany zakres Y | Cena |
|---------|---------------------|----------------------|------|
| `x = 50`, `y = 50` | 100 | 80 | 90 |
| `x = 150`, `y = 140` | 200 | 150 | 160 |
| `x = 150`, `y = 200` | 200 | 260 | 180 |
| `x = 250`, `y = 300` | powyżej 200 | powyżej 260 | 250 |

---

## Wymagania techniczne

- **.NET** (Minimal API lub Controller)
- **Redis** jako storage
- brak pełnego skanowania danych przy zapytaniu

---

## Dodatkowe pytanie (obowiązkowe)

Jaka jest **złożoność obliczeniowa** Twojego rozwiązania?

Opisz:

- złożoność wyszukania zakresu X
- złożoność wyszukania zakresu Y
- złożoność końcowego odczytu ceny

Czy Twoje rozwiązanie jest:

- O(n)?
- O(log n)?
- O(1)?

Uzasadnij:

- od czego zależy wydajność?
- jak zmieni się przy 10 vs 10 000 zakresów?
