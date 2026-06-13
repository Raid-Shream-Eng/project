# Release Notes - v1.0.0-graduation

## ZUJ Events Hub - Graduation Project Release

This is the first stable release of **ZUJ Events Hub**, an ASP.NET Core MVC university event management system developed as a graduation project.

---

## Included Features

### Admin

- Admin dashboard.
- Event statistics.
- Create events.
- Edit events.
- Delete events.
- View registered students for each event.
- Track upcoming events, active bookings, and total event capacity.

### Student

- View available university events.
- Search events by title or location.
- Book events.
- Join waiting list when event capacity is full.
- Cancel active bookings.
- View personal bookings.

### Authentication and Security

- Email/password login.
- Session-based authentication.
- Role-based access control.
- BCrypt password hashing.
- Automatic password hashing correction for old plain-text test passwords.

### Database

- SQL Server LocalDB support.
- Entity Framework Core models.
- Code-first migrations.
- Automatic migration execution on application startup.
- Seeded test accounts for local demonstration.

---

## Technology Stack

- ASP.NET Core MVC
- .NET 8
- C#
- Entity Framework Core
- SQL Server LocalDB
- Razor Views
- Bootstrap
- AdminLTE
- FullCalendar
- BCrypt.Net-Next

---

## Known Limitations

- The project currently uses custom session-based authentication instead of ASP.NET Core Identity.
- The application is designed for local academic demonstration.
- GitHub Pages can only host the static project presentation page, not the ASP.NET Core application itself.
- Default seeded accounts should be changed or removed before any public deployment.

---

## Recommended Release Assets

Attach one or more of the following:

```text
Source code zip
Project documentation PDF
Demo screenshots
Demo video link
Database notes
```

---

## Suggested GitHub Release Tag

```text
v1.0.0-graduation
```

---

## Suggested GitHub Release Title

```text
ZUJ Events Hub - Graduation Project Release
```
