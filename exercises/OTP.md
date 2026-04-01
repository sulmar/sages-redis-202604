# Zadanie: System kodów jednorazowych (OTP)

Zaimplementuj backend w .NET umożliwiający generowanie i weryfikację kodów jednorazowych dla użytkowników.

---

## Cel

Stwórz API, które pozwala:

- generować kod dla użytkownika
- przechowywać jego stan
- weryfikować kod z uwzględnieniem reguł bezpieczeństwa

---

## Wymagania funkcjonalne

### 1. Generowanie kodu
- System generuje kod (np. 6-cyfrowy) dla wskazanego użytkownika 
> **Wskazówka:** do generowania losowego kodu możesz użyć [Nanoid](https://github.com/ai/nanoid) (w .NET dostępne są porty / pakiety NuGet inspirowane Nanoid).
- Kod ma ograniczony czas ważności (2 minuty)
- Jeśli kod już istnieje i jest nadal ważny — nie generuj nowego

**Endpoint:**

- `POST /otp/generate`
- Body:

```json
{ "userId": "..." }
```

---

### 2. Przechowywanie stanu

Dla każdego użytkownika system powinien przechowywać:

- aktualny kod
- liczbę prób weryfikacji
- status (np. aktywny, wykorzystany, zablokowany)

---

### 3. Weryfikacja kodu

**Endpoint:**

- `POST /otp/verify`
- Body:

```json
{ "userId": "...", "code": "..." }
```

**Logika:**

1. Sprawdź, czy kod istnieje
2. Sprawdź, czy kod nie wygasł
3. Jeśli kod jest niepoprawny:
   - zwiększ licznik prób
   - po 3 nieudanych próbach zablokuj możliwość dalszej weryfikacji
4. Jeśli kod jest poprawny:
   - oznacz go jako wykorzystany
   - usuń lub unieważnij kod
   - zwróć sukces

---

### 4. Obsługa błędów

System powinien rozróżniać sytuacje:

- brak kodu
- kod wygasł
- kod niepoprawny
- użytkownik zablokowany
- kod już użyty

---

## Scenariusz testowy

1. Generujesz kod dla usera U1
2. Kod ważny 2 minuty
3. 3 błędne próby → blokada
4. Poprawna próba → sukces i usunięcie kodu

---

## Wymagania techniczne

- .NET (Minimal API lub Controller)
- przechowywanie danych w Redis
- rozwiązanie powinno być odporne na równoległe żądania (race conditions)


## Czas realizacji
45 min.

