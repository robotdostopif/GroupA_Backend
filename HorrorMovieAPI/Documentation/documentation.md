# GroupA_Backend
# SkräckfilmsAPI



### Process

**2020-04-27** 

* Vi är färdiga med tabeller och GET requests
* **Nästa steg:** 
  * Skriv PUT, POST, DELETE requests 
  * JSON psuedo!

**2020-04-28**

* Vi är färdiga med alla CRUD requests
* Vi är färdiga med JSON exempel data
* **Nästa steg:**
  * Invänta nästa lektion

**2020-05-01**

* Vi har strukturerat om tabellerna lite
* Vi har lagt till möjlighet att seeda till Databasen
* Vi har haft standup möte
* **Nästa steg:**
  * <Fyll i>

**2020-05-04**

* Vi har uppdaterat vår backlog och lagt ärenden under Epics
* **Nästa steg:**
  * <Fyll i>

**2020-05-13**

* Tog bort UserStories, för de var utdaterade
* Uppdaterade vilka GET-requests vi vill ha.

### Tables

| Movie     | Type         | Relations |
| --------- | ------------ | --------- |
| *Id*      | `int`        |           |
| *GenreId* | `int`        | Genre     |
| *Title*   | `string(50)` |           |
| *Length*  | `int`        |           |
| *Year*    | `int`       |           |
| *Castings*    | `ICollection<Casting>`       |           |

| Actor          | Type         | Relations |
| -------------- | ------------ | --------- |
| *Id*           | `int`        |           |
| *FirstName*    | `string(50)` |           |
| *LastName*     | `string(50)` |           |
| *DOB*          | `Date`       |           |
| *BirthTown*    | `string(50)` |           |
| *BirthCountry* | `string(50)` |           |
| *Castings*     | `ICollection<Casting>`        |           |

| Director       | Type         | Relations |
| -------------- | ------------ | --------- |
| *Id*           | `int`        |           |
| *FirstName*    | `string(50)` |           |
| *LastName*     | `string(50)` |           |
| *DOB*          | `Date`       |           |
| *BirthTown*    | `string(50)` |           |
| *BirthCountry* | `string(50)` |           |
| *MovieId*        | `int`        |           |

| Casting         | Type         | Relations |
| --------------- | ------------ | --------- |
| *Id*            | `int`        |           |
| *MovieId*       | `int` |           |
| *ActorId*       | `int` |           |
| *Character* | `string(50)` |           |



**Constraint Subgenre:** 

* Tillåtna typer = Supernatural, Slasher, etc...

| Genre  | Type         | Relations |
| ------ | ------------ | --------- |
| *Id*   | `int`        |           |
| *Name* | `string(50)` |           |

* Movie
* Genre
* Director
* Actor



### Requests

#### GET

```
/Movies/
/Movies/<id>
/Movies?includeActors=<bool>
/Movies?includeDirectors=<bool>

/Actors/ 
/Actors/<id>/
/Actors?firstName=<string>
/Actors?includeMovies=<bool>

/Directors/
/Directors?birthCountry=<string>
/Directors?includeMovies=<bool>
/Directors/<id>/

/Genres/
/Genres/<id>
/Genres?includeMovies=<bool>
/Genres?includeActors=<bool>
```

#### POST

```
/Movies/
/Actors/ 
/Directors/ 
/Genres/
```

#### PUT

```
/Movies/<id>
/Actors/<id>
/Directors/<id>
/Genres/<id>
```

#### DELETE

```
/Movies/<id>
/Actors/<id>
/Directors/<id>
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



