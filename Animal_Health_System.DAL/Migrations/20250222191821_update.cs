using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_births_animals_AnimalId",
                table: "births");

            migrationBuilder.DropForeignKey(
                name: "FK_births_farms_FarmId",
                table: "births");

            migrationBuilder.DropIndex(
                name: "IX_births_AnimalId_BirthDate",
                table: "births");

            migrationBuilder.DropIndex(
                name: "IX_births_FarmId",
                table: "births");

            migrationBuilder.DropColumn(
                name: "Numberofloads",
                table: "pregnancies");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "births");

            migrationBuilder.AlterColumn<int>(
                name: "PregnancyId",
                table: "births",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_births_AnimalId",
                table: "births",
                column: "AnimalId");

            migrationBuilder.AddForeignKey(
                name: "FK_births_animals_AnimalId",
                table: "births",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_births_animals_AnimalId",
                table: "births");

            migrationBuilder.DropIndex(
                name: "IX_births_AnimalId",
                table: "births");

            migrationBuilder.AddColumn<int>(
                name: "Numberofloads",
                table: "pregnancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PregnancyId",
                table: "births",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "births",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_births_AnimalId_BirthDate",
                table: "births",
                columns: new[] { "AnimalId", "BirthDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_births_FarmId",
                table: "births",
                column: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_births_animals_AnimalId",
                table: "births",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_births_farms_FarmId",
                table: "births",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
