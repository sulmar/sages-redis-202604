# 🔐 Redis ACL – przykłady i zastosowanie

## 🧠 Wprowadzenie

Redis ACL (Access Control List) pozwala:

- tworzyć użytkowników
- przypisywać im hasła
- ograniczać dostęp do kluczy i komend

Dostępne od Redis 6+.

---

## 📦 Podstawowe pojęcia

- **user** – użytkownik Redis
- **password** – hasło
- **commands** – dozwolone operacje
- **key patterns (`~`)** – dostęp do kluczy
- **categories (`@`)** – grupy komend

---

## 🔥 Kategorie komend

| Kategoria | Opis |
|-----------|------|
| `@read` | odczyt |
| `@write` | zapis |
| `@keyspace` | operacje na kluczach |
| `@admin` | administracja |
| `@dangerous` | np. FLUSHALL |

---

## 🚀 1. Utworzenie użytkownika (pełny dostęp)

```redis
ACL SETUSER appuser on >password123 ~* +@all
```

### 🔍 Co oznacza

- `on` → użytkownik aktywny
- `>password123` → hasło
- `~*` → dostęp do wszystkich kluczy
- `+@all` → wszystkie komendy

---

## 🔐 2. Użytkownik tylko do odczytu

```redis
ACL SETUSER readonly on >readonlypass ~* +@read -@write
```

**Może:**

- GET, MGET, EXISTS

**Nie może:**

- SET, DEL, INCR

---

## 📁 3. Dostęp tylko do określonych kluczy

```redis
ACL SETUSER orderservice on >orderpass ~orders:* +@all
```

**Dostęp tylko do:**

- `orders:1`
- `orders:abc`

**Brak dostępu do:**

- `users:1`
- `payments:1`

---

## ⚙️ 4. Ograniczenie do wybranych komend

```redis
ACL SETUSER limited on >pass ~* +GET +SET -DEL -FLUSHALL
```

**Może:**

- GET, SET

**Nie może:**

- DEL, FLUSHALL

---

## 🔥 5. Zablokuj niebezpieczne komendy

```redis
ACL SETUSER app -FLUSHALL -FLUSHDB -CONFIG -SHUTDOWN
```

### 🔥 Najbardziej niebezpieczne

- `FLUSHALL`
- `FLUSHDB`
- `CONFIG`
- `SHUTDOWN`
- `KEYS` (wydajność)

---

## 🚫 6. Wyłączenie użytkownika

```redis
ACL SETUSER appuser off
```

---

## 🔍 7. Lista użytkowników

```redis
ACL GETUSER appuser
```

---

## 🔑 8. Logowanie

```redis
AUTH appuser password123
```

---

## 🔑 9. Wyłącz lub ogranicz `default`

Połączenia bez `AUTH` idą jako użytkownik `default` — wyłączenie (`off`) lub węższe reguły wymuszają jawne logowanie.

```redis
ACL SETUSER default off
```

---

## 🧪 10. Przykład scenariusza (mikroserwisy)

### Ordering Service

```redis
ACL SETUSER ordering on >orderpass ~orders:* +@all
```

👉 Dostęp tylko do:

- `orders:*` (np. `orders:1`, `orders:abc`)

### Payment Service

```redis
ACL SETUSER payment on >paypass ~payments:* +@all
```

👉 Dostęp tylko do:

- `payments:*`

### Read-only analytics

```redis
ACL SETUSER analytics on >analyticspass ~* +@read
```

👉 Pełny odczyt całego keyspace (`~*`), bez operacji zapisu — nadaje się do dashboardów i raportów tylko do odczytu.

---

## ⚠️ Dobre praktyki

- ❗ nie używaj `~*` w produkcji, jeśli nie musisz
- ❗ ogranicz komendy (`+GET`, `+SET` zamiast `+@all`)
- ❗ stosuj osobnych userów dla mikroserwisów
- ❗ rotuj hasła

---

## 🧠 Podsumowanie

**ACL w Redis:**

- daje kontrolę dostępu
- zwiększa bezpieczeństwo
- jest obowiązkowy w środowisku produkcyjnym
