# GoLogic-Coding-Challenge-API
## Description
This repository is a API UI prototype for a Booking Platform which consumers can get a list of rooms, get a room to see more details and can post selected dates to rent or book the room. Rooms that have already been booked with the same dates or within the range of the booked dates cannot be booked by the users anymore. Booking of a room will have restriction with it's room capacity that it can accommodate guests and a user will book using an email.

## Architecture
This API is based on Clean Architecture which I believe makes a project scalable, maintanable and testable. The core or specifically the domain can be reuse accross enterprise applications like different platforms because it has no dependencies to other external like libraries or frameworks.

## Stack
This is back-end stack uses **Asp.Net Web API .Net Core 3.1** and **.Net Standard 2.1** and nuget packages **MediatR**, **FluentValidation**, **Entity Framework Core**, **AutoMapper**, **NLog**, **NUnit** and **Swashbuckle**.
### Why Asp.Net Web API .Net Core 3.1?
- Build in support for dependency injection.
- Cross platform therefore it can run on a non Windows environment.
- Open source community support.
- Supporting C# language of my choice.
- Arrays of Nuget Packages.
### Why .Net Standard 2.1?
- Uniformity for lower and higher versions of .Net Core/.Net 5 and 6
### Why MediatR
- It helps decoupling the application from top-level framework. Requests to the application does not mean it will only be via http request. MediatR helps with that decoupling with the Mediator design patterna it implements.
### Why FluentValidation
- Decouples models or entities from Frameworks like Entity Framework.
- Simpler to set validation rules.
## Entity Framework Core
- Helps developers to solely focus on writing language codes instead of having to use IDE fo databases and writing explicit queries.
## AutoMapper
- Reduces the need for explicit  mapping of models/dtos, makes code base a lot cleaner.
## NLog
- Have not used other logging package but I believe it has great logging features and easy to use.
## NUnit
- Have not used other automated testings, but I believe NUnit is one of the most popular one and widely used and for me it's easy to use and greate features.
## Swashbuckle
- Follows Swagger interface description language and provides a rich Swagger/Swagger UI interface and helps and REST Api documentation.
## Trade-offs
- Implement authentication and authorzation for the APIs, have implemented it but removed it as it would make the code base a bit dirty. Performance or query profiling to the LINQ queries of EF Core. Endpoints for populating datas not having to seed them with EF Core. Code refactoring for any simplication or try follwing standards and best practices.
