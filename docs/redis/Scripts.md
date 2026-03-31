# Scripts

## Opis
Skrypty umożliwiają przetwarzanie wielu poleceń bezpośrednio na serwerze Redis.
Dzięki temu możemy ograniczyć ilość zapytań pomiędzy klientem a Redisem.

Skrypty są w języku Lua. Lua to język skryptowy https://www.lua.org/ 
Posiada prostą składnię. 


## Przykłady

### Podstawy

- Wykonane wyrażenia

~~~ lua
EVAL "return 'Hello World'" 0
~~~ 

- Przekazywanie parametru
~~~ lua
EVAL "return 'Hello ' .. ARGV[1]" 0 John
~~~ 

### Integracja z Redis


- Wykonane polecenia Redis
~~~ lua
EVAL "return redis.call('SET','foo', 'Hello')" 0
EVAL "return redis.call('GET','foo')" 0 
~~~

- Przekazanie kluczy i wartości parametrów do polecenia Redis
~~~ lua
EVAL "return redis.call('SET',KEYS[1], ARGV[1])" 1 message Hello
EVAL "return redis.call('GET',KEYS[1])" 1 message 
~~~

Parametry skryptu podzielone są na 2 grupy: **KEYS** klucze i **ARGV** argumenty. Przed nimi należy podać ilość parametrów.
Parametry indeksowane są od 1.

### Ładowanie skryptów


- Załadowanie skryptu
~~~ 
SCRIPT LOAD "return redis.call('SET',KEYS[1], ARGV[1])"
~~~

Operacja zwróci SHA.

- Wykonanie skryptu
~~~
EVALSHA {sha} 1 message "Hello World"
~~~

**Uwaga** Tablice w języku LUA rozpoczynają się od 1.

- Wykonanie skryptu z pliku 

_hello.lua_

~~~ lua
local msg = "Hello, world!"
return msg
~~~

~~~ bash
redis-cli --EVAL hello.lua
~~~



- Załadowanie skryptu z pliku
~~~ bash
redis-cli -x SCRIPT LOAD < hello.lua
~~~

- Przerywanie skryptu
~~~ lua
while(true)
do
end
return 0
~~~

~~~ bash
SCRIPT KILL
~~~

- Wstawianie danych
_create-users.lua_
~~~ lua
for i=1,10000 do redis.call('SADD', 'users', "user:"..i) end
return 0
~~~

- Wykonanie skryptu
~~~
EVALSHA {sha} 1 count 1000
~~~