using Microsoft.EntityFrameworkCore.Migrations;

namespace TestsSystem.SqlData.Migrations
{
    public partial class Answer_add_field_IsSuccessful : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSuccessful",
                table: "Answers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSuccessful",
                table: "Answers");
        }
    }
}
