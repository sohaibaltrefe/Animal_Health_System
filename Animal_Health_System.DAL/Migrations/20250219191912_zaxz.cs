using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class zaxz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicalRecords_farms_FarmId",
                table: "medicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_medicalRecords_FarmId",
                table: "medicalRecords");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "medicalRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "medicalRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_medicalRecords_FarmId",
                table: "medicalRecords",
                column: "FarmId");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalRecords_farms_FarmId",
                table: "medicalRecords",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
