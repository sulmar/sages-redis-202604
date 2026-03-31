#  Zadanie: Optymalizacja Procesu Monitorowania Urządzeń z Wykorzystaniem Redis

## Cel: 
Zrozumienie, jak wykorzystać bazę danych Redis do efektywnego przechowywania i analizy wyników testów diagnostycznych urządzeń.


## Scenariusz:
Twoja firma chce usprawnić proces monitorowania stanu technicznego swojej floty urządzeń. W tym celu planuje wdrożyć system oparty na Redis, który będzie gromadził i analizował dane z testów diagnostycznych.

## Zadanie
- **1. Projektowanie Struktury Danych:** 
  - Zaproponuj strukturę danych w Redisie, która umożliwi efektywne przechowywanie pytań testowych oraz wyników dla różnych urządzeń.

- **2. Implementacja Systemu:**
	- Utwórz przykładową strukturę w Redisie, reprezentujące pytania testowe dla określonej grupy urządzeń.
	- Zaimplementuj funkcję zapisu wyników testów dla pojedynczego urządzenia.

- **3. Analiza Wyników:**
	- Opracuj metodę, która pozwoli szybko ocenić, czy wszystkie testy dla danego urządzenia zakończyły się pomyślnie.
