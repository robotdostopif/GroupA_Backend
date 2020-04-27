## Grupp A 

## SkräckfilmsAPI



### Tables

**Constraint Subgenre:** 

* Tillåtna typer = Supernatural, Slasher, etc...

| Movie    | Type       | Relations |
| -------- | ---------- | --------- |
| MovieId  | int        |           |
| GenreId  | int        |           |
| Title    | string(50) |           |
| Length   | int        |           |
| Year     | Date       |           |
| Subgenre | string     |           |

| Person       | Type       | Relations |
| ------------ | ---------- | --------- |
| PersonId     | int        |           |
| FirstName    | string(50) |           |
| LastName     | string(50) |           |
| DOB          | Date       |           |
| BirthTown    | string(50) |           |
| BirthCountry | string(50) |           |



**Constraint Role:** 

* Tillåtna typer = actor, director

| PersonMovie | Type   | Relations |
| ----------- | ------ | --------- |
| MovieId     | int    | Movie     |
| PersonId    | int    | Person    |
| Role        | string |           |

* Person

* Movie
* Genre

* PersonMovie



### Tankar om Requests 

* Director 
  * Visa alla regissörer
* Movies [Limit, Year, Genre]
  * Visa alla filmer
* Genre
  * Visa alla genrer
* Actor
  * Visa alla skådespelare



### Requests

#### GET

```
/Movies/
/Movies/13
/Movies/?year=<year>
/Persons/
/Persons/5
/Persons/?role=<role>
/Genres/
/Genres/<id>
/Genres/<id>/?includeMovies=true
/Genres/<id>/?includeActors=true
```



### User Stories

Som användare vill jag: kunna få fram en lista av alla Regissörer

Som användare vill jag: kunna få fram en lista av alla Movies

Som användare vill jag: kunna få fram en lista av alla Skådespelare

Som användare vill jag: kunna få fram en lista av alla Genrer

Som användare vill jag: kunna få fram alla titlar utgivna ett visst årtal

Som användare vill jag: kunna få fram alla titlar under en särskild Genre

Som användare vill jag: kunna få fram alla titlar från en viss Regissör

Som användare vill jag: kunna få fram alla titlar från en viss Skådespelare

