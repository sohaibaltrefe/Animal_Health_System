using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class aaaca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatingId",
                table: "pregnancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_pregnancies_MatingId",
                table: "pregnancies",
                column: "MatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_pregnancies_matings_MatingId",
                table: "pregnancies",
                column: "MatingId",
                principalTable: "matings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pregnancies_matings_MatingId",
                table: "pregnancies");

            migrationBuilder.DropIndex(
                name: "IX_pregnancies_MatingId",
                table: "pregnancies");

            migrationBuilder.DropColumn(
                name: "MatingId",
                table: "pregnancies");
        }
    }
}
