# Repository Improvement Checklist

Use this checklist to make the GitHub repository look complete and professional.

---

## 1. Rename the Repository

Current name appears generic. Use:

```text
ZUJ-Events-Hub
```

or:

```text
University-Event-Management-System
```

---

## 2. Replace README.md

Replace the current README with the prepared `README.md`.

The README should explain:

- What the project is.
- Why it exists.
- Features.
- Tech stack.
- How to run.
- Default accounts.
- Project structure.
- Release notes.
- Future improvements.

---

## 3. Add Repository About Section

Use this description:

```text
Graduation project: ASP.NET Core MVC university event management system with Admin/Student roles, event booking, capacity control, waiting list logic, and SQL Server database.
```

---

## 4. Add Topics

Use:

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

## 5. Add GitHub Pages

Use the included `/docs/index.html` as a static project presentation page.

Steps:

1. Push the `/docs` folder to GitHub.
2. Open repository `Settings`.
3. Open `Pages`.
4. Under build and deployment, select deploy from branch.
5. Select `main`.
6. Select `/docs`.
7. Save.

Then add the generated Pages URL to the repository website field.

---

## 6. Add First Release

Create a GitHub release:

```text
Tag: v1.0.0-graduation
Title: ZUJ Events Hub - Graduation Project Release
```

Use the prepared `RELEASE_NOTES_v1.0.0-graduation.md`.

---

## 7. Packages Section

For this project, GitHub Packages is optional.

Recommended decision:

```text
Do not publish a GitHub Package unless you convert the application into a Docker image or reusable NuGet package.
```

Reason:

- This is a web application, not a reusable library.
- A GitHub Release is more suitable for graduation project submission.
- The README already documents the NuGet dependencies.

Optional future package idea:

```text
Publish a Docker image using GitHub Container Registry after the app is production-ready.
```

---

## 8. Add Screenshots

Create this folder:

```text
docs/images/
```

Add these files:

```text
home.png
login.png
admin-dashboard.png
create-event.png
student-events.png
book-event.png
my-bookings.png
profile.png
```

Then update README and GitHub Pages to show the screenshots.

---

## 9. Clean Before Public Upload

Before making the repository public:

- Remove `.csproj.user` files.
- Check that no personal secrets exist in `appsettings.json`.
- Keep only safe local database connection strings.
- Remove unused SQL files if they are not needed.
- Rename unclear files.
- Add screenshots and documentation.
- Add a license if you want others to reuse the code.

---

## 10. Recommended Final Repository Layout

```text
ZUJ-Events-Hub/
├── .github/
│   └── ISSUE_TEMPLATE/
├── docs/
│   └── index.html
├── project/
├── project.sln
├── README.md
├── RELEASE_NOTES_v1.0.0-graduation.md
├── REPOSITORY_SETUP.md
├── ABOUT_AND_TOPICS.md
├── .gitignore
└── LICENSE
```
