using Diagram_MySQL.Server.Data;
using LinqToDB;
using LinqToDB.AspNet;
using LinqToDB.DataProvider.MySql;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(o => o.SerializerSettings.ContractResolver = new DefaultContractResolver());

// Configure CORS (Cross-Origin Resource Sharing) for development
// IMPORTANT: This allows the Blazor frontend to make requests to this backend
// Without CORS, browsers block requests between different ports for security reasons
builder.Services.AddCors(options =>
{
    options.AddPolicy("cors", p => p
        .AllowAnyOrigin()      // Allow requests from any domain
        .AllowAnyHeader()      // Allow any HTTP headers
        .AllowAnyMethod()      // Allow GET, POST, PUT, DELETE, etc.
    );
});
// Register LINQ2DB with MySQL provider
builder.Services.AddLinqToDB(
    (sp, options) =>
        options.UseMySql(
            builder.Configuration.GetConnectionString("MySqlConn"),
            MySqlVersion.MySql80,
            MySqlProvider.MySqlConnector
        )
);

// Register AppDataConnection for dependency injection
builder.Services.AddScoped<AppDataConnection>();
var app = builder.Build();

// Apply CORS policy
app.UseCors("cors");

app.UseAuthorization();

app.MapControllers();

app.Run();