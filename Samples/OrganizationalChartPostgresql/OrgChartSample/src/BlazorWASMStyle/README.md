# Syncfusion Blazor Diagram – Organizational Chart (WASM + Hosted)

This repository is a hosted Blazor WebAssembly sample that demonstrates a Syncfusion Blazor Diagram-powered organizational chart with a server-side API and EF Core migrations.

Built with .NET 10.

## Project layout (workspace)
- `BlazorWASMStyle.slnx` – solution file
- `BlazorWASMStyle/` – host project (serves the Blazor WASM client and contains the API, EF Core migrations)
  - `BlazorWASMStyle/` (project root)
    - `BlazorWASMStyle.csproj` – hosted server project
    - `Migrations/` – EF Core migrations
    - `Data/` – `AppDbContext` and models
    - `Properties/launchSettings.json` – dev ports (http:5252, https:7042)
    - `wwwroot/` – static assets
- `BlazorWASMStyle.Client/` – Blazor WebAssembly client project
  - `BlazorWASMStyle.Client.csproj`
  - `Program.cs` – registers `HttpClient` and client services
  - `Pages/`, `Layout/`, `Services/` (contains `LayoutService` used by the client)

## Prerequisites
- [.NET 10 SDK]
- PostgreSQL 14+ running locally (default connection string is in `appsettings.json` under `BlazorWASMStyle`)
- Syncfusion license as required by the component

## Quick setup and run (hosted, recommended)

1. Restore packages:

```bash
dotnet restore
```

2. Apply EF Core migrations and seed the database (run from the host project folder):

```bash
cd BlazorWASMStyle
dotnet ef database update
```

3. Run the hosted app (this serves the WASM client and the API):

```bash
cd BlazorWASMStyle
dotnet run
```

By default the dev `launchSettings.json` uses `http://localhost:5252` and `https://localhost:7042`. Use the URL printed by `dotnet run` to open the app.

## Running client or server separately (development)
- To run the server/API only: `cd BlazorWASMStyle && dotnet run`.
- To run the client only (if desired): `cd BlazorWASMStyle.Client && dotnet run` — note the API must be running separately for data calls.

## Common troubleshooting
- Initial "connection refused" errors during first client request: the client now uses `HttpClient` with the correct `BaseAddress`; a short retry is implemented to handle transient startup timing issues.
- If you see component injection errors for `LayoutService` during prerendering, the host project registers a server-side `LayoutService` (HttpClient-backed) so server-side rendering resolves dependencies.

## Visual Studio
- Use Multiple Startup Projects: set `BlazorWASMStyle` (host) to Start. That runs both client and API together.

## Contributing
Fork, modify, and submit a PR. Follow solution coding and project conventions.

## License
Refer to Syncfusion license guidance if you use Syncfusion components in production.

## Support
- Open an issue in this repository or consult Syncfusion docs and forums for component-specific help.

