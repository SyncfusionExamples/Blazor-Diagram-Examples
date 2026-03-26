using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorWASMStyle.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "org_chart_layout",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    parent_id = table.Column<string>(type: "text", nullable: true),
                    role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_org_chart_layout", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "org_chart_layout",
                columns: new[] { "Id", "parent_id", "role" },
                values: new object[,]
                {
                    { "1", "parent", "General Manager" },
                    { "10", "1", "Operations Manager" },
                    { "11", "10", "Statistics Department" },
                    { "12", "10", "Logistics Department" },
                    { "16", "1", "Marketing Manager" },
                    { "17", "16", "Overseas Sales Manager" },
                    { "18", "16", "Petroleum Manager" },
                    { "2", "1", "Human Resource Manager" },
                    { "20", "16", "Service Department Manager" },
                    { "21", "16", "Quality Control Department" },
                    { "3", "2", "Trainers" },
                    { "4", "2", "Recruiting Team" },
                    { "5", "2", "Finance Asst. Manager" },
                    { "6", "1", "Design Manager" },
                    { "7", "6", "Design Supervisor" },
                    { "8", "6", "Development Supervisor" },
                    { "9", "6", "Drafting Supervisor" },
                    { "parent", null, "Board" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_org_chart_layout_parent_id",
                table: "org_chart_layout",
                column: "parent_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "org_chart_layout");
        }
    }
}
