# Koszyk zakupowy

## Wprowadzenie

Celem projektu jest stworzenie usługi, która umożliwia zarządzanie koszykiem zakupowym użytkownika z wykorzystaniem bazy danych Redis i mechanizmu cache. Usługa powinna umożliwiać dodawanie, usuwanie oraz przeglądanie produktów w koszyku. Każda operacja powinna być zapisywana w Redis, a dane o koszyku powinny być przechowywane w pamięci podręcznej, aby przyspieszyć dostęp do nich.


## Zadanie 

Utwórz usługę, która realizuje następujące funkcjonalności:

1. **Dodawanie produktu do koszyka:** Produkt zostaje dodany do koszyka z przypisanym identyfikatorem użytkownika.
3. **Usuwanie produktu z koszyka:** Produkt zostaje usunięty z koszyka użytkownika.
3. **Przeglądanie koszyka:** Użytkownik może zobaczyć wszystkie produkty w swoim koszyku.
4. **Pamięć podręczna:** Zastosowanie mechanizmu cache w celu przyspieszenia dostępu do danych koszyka (dane w Redis powinny być przechowywane w pamięci podręcznej przez określony czas).


## Wymagania

1. Dodawanie produktu do koszyka (`POST /cart/{userId}`)
- Użytkownik wysyła zapytanie POST z następującymi danymi w JSON:

```json
{
  "productId": "123",
  "name": "Product Name",
  "quantity": 1,
  "price": 29.99
}
```

- Produkt zostaje dodany do koszyka użytkownika w Redis. 

- Jeśli koszyk użytkownika już istnieje, produkt zostaje dodany do istniejącego koszyka. Jeśli nie istnieje, zostaje utworzony nowy koszyk.

- Odpowiedź zwraca status operacji:
```json
{
  "message": "Product added to cart successfully."
}
```

- Jeśli produkt w koszyku użytkownika już istnieje, zostaje powiększona lub pomniejszona jego ilość o `quantity`.


2. Usuwanie produktu z koszyka (`DELETE /cart/{userId}/{productId}`)
- Użytkownik wysyła zapytanie DELETE z identyfikatorem użytkownika i identyfikatorem produktu, np.:
```
DELETE /cart/123/456
```

- Produkt zostaje usunięty z koszyka użytkownika w Redis. 
- Odpowiedź zwraca status operacji:
```json
{
  "message": "Product removed from cart successfully."
}
```

3. Przeglądanie koszyka (`GET /cart/{userId}`)
- Użytkownik wysyła zapytanie GET z identyfikatorem użytkownika, np.:
```
GET /cart/123
```

- Odpowiedź zwraca produkty w koszyku użytkownika:

```json
{
  "userId": "123",
  "products": [
    {
      "productId": "123",
      "name": "Product Name",
      "quantity": 1,
      "price": 29.99
    },
    {
      "productId": "124",
      "name": "Another Product",
      "quantity": 2,
      "price": 19.99
    }
  ]
}
```

5. Pamięc podręczna
- Dane koszyka były przechowywane w pamięci podręcznej przez określony czas (np. 10 minut).
