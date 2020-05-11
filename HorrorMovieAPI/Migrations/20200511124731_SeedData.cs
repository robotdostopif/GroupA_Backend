using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorrorMovieAPI.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "BirthCountry", "BirthTown", "DOB", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "USA", "Burbank, California", new DateTime(1957, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tony", "Moran" },
                    { 2, "USA", "Clifton, New Yersey", new DateTime(1973, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vera", "Farmiga" }
                });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "Id", "BirthCountry", "BirthThown", "DOB", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "USA", null, new DateTime(1948, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Carpenter" },
                    { 2, "Malaysia", null, new DateTime(1977, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "Wan" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Slasher" },
                    { 2, "Paranormal" }
                });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "DirectorId", "GenreId", "Length", "Title", "Year" },
                values: new object[] { 1, 1, 1, 91, "Halloween", 1978 });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "DirectorId", "GenreId", "Length", "Title", "Year" },
                values: new object[] { 2, 2, 2, 112, "The Conjuring", 2013 });

            migrationBuilder.InsertData(
                table: "Casting",
                columns: new[] { "Id", "ActorId", "Character", "MovieId" },
                values: new object[] { 1, 1, "Michael Myers (age 23)", 1 });

            migrationBuilder.InsertData(
                table: "Casting",
                columns: new[] { "Id", "ActorId", "Character", "MovieId" },
                values: new object[] { 2, 2, "Loraine Warren", 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Casting",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Casting",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genre",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
