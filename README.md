# Week 10 Solutions

By Stella Marie

C# Web projects featuring use of databases.

## Technologies Used

- C# 12
- .Net 6.0
  - Entity Framework Core
  - MySQL

## Description

### ToDoList

Sample project for Week 10, refactored from Week 9. ToDoList demonstrates the use of a database for storing and retrieving data corresponding to models, Items and Categories. Using Html helper methods removed the RESTful conventions, but simplified the routing from page to page. This project features an initial page, view and single view pages for Items and Categories, addition, modification and deletion.

### RestaurantList

RestaurantList is an MVC web app for viewing restaurants by cuisine and their reviews. This project builds on the base concepts shown in ToDoList and replicate them for practice.

## Complete Setup

- Navigate to main page of repo
- Either fork or clone project

To run the project:
```bash
dotnet run --project ProjectName
```

Options for ProjectName can be found in [Description](#description).

If the app does not launch in the browser:
- Run the app
- Open a browser
- Enter the url: https://localhost:5001/

### Forked Repo

ProjectName
- main assembly
- tests assembly

Main assembly
- Program.cs Line 4
- *Controller.cs Line 2, 4
- Models/*.cs Line 1
- Views/*/*.cshtml Line 5

Please provide credit in the license section of your readme.

This project utilizes a database for persistent storage, particularly MySQL. To setup your own database, you may need to download MySQL Server and MySQL Workbench. Using Workbench is not completely necessary, being a GUI (and it is slower than using CLI), but if you are starting out with databases, Workbench may make it easier. Note that if you use CLI, your tables and column names will need to be surrounded by backticks \`\` as in: \`restaurant_list\`.\'cuisines\'. The query writer in Workbench would not require use of the backticks, which would be added for you.

- Setup a database: ```CREATE DATABASE restaurant_list;```
- Select the database: ```USE restaurant_list;```
- Add three tables:
  - ```CREATE TABLE cuisines (CuisineId INT PRIMARY KEY NOT NULL AUTO_INCREMENT, Name VARCHAR(255));```
  - ```CREATE TABLE restaurants (RestaurantId INT PRIMARY KEY NOT NULL AUTO_INCREMENT, NAME VARCHAR(255), CuisineId INT, FOREIGN KEY (CuisineId) REFERENCES cuisines(CuisineId));```
  - ```CREATE TABLE reviews (ReviewId INT NOT NULL AUTO_INCREMENT, Comment TEXT, Rating INT DEFAULT 0, Summary VARCHAR(255), RestaurantId INT, PRIMARY KEY (ReviewId), FOREIGN KEY (RestaurantId) REFERENCES restaurants(RestaurantId))```

In your IDE:
- Create a file in the RestaurantList assembly: appsettings.json
  - Do not remove the mention of this file from .gitignore
- Add this code:

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=[hostname];Port=[port_number];database=[database_name];uid=[username];pwd=[password]"
    }
}
```

Replace the values accordingly and brackets are not to be included.

## Known Bugs

Please report any issues in using the app.

## License

[MIT](https://choosealicense.com/licenses/mit/)

Copyright (c) 2023 Sm Kou