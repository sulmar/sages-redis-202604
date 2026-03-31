# Zadanie: Monitorowanie Urządzeń


## Wprowadzenie
Firma zajmuje się serwisowaniem ekspresów kawowych i musi je regularnie monitorować ich stan techniczny, aby zapewnić ich prawidłowe działanie. W tym zadaniu stwórz system, który będzie przechowywał wyniki testów diagnostycznych ekspresów kawowych, takich jak zasilanie, temperatura, działanie pompy i młynka do kawy, oraz umożliwiał analizowanie tych wyników.

## Zadanie
Stwórz system, który będzie:
- Przechowywał wyniki testów diagnostycznych ekspresów kawowych.
- Umożliwiał analizę wyników testów ekspresów w celu sprawdzenia ich stanu technicznego.


## Wymagania
1. Przechowywanie wyników testów:
- Wyniki testów diagnostycznych ekspresów kawowych powinny być przechowywane w bazie Redis.

2. Analiza wyników:
- System powinien umożliwiać analizowanie wyników testów dla różnych ekspresów kawowych.

3. Testy diagnostyczne:
- Testy powinny obejmować:
- Sprawdzenie zasilania ekspresu.
- Weryfikacja minimalnej temperatury ekspresu.
- Test działania pompy w ekspresie.
- Test działania młynka w ekspresie.

4. Wyniki testów: System powinien umożliwiać sprawdzenie, czy ekspres przeszedł wszystkie testy, czy niektóre z nich nie zostały zaliczone.