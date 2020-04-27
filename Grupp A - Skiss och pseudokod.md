## Grupp A 

## SkräckfilmsAPI



### Tables

* Director
* Title
* Genre
* Actor



#### Join Tables

* ActorTitle
* DirectorTitle



### Requests

* Director 
  * Visa alla regissörer
* Title [Limit, Year, Genre]
  * Visa alla titlar
* Genre
  * Visa alla genrer
* Actor
  * Visa alla skådespelare



### Routing Pseudokod

myapi.se/Title/

myapi.se/Title/13

myapi.se/Title/Year/1970

myapi.se/Title/?limit=10

myapi.se/Director/

myapi.se/Director/5/Titles

myapi.se/Actor/

myapi.se/Actor/8/Titles

myapi.se/Genre/

myapi.se/Genre/5/Titles



### User Stories

Som användare vill jag: kunna få fram en lista av alla Regissörer

Som användare vill jag: kunna få fram en lista av alla Titlar

Som användare vill jag: kunna få fram en lista av alla Skådespelare

Som användare vill jag: kunna få fram en lista av alla Genrer

Som användare vill jag: kunna få fram alla titlar utgivna ett visst årtal

Som användare vill jag: kunna få fram alla titlar under en särskild Genre

Som användare vill jag: kunna få fram alla titlar från en viss Regissör

Som användare vill jag: kunna få fram alla titlar från en viss Skådespelare

