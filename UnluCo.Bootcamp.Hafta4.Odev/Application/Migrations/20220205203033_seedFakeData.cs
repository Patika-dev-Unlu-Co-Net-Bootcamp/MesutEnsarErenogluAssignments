using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class seedFakeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "CreatedDate", "FirstName", "IsActive", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(2072), "Tim", true, "Robbins" },
                    { 2, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(2357), "Morgan", true, "Freeman" },
                    { 3, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(2360), "Bob", true, "Gunton" },
                    { 4, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(2361), "Marlon", true, "Brando" },
                    { 5, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(2362), "Al", true, "Pacino" },
                    { 6, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(2363), "James", true, "Caan" },
                    { 7, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(2426), "Christian", true, "Bale" },
                    { 8, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(2427), "Heath", true, "Ledger" },
                    { 9, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(2429), "Aaron", true, "Eckhart" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "CreatedDate", "FirstName", "IsActive", "LastName" },
                values: new object[,]
                {
                    { 3, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(1763), "Christoper", true, "Nolan" },
                    { 1, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(1397), "Frank", true, "Darabont" },
                    { 2, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(1759), "Francis", true, "Coppola" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "CreatedDate", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 5, 23, 30, 33, 130, DateTimeKind.Local).AddTicks(5062), true, "Drama" },
                    { 2, new DateTime(2022, 2, 5, 23, 30, 33, 131, DateTimeKind.Local).AddTicks(4237), true, "Crime" },
                    { 3, new DateTime(2022, 2, 5, 23, 30, 33, 131, DateTimeKind.Local).AddTicks(4253), true, "Action" },
                    { 4, new DateTime(2022, 2, 5, 23, 30, 33, 131, DateTimeKind.Local).AddTicks(4256), true, "Adventure" },
                    { 6, new DateTime(2022, 2, 5, 23, 30, 33, 131, DateTimeKind.Local).AddTicks(4257), true, "Romance" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "CreatedDate", "IsActive", "MovieName", "ReleaseDate" },
                values: new object[,]
                {
                    { 2, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(3078), true, "The Godfather", new DateTime(1972, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(2728), true, "The Shawshank Redemption", new DateTime(1994, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2022, 2, 5, 23, 30, 33, 132, DateTimeKind.Local).AddTicks(3082), true, "The Dark Knight", new DateTime(2008, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
