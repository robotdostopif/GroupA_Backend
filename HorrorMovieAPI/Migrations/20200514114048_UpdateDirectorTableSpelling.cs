using Microsoft.EntityFrameworkCore.Migrations;

namespace HorrorMovieAPI.Migrations
{
    public partial class UpdateDirectorTableSpelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthThown",
                table: "Director");

            migrationBuilder.AddColumn<string>(
                name: "BirthTown",
                table: "Director",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Director",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthTown",
                value: "Carthage, New York");

            migrationBuilder.UpdateData(
                table: "Director",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthTown",
                value: "Kuching, Sarawak");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthTown",
                table: "Director");

            migrationBuilder.AddColumn<string>(
                name: "BirthThown",
                table: "Director",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
