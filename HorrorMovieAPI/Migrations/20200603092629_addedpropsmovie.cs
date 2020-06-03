using Microsoft.EntityFrameworkCore.Migrations;

namespace HorrorMovieAPI.Migrations
{
    public partial class addedpropsmovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BudgetInUsd",
                table: "Movie",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Movie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Movie",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Movie",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BudgetInUsd", "Country", "Language", "Rating" },
                values: new object[] { 2000000, "Usa", "English", 7.5999999999999996 });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BudgetInUsd", "Country", "Language", "Rating" },
                values: new object[] { 30000000, "Usa", "English", 8.1999999999999993 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BudgetInUsd",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movie");
        }
    }
}
