# Syncfusion Blazor Diagram – Organizational Chart (BlazorServerStyle)

This repository contains the `BlazorServerStyle` Blazor server project demonstrating an organizational chart implemented with Syncfusion Blazor Diagram and persisted via Entity Framework Core (Npgsql/PostgreSQL).

Built with **.NET 10** (LTS) – March 2026.

![Diagram Screenshot](https://via.placeholder.com/800x400?text=Organizational+Chart+Screenshot)

## Highlights
- Organizational chart layout with 50px spacing
- Nodes: blue rectangles displaying role names
- Orthogonal connectors with arrow decorators
- Data persisted via EF Core + Npgsql (PostgreSQL)
- Database created and seeded via EF Core migrations

## Technology Stack
- **Framework**: .NET 10 (Blazor Server)
- **UI**: Syncfusion.Blazor.Diagram
- **Data access**: Entity Framework Core + Npgsql
- **Database**: PostgreSQL 14+

## Project Structure (root of this folder)
```
BlazorServerStyle/
├─ Components/
├─ Controllers/
├─ Data/                # AppDbContext, migrations
├─ Migrations/          # EF Core migrations + seed data
├─ Models/              # LayoutNode
├─ Services/
├─ wwwroot/
├─ appsettings.json
├─ appsettings.Development.json
├─ BlazorServerStyle.csproj
└─ Program.cs
```

## Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- PostgreSQL 14+ running locally (default credentials used in examples)
- (Optional) Visual Studio 2022+ or VS Code with C# tooling

## Setup Instructions

1. Restore NuGet packages:

```bash
dotnet restore
```

2. Configure the database connection (if needed):

Edit `appsettings.Development.json` in this project and update the `DefaultConnection` string if your PostgreSQL settings differ.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=orgchart_db;Username=postgres;Password=postgres123;Port=5432"
  }
}
```

3. Create and seed the database using EF Core migrations:

```bash
dotnet tool restore
dotnet ef database update
```

Run the `dotnet ef` commands from this project's root (where `BlazorServerStyle.csproj` is located). If you don't have the EF CLI installed, run `dotnet tool restore` or install `dotnet-ef` globally.

4. Run the app:

```bash
dotnet run
```

Open the URL shown in the console (typically `http://localhost:5xxx`). The app will load and fetch layout data from the application's controllers backed by the local PostgreSQL database.

## Expected Result

- The page shows a loading state briefly, then renders the hierarchical org chart.
- Top node: "Board" (branches to managers / departments)

## Next Steps / Ideas

- Add CRUD endpoints and UI for managing nodes
- Enable node drag & drop and inline editing
- Export the diagram to PDF or SVG

## Contributing
Contributions are welcome—open a PR with changes and tests where appropriate.

## License & Support
- Syncfusion components require a Syncfusion license; see the Syncfusion documentation for license setup.
- For component-specific questions, consult https://www.syncfusion.com/forums


