using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoAppUi.Migrations
{
    public partial class updateTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "TodoLists",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "TodoLists");
        }
    }
}
