## Issues



### Epic

* Actor
  * Create a model
    * Props...
    * In folder Models
  * Create a DTO
    * Props...
    * In folder Dto
  * Create a Controller
    * Should have private readonly Repository from DI 
    * In folder Controllers
  * Add Method GetAll() to Controller
    * Make async request to repository to fetch all Actors
  * Add Method Get(int id) to Controller
    * Make async request to repository to fetch one Actor by Id
  * Create a Repository
    * Should have private readonly Context from DI
    * In folder Services
  * Add Method GetAll() to Repository
    * Make an async request to context to fetch all Actors
  * Add Method Get(int id) to Repository
    * Make an async request to context to fetch one Actor by id
* Movie
* Director
* Genre
* Casting



#### To do

* Create folder Dto
  * Move all DTO models into folder Dto/

* Create Services/RepositoryCrud.cs
  * Create the file in Services folder
  * Fill it with a private readonly field HorrorContext
  * Fill it with a constructor that takes context injection and sets the private field
* 



