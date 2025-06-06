using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmManager.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AreaInHectares = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CropRotationPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FieldId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropRotationPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CropRotationPlans_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CropTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    HarvestingPeriodId = table.Column<int>(type: "INTEGER", nullable: true),
                    CropRotationPlanId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CropTypes_CropRotationPlans_CropRotationPlanId",
                        column: x => x.CropRotationPlanId,
                        principalTable: "CropRotationPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MonthPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PeriodStartingMonth = table.Column<int>(type: "INTEGER", nullable: false),
                    PeriodEndingMonth = table.Column<int>(type: "INTEGER", nullable: false),
                    CropTypeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthPeriods_CropTypes_CropTypeId",
                        column: x => x.CropTypeId,
                        principalTable: "CropTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CropRotationPlans_FieldId",
                table: "CropRotationPlans",
                column: "FieldId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CropTypes_CropRotationPlanId",
                table: "CropTypes",
                column: "CropRotationPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_CropTypes_HarvestingPeriodId",
                table: "CropTypes",
                column: "HarvestingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthPeriods_CropTypeId",
                table: "MonthPeriods",
                column: "CropTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CropTypes_MonthPeriods_HarvestingPeriodId",
                table: "CropTypes",
                column: "HarvestingPeriodId",
                principalTable: "MonthPeriods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CropRotationPlans_Fields_FieldId",
                table: "CropRotationPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_CropTypes_CropRotationPlans_CropRotationPlanId",
                table: "CropTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_CropTypes_MonthPeriods_HarvestingPeriodId",
                table: "CropTypes");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "CropRotationPlans");

            migrationBuilder.DropTable(
                name: "MonthPeriods");

            migrationBuilder.DropTable(
                name: "CropTypes");
        }
    }
}
