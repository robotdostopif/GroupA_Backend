using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HorrorMovieAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    BirthTown = table.Column<string>(nullable: true),
                    BirthCountry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    BirthTown = table.Column<string>(nullable: true),
                    BirthCountry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GenreId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    BudgetInUsd = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    DirectorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movie_Director_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Director",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movie_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Casting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Character = table.Column<string>(nullable: true),
                    MovieId = table.Column<int>(nullable: true),
                    ActorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Casting_Actor_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Casting_Movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "BirthCountry", "BirthTown", "DOB", "FirstName", "LastName" },
                values: new object[] { 1, "USA", "Burbank, California", new DateTime(1957, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tony", "Moran" });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "BirthCountry", "BirthTown", "DOB", "FirstName", "LastName" },
                values: new object[] { 2, "USA", "Clifton, New Yersey", new DateTime(1973, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vera", "Farmiga" });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "Id", "BirthCountry", "BirthTown", "DOB", "FirstName", "LastName" },
                values: new object[] { 1, "USA", "Carthage, New York", new DateTime(1948, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Carpenter" });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "Id", "BirthCountry", "BirthTown", "DOB", "FirstName", "LastName" },
                values: new object[] { 2, "Malaysia", "Kuching, Sarawak", new DateTime(1977, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "James", "Wan" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Slasher" });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Paranormal" });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "BudgetInUsd", "Country", "DirectorId", "GenreId", "Language", "Length", "Rating", "Title", "Year" },
                values: new object[] { 1, 2000000, "Usa", 1, 1, "English", 91, 7.5999999999999996, "Halloween", 1978 });

            migrationBuilder.InsertData(
                table: "Movie",
                columns: new[] { "Id", "BudgetInUsd", "Country", "DirectorId", "GenreId", "Language", "Length", "Rating", "Title", "Year" },
                values: new object[] { 2, 30000000, "Usa", 2, 2, "English", 112, 8.1999999999999993, "The Conjuring", 2013 });

            migrationBuilder.InsertData(
                table: "Casting",
                columns: new[] { "Id", "ActorId", "Character", "MovieId" },
                values: new object[] { 1, 1, "Michael Myers (age 23)", 1 });

            migrationBuilder.InsertData(
                table: "Casting",
                columns: new[] { "Id", "ActorId", "Character", "MovieId" },
                values: new object[] { 2, 2, "Loraine Warren", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Casting_ActorId",
                table: "Casting",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Casting_MovieId",
                table: "Casting",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_DirectorId",
                table: "Movie",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_GenreId",
                table: "Movie",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casting");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
