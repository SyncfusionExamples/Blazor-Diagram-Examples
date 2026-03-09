using Microsoft.EntityFrameworkCore;
using BlazorWASMStyle.Client.Models;

namespace BlazorWASMStyle.Data;

public class AppDbContext : DbContext
{
    public DbSet<LayoutNode> OrgChartLayouts { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LayoutNode>()
            .ToTable("org_chart_layout")
            .HasKey(n => n.Id);

        modelBuilder.Entity<LayoutNode>()
            .Property(n => n.ParentId)
            .HasColumnName("parent_id");

        modelBuilder.Entity<LayoutNode>()
            .Property(n => n.Role)
            .HasColumnName("role")
            .IsRequired();

        modelBuilder.Entity<LayoutNode>()
            .HasIndex(n => n.ParentId);

        modelBuilder.Entity<LayoutNode>().HasData(
            new LayoutNode { Id = "parent", ParentId = null, Role = "Board" },
            new LayoutNode { Id = "1",      ParentId = "parent", Role = "General Manager" },
            new LayoutNode { Id = "2",      ParentId = "1",      Role = "Human Resource Manager" },
            new LayoutNode { Id = "3",      ParentId = "2",      Role = "Trainers" },
            new LayoutNode { Id = "4",      ParentId = "2",      Role = "Recruiting Team" },
            new LayoutNode { Id = "5",      ParentId = "2",      Role = "Finance Asst. Manager" },
            new LayoutNode { Id = "6",      ParentId = "1",      Role = "Design Manager" },
            new LayoutNode { Id = "7",      ParentId = "6",      Role = "Design Supervisor" },
            new LayoutNode { Id = "8",      ParentId = "6",      Role = "Development Supervisor" },
            new LayoutNode { Id = "9",      ParentId = "6",      Role = "Drafting Supervisor" },
            new LayoutNode { Id = "10",     ParentId = "1",      Role = "Operations Manager" },
            new LayoutNode { Id = "11",     ParentId = "10",     Role = "Statistics Department" },
            new LayoutNode { Id = "12",     ParentId = "10",     Role = "Logistics Department" },
            new LayoutNode { Id = "16",     ParentId = "1",      Role = "Marketing Manager" },
            new LayoutNode { Id = "17",     ParentId = "16",     Role = "Overseas Sales Manager" },
            new LayoutNode { Id = "18",     ParentId = "16",     Role = "Petroleum Manager" },
            new LayoutNode { Id = "20",     ParentId = "16",     Role = "Service Department Manager" },
            new LayoutNode { Id = "21",     ParentId = "16",     Role = "Quality Control Department" }
        );
    }
}
