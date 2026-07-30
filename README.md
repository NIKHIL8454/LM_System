# LM_System — Library Management System

A web-based **Library Management System** built with **ASP.NET Core MVC (.NET 8)** and **Entity Framework Core**. It lets a librarian manage books, publications (newspapers/magazines), student records, and borrow/return activity, with role-based login for Administrator, Librarian, and Member accounts.

## Features

- **Books management** — add, edit, delete, and list books (title, author, ISBN, published date, availability).
- **Publications management** — track newspapers and magazines separately from books.
- **Borrow / Return workflow** — issue a book to a borrower (name, email, phone) and record return dates; a book is automatically marked unavailable while borrowed.
- **Student records** — maintain a list of students/members.
- **Authentication & authorization** — powered by ASP.NET Core Identity with three roles: `Administrator`, `Librarian`, and `Member`. Every controller requires login by default; only the login page is public.
- **Dashboard** — quick overview of library activity.
- **Seeded demo data** — roles and demo accounts are created automatically on first run (see [Demo accounts](#demo-accounts) below).
- **Unit tests** — an xUnit test project (`LMSystem.Tests`) covering the Books controller using an in-memory database.

## Tech stack

| Layer            | Technology                                      |
|-------------------|--------------------------------------------------|
| Framework         | ASP.NET Core MVC (.NET 8)                        |
| Data access       | Entity Framework Core 8 (Code-First + Migrations) |
| Database          | SQL Server (LocalDB / SQL Express)                |
| Auth              | ASP.NET Core Identity (Cookie-based, role-based)  |
| Views             | Razor Views (`.cshtml`)                           |
| Testing           | xUnit + EF Core InMemory provider                 |

## Project structure

```
LMSystem/
├── LMSystem/                  # Main ASP.NET Core MVC app
│   ├── Controllers/           # Books, Publications, Student, Borrow, Librarian, Account, Login, Dashboard, Home
│   ├── Models/                # Book, Publication, BorrowRecord, StudentModel, LibrarianModel, view models
│   ├── Data/                  # ApplicationDbContext (Identity) + SeedData (roles & demo users)
│   ├── Migrations/            # EF Core migrations
│   ├── Views/                 # Razor views per controller
│   ├── wwwroot/               # Static assets (css, images)
│   ├── setup_day3_day4.sql    # Manual SQL setup/reference script
│   ├── appsettings.json       # Configuration (connection string, logging)
│   └── Program.cs             # App startup / middleware pipeline
├── LMSystem.Tests/            # xUnit test project
├── LMSystem.sln                # Visual Studio solution file
└── README.md
```

## Getting started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (LocalDB, Express, or full SQL Server) — the default connection string targets `localhost\SQLEXPRESS`
- Visual Studio 2022 / VS Code (with the C# Dev Kit extension)

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/<your-username>/LM_System.git
   cd LM_System
   ```

2. **Configure the database connection**
   Update the `ConnectionStrings:DefaultConnection` value in `LMSystem/appsettings.json` to point at your SQL Server instance.

3. **Apply migrations to create the database**
   ```bash
   cd LMSystem
   dotnet ef database update
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```
   The app seeds Identity roles and demo accounts automatically on first startup.

5. **Open the app** in your browser at the URL shown in the console (e.g. `https://localhost:5001`).

### Running tests

```bash
cd LMSystem.Tests
dotnet test
```

## Demo accounts

The following accounts are seeded automatically on first run:

| Username           | Password | Role          |
|--------------------|----------|---------------|
| `admin`            | `12345`  | Administrator |
| `mycodingproject`   | `myc546` | Librarian     |
| `my`               | `myc`    | Member        |

> ⚠️ These are demo/course-project credentials with intentionally relaxed password rules. Do not use this configuration as-is in a production environment — tighten the password policy in `Program.cs` and rotate these credentials before any real deployment.

## License

This project currently has developed for MP Online Internship Project.
