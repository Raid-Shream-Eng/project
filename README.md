# ZUJ Events Hub

Graduation project: a university event management web application built with ASP.NET Core MVC.

ZUJ Events Hub helps university administrators publish and manage events, while students can browse events, book seats, cancel bookings, and track their reservations. The project focuses on event capacity control, role-based access, student registration flow, and a simple administrative dashboard.

---

## Project Overview

This application was developed as a graduation project to manage university events in a structured way. The system supports two main user roles:

- **Admin**: manages events, monitors dashboard statistics, views registered students, and controls event records.
- **Student**: views available events, searches events, books a seat, joins the waiting list when an event is full, cancels bookings, and views personal bookings.

The project is suitable as an academic demonstration of CRUD operations, relational database design, authentication/session handling, role-based access control, and event registration business rules.

---

## Main Features

### Admin Features

- Admin dashboard with event and booking statistics.
- Create new events.
- Edit existing events.
- Delete events.
- View students registered for each event.
- Track upcoming events, active bookings, total capacity, and monthly event counts.

### Student Features

- Browse available university events.
- Search events by title or location.
- View event details before booking.
- Book an event if seats are available.
- Join a waiting list automatically when capacity is full.
- Cancel an active booking.
- Automatic promotion from waiting list when a seat becomes available.
- View personal booking history.

### Account Features

- Login with email and password.
- Session-based access control.
- Role-based redirection for Admin and Student users.
- Profile page.
- Change password.
- BCrypt password hashing.

---

## Technology Stack

| Area | Technology |
|---|---|
| Backend | ASP.NET Core MVC |
| Framework | .NET 8 |
| Language | C# |
| Database | SQL Server LocalDB |
| ORM | Entity Framework Core |
| Authentication | Session-based login |
| Password Security | BCrypt.Net-Next |
| Frontend | Razor Views, HTML, CSS, JavaScript |
| UI Libraries | Bootstrap, AdminLTE |
| Calendar Assets | FullCalendar |
| IDE | Visual Studio 2022 |

---

## Database Entities

The application uses three core entities:

### User

Stores student and admin account data.

Main fields:

- `Id`
- `Name`
- `Email`
- `Password`
- `Role`
- `UImage`

### Event

Stores event information.

Main fields:

- `Id`
- `Title`
- `Description`
- `Date`
- `StartTime`
- `Location`
- `major`
- `Limit`

### Roll

Stores event booking records and booking status.

Main fields:

- `Id`
- `UserId`
- `EventId`
- `States`
- `BookingTime`

Booking states include:

- `active`
- `waiting`
- `cancelled`

---

## Business Rules

- A student cannot book the same event more than once while their booking is active or waiting.
- If an event reaches its capacity limit, new students are added to the waiting list.
- When an active booking is cancelled, the first waiting student can be promoted.
- Admin-only pages are protected using a custom session check attribute.
- Student-only pages are also protected using role validation.
- Passwords are stored using BCrypt hashing.
- The system applies database migrations automatically on startup.

---

## Project Structure

```text
project-main/
├── project.sln
├── SQLQuery1.sql
├── SQLQuery2.sql
├── project/
│   ├── Controllers/
│   │   ├── AdminController.cs
│   │   ├── HomeController.cs
│   │   ├── LoginController.cs
│   │   ├── StudentController.cs
│   │   └── UserController.cs
│   ├── Models/
│   │   ├── ApplicationDbContext.cs
│   │   ├── Event.cs
│   │   ├── Roll.cs
│   │   └── User.cs
│   ├── Views/
│   │   ├── Admin/
│   │   ├── Home/
│   │   ├── Login/
│   │   ├── Student/
│   │   └── User/
│   ├── Migrations/
│   ├── wwwroot/
│   ├── Program.cs
│   ├── SessionCheckAttribute.cs
│   └── appsettings.json
└── README.md
```

---

## Required Packages

The project uses the following NuGet packages:

```xml
<PackageReference Include="BCrypt.Net-Next" Version="4.0.3" />
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.22" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.22" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.22" />
```

To restore packages:

```bash
dotnet restore
```

---

## How to Run the Project

### Prerequisites

Install the following:

- Visual Studio 2022
- .NET 8 SDK
- SQL Server LocalDB

### Steps

1. Clone the repository:

```bash
git clone https://github.com/USERNAME/REPOSITORY_NAME.git
```

2. Open the solution file:

```text
project.sln
```

3. Check the database connection string in `project/appsettings.json`:

```json
"DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ProjectEventDb;Trusted_Connection=true;"
```

4. Run the project from Visual Studio.

5. The application will apply pending Entity Framework migrations automatically on startup.

---

## Default Test Accounts

The project seeds default users when the database is created.

### Admin Accounts

```text
Email: admin@example.com
Password: Admin123!
```

```text
Email: admin2@example.com
Password: Admin123!2
```

### Student Accounts

```text
Email: student@example.com
Password: Student123!
```

```text
Email: student2@example.com
Password: Student123!2
```

```text
Email: student3@example.com
Password: Student123!3
```

> These accounts are for local testing only. Change or remove them before any public deployment.

---

## Suggested Screenshots

Add screenshots to make the repository stronger.

Recommended screenshot folder:

```text
docs/images/
```

Recommended screenshots:

- Home page
- Login page
- Admin dashboard
- Create event page
- Student event list
- Event booking page
- My bookings page
- Profile page

Then reference them in this README like this:

```md
![Admin Dashboard](docs/images/admin-dashboard.png)
```

---

## GitHub Pages

This ASP.NET Core MVC application cannot run directly on GitHub Pages because GitHub Pages is for static website content. However, this repository can still use GitHub Pages as a project presentation page.

Recommended approach:

- Keep the actual application code in the main project.
- Put the static presentation website in the `/docs` folder.
- Enable GitHub Pages from repository settings.
- Set the publishing source to the `main` branch and `/docs` folder.

The `/docs` page can include:

- Project description
- Features
- Technology stack
- Screenshots
- Demo video link
- Repository link
- Graduation project context

---

## Release Plan

Use GitHub Releases to mark stable versions of the project.

Recommended first release:

```text
v1.0.0-graduation
```

Suggested release title:

```text
ZUJ Events Hub - Graduation Project Release
```

Suggested release description:

```md
First stable graduation project release of ZUJ Events Hub.

Includes:
- ASP.NET Core MVC event management system
- Admin dashboard
- Student event browsing and booking
- Capacity and waiting list handling
- Session-based authentication
- BCrypt password hashing
- SQL Server database with Entity Framework Core migrations
```

---

## Repository About Section

Suggested repository description:

```text
Graduation project: ASP.NET Core MVC university event management system with Admin/Student roles, event booking, capacity control, waiting list logic, and SQL Server database.
```

Suggested website link:

```text
https://USERNAME.github.io/REPOSITORY_NAME/
```

Suggested topics:

```text
aspnet-core
mvc
dotnet
dotnet-8
csharp
entity-framework-core
sql-server
razor-pages
bootstrap
adminlte
fullcalendar
event-management
booking-system
university-project
graduation-project
```

---

## Academic Notes

This project demonstrates:

- MVC architecture in ASP.NET Core.
- Entity Framework Core database access.
- Code-first migrations.
- Role-based page protection.
- Session management.
- CRUD operations.
- Relational database relationships.
- Password hashing.
- Event capacity and waiting list logic.
- Basic dashboard analytics.

---

## Future Improvements

Possible improvements for future versions:

- Replace session-only authentication with ASP.NET Core Identity.
- Add email confirmation and password reset.
- Add better validation for event dates and times.
- Add event categories and departments.
- Add event images.
- Add admin export reports.
- Add student attendance QR code.
- Add API endpoints.
- Add unit and integration tests.
- Improve UI responsiveness.
- Add Arabic/English language switching.
- Deploy the application to a real ASP.NET hosting environment.

---

## License

This project is submitted as an academic graduation project. If you plan to make the repository public, add a license file such as MIT License or keep it as private academic work.

---

## Author

**Raid Shream**

Computer Science Graduate  
GitHub: [Raid-Shream-Eng](https://github.com/Raid-Shream-Eng)  
LinkedIn: [Raid M. Shream](https://www.linkedin.com/in/raid-m-shream-9203233a2/)
