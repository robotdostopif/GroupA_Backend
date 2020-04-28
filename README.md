# GroupA_Backend
# SkräckfilmsAPI



### Process

#### 2020-04-27

* Vi är färdiga med tabeller och GET requests
* **Nästa steg:** 
  * Skriv PUT, POST, DELETE requests 
  * JSON psuedo!

**2020-04-27**



### Tables

| Movie     | Type         | Relations |
| --------- | ------------ | --------- |
| *MovieId* | `int`        |           |
| *GenreId* | `int`        | Genre     |
| *Title*   | `string(50)` |           |
| *Length*  | `int`        |           |
| *Year*    | `Date`       |           |

| Person         | Type         | Relations |
| -------------- | ------------ | --------- |
| *PersonId*     | `int`        |           |
| *FirstName*    | `string(50)` |           |
| *LastName*     | `string(50)` |           |
| *DOB*          | `Date`       |           |
| *BirthTown*    | `string(50)` |           |
| *BirthCountry* | `string(50)` |           |



**Constraint Subgenre:** 

* Tillåtna typer = Supernatural, Slasher, etc...

| Genre     | Type         | Relations |
| --------- | ------------ | --------- |
| *GenreId* | `int`        |           |
| *Name*    | `string(50)` |           |



**Constraint Role:** 

* Tillåtna typer = actor, director

**Kan vara Null:**

* Character (ifall man är regissör)

| PersonMovie | Type     | Relations |
| ----------- | -------- | --------- |
| *MovieId*   | `int`    | Movie     |
| *PersonId*  | `int`    | Person    |
| *Role*      | `string` |           |
| *Character* | `string` |           |

* Person

* Movie
* Genre

* PersonMovie



### Requests

#### GET

```
/Movies/
/Movies?year=<year>
/Movies?minLength=<minLength>
/Movies?maxLength=<maxLength>
/Movies?subgenre=<genreName>
/Movies/<id>?includeActors=<bool>
/Movies/<id>?includeDirectors=<bool>

/Persons/ 
/Persons?role=<role>
/Persons?birthTown=<town>
/Persons?birthCountry=<countrycode>
/Persons?includeMovies=<bool>
/Persons/<id>/

/Genres/
/Genres/<id>
/Genres/<id>?includeMovies=<bool>
/Genres/<id>?includeActors=<bool>
```

#### POST

```
/Movies/
/Persons/ 
/Genres/
```

#### PUT

```
/Movies/<id>
/Persons/<id>
/Genres/<id>
```

#### DELETE

```
/Movies/<id>
/Persons/<id>
/Genres/<id>
```



### Json Response

```
/Movies/1
{
	"MovieId" : 1,
	"GenreId" : 2,
	"Title" : "The Amityville Horror",
	"Length" : 90, 
	"Year": 2005
}

/Movies/1?includeDirector=true
{
	"MovieId" : 1,
	"GenreId" : 2,
	"Title" : "The Amityville Horror",
	"Length" : 90, 
	"Year": 2005,
	"Directors" : [{
		"PersonId" : 3,
		"FirstName" : "Andrew",
		"LastName" : "Douglas",
		"DOB" : null,
		"BirthTown" : null,
		"BirthCountry" : "UK"
    }]
}
```



### User Stories

#### GET

* Som användare vill jag kunna se alla tillgängliga filmer
* Som användare vill jag kunna välja en film på id och se detaljer
* Som användare vill jag kunna se en lista av filmer som är släppta ett särskilt årtal
* Som användare vill jag kunna se en lista av filmer som har en angiven minsta spellängd
* Som användare vill jag kunna se en lista av filmer som har en angiven högsta spellängd
* Som användare vill jag kunna se en lista av filmer av en särskild genre
* Som användare vill jag kunna se filmer och inkludera regissörer
* Som användare vill jag kunna se filmer och inkludera skådespelare



* Som användare vill jag kunna se en lista utav alla personer som finns registrerad på någon film
* Som användare vill jag kunna välja en person på id och se detaljer
* Som användare vill jag kunna se en lista utav alla regissörer
* Som användare vill jag kunna se en lista utav alla skådespelare
* Som användare vill jag kunna se en lista utav alla personer födda i en viss stad
* Som användare vill jag kunna se en lista utav alla personer födda i en visst land
* Som användare vill jag kunna se en lista utav alla, eller en särskild person, och inkludera alla filmer personen har varit delaktig i



* Som användare vill jag kunna se en lista utav alla tillgängliga genrer
* Som användare vill jag kunna välja ut en genre på dess id 
* Som användare vill jag kunna inkludera välja ut en genre och inkludera filmer
* Som användare vill jag kunna inkludera välja ut en genre och inkludera skådespelare
* Som användare vill jag kunna inkludera välja ut en genre och inkludera regissörer

