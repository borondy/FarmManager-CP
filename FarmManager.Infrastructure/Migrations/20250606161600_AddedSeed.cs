using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FarmManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Fields",
                columns: new[] { "Id", "AreaInHectares", "Name" },
                values: new object[,]
                {
                    { 1, 14.699999999999999, "95" },
                    { 2, 4.7999999999999998, "96" },
                    { 3, 2.2999999999999998, "97" },
                    { 4, 1.3999999999999999, "102" },
                    { 5, 3.6000000000000001, "103" },
                    { 6, 2.8999999999999999, "106" },
                    { 7, 8.9000000000000004, "169" },
                    { 8, 2.1000000000000001, "196" },
                    { 9, 11.82, "Kaszáló" },
                    { 10, 7.9000000000000004, "10236" },
                    { 11, 5.1500000000000004, "199" },
                    { 12, 8.4600000000000009, "201" },
                    { 13, 6.8200000000000003, "207" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Fields",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
