📚 SchoolAPI - ASP.NET Core Web API for School Management
SchoolAPI is a structured and scalable ASP.NET Core 8 Web API project designed using Clean Architecture principles to manage students, departments, instructors, and subjects with full CRUD operations, pagination, and localization support. 


🚀 Features
✅ Clean Architecture with separation of Concerns

✅ CQRS pattern using MediatR

✅ AutoMapper for model mapping

✅ FluentValidation for input validation

✅ Global exception handling

✅ Localization (AR/EN) using IStringLocalizer

✅ Generic API response wrapper

✅ Pagination with metadata

✅ Entity Framework Core with SQL Server

✅ Swagger for API testing

🛠️ Technologies Used
.NET 8

Entity Framework Core

MediatR

AutoMapper

FluentValidation

SQL Server

Swashbuckle (Swagger)

IStringLocalizer (Localization)

LINQ & Expression trees

RESTful API design

📁 Project Structure

SchoolAPI/
│
├── School.API                → Startup layer (Controllers, Middleware)
├── School.Core               → Business logic (CQRS, Commands, Queries, Validators)
├── School.Data               → Entity models (Student, Department, etc.)
├── School.Service            → Interfaces + Implementations
├── Shcool.Infrustructure     → Repositories + EFCore access
├── Resources/                → Localization (.resx files)
└── README.md

🧪 How to Run
Clone the repo:

git clone https://github.com/Moamed1010/SchoolAPI.git
Update your appsettings.json with your SQL Server connection string.

Run EF Core migrations:

dotnet ef database update
Launch the API:

dotnet run
Visit Swagger UI:
https://localhost:{port}/swagger

🌍 Localization
Supports both Arabic and English using IStringLocalizer.

Example:

{
  "key": "NotEmpty",
  "value": "This field is required."
}
📬 Endpoints Sample

GET /api/Studnet/Api/V1/Student/GetAll

POST /api/Studnet/Api/V1/Student/Create

PUT /api/Studnet/Api/V1/Student/Edit

DELETE /api/Studnet/Api/V1/Student/Delete

👨‍💻 Author
Mohamed Hassan Ali
Full-stack Developer (Flutter & .NET)
GitHub

✅ License
This project is licensed under the MIT License.

