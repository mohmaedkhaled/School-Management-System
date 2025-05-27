🏫 School Management System
A robust, modular backend system built with Clean Architecture, CQRS, and .NET Core.

✨ Features

✅ Clean Architecture – Clear separation of layers (Core, Infrastructure, API)

✅ CQRS Pattern – Using MediatR for command/query separation

✅ Multi-Language Support – English & Arabic localization

✅ Advanced Error Handling – Global middleware for consistent API responses

✅ Pagination – Flexible PaginatedResults<T> for large datasets

✅ Entity Framework Core – Database management with relationships

✅ AutoMapper – Seamless DTO-Entity mapping


🌐 API Endpoints

* Students
  
-Get All Students (Paginated)
GET /api/students
Query Params:

--pageNumber (default: 1)

--pageSize (default: 10)

--sortBy (optional: "name", "email")

-Get Single Student
GET /api/students/{id}

-Create Student
POST /api/students

-Update Student
PUT /api/students/{id}
(same body as Create)

-Delete Student
DELETE /api/students/{id}


* Departments

-Get All Departments
GET /api/departments

-Create Department
POST /api/departments


* Subjects

-Assign Subject to Student
POST /api/subjects/assign



🚀 Technologies Used
.NET 6

-Entity Framework Core (Code-First)

-MediatR (CQRS Implementation)

-FluentValidation

-AutoMapper

-xUnit (For Unit Testing)


📂 Project Structure

SchoolProject/

├── SchoolProject.API/          # Presentation Layer (Controllers, Middlewares)

├── SchoolProject.Core/        # Domain Layer (Entities, CQRS, DTOs)

├── SchoolProject.Data/        # Data Layer (DbContext, Repositories)

├── SchoolProject.Infrastructure/ # Shared Resources, Wrappers

└── SchoolProject.Service/     # External Services


📚 Documentation
For more details:

* Explore the API with Swagger UI at /swagger

* Check the Wiki for architecture diagrams


🔧 Setup & Installation

