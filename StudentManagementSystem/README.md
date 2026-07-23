# Student Management System

## Overview
A RESTful Web API built using ASP.NET Core 8 and Entity Framework Core.

## Features
- Student CRUD Operations
- JWT Authentication
- Repository Pattern
- Service Layer
- DTOs
- SQL Server Database
- Entity Framework Core Code First
- Swagger API Documentation
- Global Exception Handling
- Serilog Logging

## Technologies Used
- ASP.NET Core 8 Web API
- C#
- Entity Framework Core
- SQL Server
- JWT Authentication
- Serilog
- Swagger (OpenAPI)

## Setup

1. Clone the repository.
2. Update the connection string in `appsettings.json`.
3. Run the following commands:

```powershell
Add-Migration InitialCreate
Update-Database
```

4. Run the application.

## Login Credentials

```
Username: admin
Password: admin123
```

## API Endpoints

### Authentication
- POST `/api/Auth/login`

### Students
- GET `/api/Student`
- GET `/api/Student/{id}`
- POST `/api/Student`
- PUT `/api/Student/{id}`
- DELETE `/api/Student/{id}`

## Project Structure

- Controllers
- DTOs
- Models
- Services
- Repositories
- Data
- Middleware
- Migrations

## Author

