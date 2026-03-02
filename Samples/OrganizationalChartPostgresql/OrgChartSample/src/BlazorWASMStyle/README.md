# Syncfusion Blazor Diagram – Organizational Chart with PostgreSQL (WASM)

A clean, beginner-friendly full-stack sample demonstrating how to visualize hierarchical organizational data using **Syncfusion Blazor Diagram** in a **Blazor WebAssembly (WASM)** client connected to **PostgreSQL** via **ASP.NET Core Web API** and **EF Core**.

Built with **.NET 10** (LTS) – February 2026.

![Diagram Screenshot](https://via.placeholder.com/800x400?text=Organizational+Chart+Screenshot)  
*(Replace with actual screenshot of the rendered diagram)*

## Features
- Organizational chart layout with 50px spacing
- Nodes: Blue rectangles (#6BA5D7) displaying role names
- Orthogonal connectors with arrow decorators
- Data fetched from PostgreSQL via REST API
- Automatic database + table + seed data creation via EF Core migrations
- Loading state and basic error handling
- Type-safe C# code with proper null handling

## Technology Stack
- **Frontend**: Blazor WebAssembly (WASM) client (.NET 10)
- **Backend**: ASP.NET Core Web API (.NET 10) + EF Core + Npgsql
- **Database**: PostgreSQL 14+ (localhost)
- **Diagram Component**: Syncfusion.Blazor.Diagram (latest version compatible with .NET 10)
- **ORM**: Entity Framework Core 10.x

## Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) (LTS)
- PostgreSQL 14+ installed and running locally (default: user `postgres`, password `postgres123`, port 5432)
- Visual Studio 2022+ or VS Code with C# Dev Kit extension
- [Syncfusion Blazor Community License](https://www.syncfusion.com/products/communitylicense) (free for individuals/small teams – required)

## Project Structure
OrgChartShowcase/
├── src/
│   ├── Api/                    # REST API + EF Core
│   ├── BlazorWASMStyle/        # Host project (serves client or can be used for hosting)
│   ├── BlazorWASMStyle.Client/ # Blazor WebAssembly client
│   └── Shared/                 # Shared models (LayoutNode)
├── .gitignore
├── OrgChartShowcase.sln
└── README.md

## Setup Instructions

1. **Clone / Open the Solution**
   ```bash
   git clone <your-repo-url> OrgChartShowcase
   cd OrgChartShowcase
   ```
   Or open the .sln file in Visual Studio.

2. **Restore NuGet Packages**
   ```bash
   dotnet restore
   ```

3. **Configure PostgreSQL Connection (if different from defaults)**
   Edit `src/Api/appsettings.Development.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=orgchart_db;Username=postgres;Password=postgres123;Port=5432"
     }
   }
   ```

4. **Create & Seed the Database**
   From the `src/Api` folder:
   ```bash
   cd src/Api
   dotnet ef database update
   ```

   This creates:
   - Database `orgchart_db`
   - Table `orgchart_layout`
   - Index on `parent_id`
   - Seed rows for the sample organizational chart
   - 18 seed rows (Board → General Manager → departments)

5. **Run the API (in one terminal)**
   ```bash
   cd src/Api
   dotnet run
   ```
   Note the HTTP port printed in the console (e.g., `http://localhost:5015`).

6. **Run the Blazor WebAssembly App**

   Recommended (hosted): run the host project which serves the client:
   ```bash
   cd src/BlazorWASMStyle
   dotnet run
   ```
   Or in Visual Studio set multiple startup projects: start `Api` and `BlazorWASMStyle`.

   Alternative: run the client project during development:
   ```bash
   cd src/BlazorWASMStyle.Client
   dotnet run
   ```
   (Depending on project setup, the client may need the API running separately.)

Open the browser at the port shown in the console (hosted app) or navigate to the client URL.

## Expected Result

- Page loads with "Loading organizational chart..." briefly
- Then renders a hierarchical org chart:
  - Top: "Board"
  - Branches to General Manager, Design Manager, etc.
- Blue rectangular nodes with role text
- Connected with orthogonal lines + arrows

## In Visual Studio:

- Right-click Solution → Set Startup Projects…
- Choose Multiple startup projects
- Set `Api` and `BlazorWASMStyle` to Start

## Extension Ideas

- Add CRUD operations for nodes
- Enable node drag & drop / editing
- Add search/filter by role
- Export diagram to PDF/SVG
- Compare Server vs WASM rendering/performance

## Contributing
We welcome contributions! Fork the repo, make your changes, and submit a pull request. Please follow contribution best practices.

## License
Refer the LICENSE section [here](https://blazor.syncfusion.com/documentation/getting-started/license-key/overview) for details.

## Support and Feedback
- For issues, open a ticket in this repository’s Issues section.
- Explore more Syncfusion® Blazor components at [syncfusion.com](https://www.syncfusion.com/).
- Join the community on [forums.syncfusion.com](https://www.syncfusion.com/forums/blazor-components).

