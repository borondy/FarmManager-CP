using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Fields",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Fields");
        }
    }
}
