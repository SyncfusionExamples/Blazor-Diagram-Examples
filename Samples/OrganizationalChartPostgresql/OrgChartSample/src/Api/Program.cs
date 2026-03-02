using Api.Data;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
        policy.WithOrigins(
            "http://localhost:5069",
            "http://localhost:7042",
            "https://localhost:5069",
            "https://localhost:7042"    // add https variants too
        )
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});

var app = builder.Build();

// Configure middleware
app.UseHttpsRedirection();
app.UseCors("AllowBlazor");
app.UseAuthorization();
app.MapControllers();

app.Run();