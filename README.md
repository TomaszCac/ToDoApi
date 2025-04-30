# ToDoApi
### Synopsis
This project aims to show my skills as a programmer. Its purpose is to make tasks called ToDo's with an expiration date, percentage of completion, title, description and id.
### Setup
If you have docker you can just use the command "docker compose up -d" inside project where dockerfile and docker-compose.yml are. By doing that the app with database should be working properly on "http://localhost:8080/api/todo".
(REMEMBER TO USE HTTP NOT HTTPS)
If you dont have docker you can still setup a mariadb database and connect the project to it. Then use command "Update-Database" in Package manager terminal, after that use the template of data inside ExampleData.sql,
### Model
int Id </br>
required string Title</br>
string? Description</br>
int CompletePercent</br>
DateTime Expiration</br>
### Endpoints
GET http://localhost:8080/api/todo - Shows all Todo's.</br>
GET http://localhost:8080/api/todo/{id} - Shows specific Todo by id.</br>
GET http://localhost:8080/api/todo/incoming?when={today/tomorrow/week} - Shows Todo's based on their expiration date, if it's in range of now to today, tomorrow or one week.</br>
POST http://localhost:8080/api/todo - Adds new Todo to database. Model Todo needs to be inside body.</br>
PUT http://localhost:8080/api/todo/{id} - Updates entire Todo based on id. Model Todo needs to be inside body.</br>
PATCH http://localhost:8080/api/todo/{id}/percent - Changes percentage of completion using id. Int percent needs to be inside body.</br>
DELETE http://localhost:8080/api/todo/{id} - Deletes Todo based on id.</br>
PATCH http://localhost:8080/api/todo/{id}/done - Marks Todo as done based on id. Completion is marked as 100 percentage complete.</br>



