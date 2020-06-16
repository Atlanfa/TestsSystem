using Microsoft.EntityFrameworkCore.Migrations;

namespace TestsSystem.SqlData.Migrations
{
    public partial class Answer_Object_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerDate",
                table: "Answers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Answers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TryCount",
                table: "Answers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerDate",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "TryCount",
                table: "Answers");
        }
    }
}
