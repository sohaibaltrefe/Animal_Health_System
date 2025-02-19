using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class zxcxx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_animals_animalId",
                table: "vaccineHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_farms_FarmId",
                table: "vaccineHistories");

            migrationBuilder.DropIndex(
                name: "IX_vaccineHistories_animalId",
                table: "vaccineHistories");

            migrationBuilder.DropIndex(
                name: "IX_vaccineHistories_FarmId",
                table: "vaccineHistories");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "vaccineHistories");

            migrationBuilder.DropColumn(
                name: "animalId",
                table: "vaccineHistories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "vaccineHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "animalId",
                table: "vaccineHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_vaccineHistories_animalId",
                table: "vaccineHistories",
                column: "animalId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccineHistories_FarmId",
                table: "vaccineHistories",
                column: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineHistories_animals_animalId",
                table: "vaccineHistories",
                column: "animalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineHistories_farms_FarmId",
                table: "vaccineHistories",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
