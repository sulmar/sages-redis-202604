# Usługa do tworzenia skróconych adresów

## Wprowadzenie
Celem projektu jest stworzenie usługi konsolowej do skracania adresów URL. Skróty powinny być generowane za pomocą biblioteki NanoID i przechowywane w bazie danych Redis. Usługa powinna umożliwiać zarówno generowanie skrótów, jak i odwzorowanie skrótu na pełny adres URL.

## Zadanie
Utwórz usługę, która:

1. Generuje unikalne skróty do podanych adresów URL przy użyciu NanoID.
2. Przechowuje skróty w Redis w formacie klucz-wartość (gdzie kluczem jest skrót, a wartością pełny adres URL).
3. Umożliwia odczyt pełnego adresu URL na podstawie skrótu.
4. Weryfikuje, czy skrót lub URL już istnieje w bazie.


## Wymagania
1. Generowanie skrótu dla URL (POST /shorten)
- Użytkownik wysyła zapytanie POST do endpointu /shorten w formacie JSON:
```
{
  "url": "https://example.com/some-long-url"
}
```

- Odpowiedź zwraca skrócony URL w formacie JSON:
{
  "short_url": "https://short.ly/aBc123"
}


2. Odwzorowanie skrótu na pełny URL

- Użytkownik wysyła zapytanie GET na endpoint /{short_url}
- Jeśli istnieje, zwraca pełny adres URL jako odpowiedź HTTP 302 (przekierowanie):
```
HTTP/1.1 302 Found
Location: https://example.com/some-long-url
```

- Jeśli klucz nie istnieje, zwraca błąd HTTP 404:

3. Walidacja danych wejściowych
- Zapewnij, że wprowadzony URL jest prawidłowy.
- Jeśli URL jest nieprawidłowy, zwróć błąd HTTP 400 z odpowiednią wiadomością:
```
{
  "error": "Invalid URL format"
}
```


4. Obsługa duplikatów
- Przed wygenerowaniem nowego skrótu sprawdź, czy dany URL już istnieje w Redis:
- Jeśli istnieje, zwróć istniejący skrót:
{
  "short_url": "https://short.ly/{short_url}"
}
- Jeśli nie istnieje, wygeneruj nowy skrót.

5. Parametry konfiguracyjne
- Długość skrótu (domyślnie 6 znaków) powinna być konfigurowalna.
- Bazowy URL usługi (np. https://short.ly) powinien być ustawiany w pliku konfiguracyjnym.


6. Przechowywanie
- Wygenerowane skróty przechowuj w bazie Redis
- Dodaj opcjonalny czas wygaśnięcia skrótu (TTL), np. 7 dni

7. Obsługa błędów
- Brak URL w żądaniu (POST /shorten)
- Podany URL jest niezgodny z formatem RFC 3986 (POST /shorten)
- Skrót nie znaleziony (GET /{id})

Odpowiedź błędu powinna być w formacie zgodnym z RFC 7807.


