# Ticketing
This project is a simple offline ticketing system backend designed for an organization to handle internal support requests. It is built entirely using ASP.NET Core 8 Web API and Entity Framework Core with a local SQL Server database. No external dependencies or front-end are required.

# Features
- JWT-based authentication to secure the API endpoints
- Two user roles: Employee and Admin
- Employees can create tickets and view their own tickets
- Admins can manage all tickets, update status, assign tickets, view statistics, and delete tickets
- Tickets have properties such as Title, Description, Status (Open, InProgress, Closed), and Priority (Low, Medium, High)
- Basic ticket statistics by status
- Secure endpoints with role-based authorization

# Prerequisites
- .NET 8 SDK installed
- SQLServer installed and configured

# Setup and Run
- Clone or download the project source code.
- Configure your connection string and JWT settings in `appsettings.json`.
- Apply EF Core migrations to create the database schema:
`dotnet ef database update`
- Run the application
- Use Swagger UI at `/swagger` to test endpoints interactively.

# 
---

## API Endpoints

| Endpoint                  | Method | Description                                              | Roles Allowed             |
|---------------------------|--------|----------------------------------------------------------|---------------------------|
| `/auth/login`             | POST   | Authenticate user and get JWT token                      | All                       |
| `/tickets`                | POST   | Create new ticket                                        | Employee                  |
| `/tickets/my`             | GET    | Get tickets created by current user                     | Employee                  |
| `/tickets`                | GET    | List all tickets                                        | Admin                     |
| `/tickets/{id}`           | GET    | Get details of specific ticket (allowed creator/admin)  | Creator or Assigned Admin |
| `/tickets/{id}`           | PUT    | Update ticket status and assignment                      | Admin                     |
| `/tickets/stats`          | GET    | Get ticket counts by status                              | Admin                     |
| `/tickets/{id}`           | DELETE | Delete ticket                                           | Admin                     |

---

## Technologies Used

- ASP.NET Core 8 Web API  
- Entity Framework Core (Code First)  
- JWT Authentication  
- SQLServer Database  
- Swagger UI for API documentation and testing

---

## Notes

- Passwords are stored securely as hashed values.  
- JWT tokens include user ID and role claims for authorization.  
- Role-based authorization is applied to restrict access to endpoints.  
- The system runs locally without external dependencies.


