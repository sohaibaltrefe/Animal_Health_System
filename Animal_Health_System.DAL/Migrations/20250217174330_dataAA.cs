using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class dataAA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_farmStaff_FarmStaffId",
                table: "vaccineHistories");

            migrationBuilder.DropIndex(
                name: "IX_vaccineHistories_FarmStaffId",
                table: "vaccineHistories");

            migrationBuilder.DropColumn(
                name: "FarmStaffId",
                table: "vaccineHistories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FarmStaffId",
                table: "vaccineHistories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_vaccineHistories_FarmStaffId",
                table: "vaccineHistories",
                column: "FarmStaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineHistories_farmStaff_FarmStaffId",
                table: "vaccineHistories",
                column: "FarmStaffId",
                principalTable: "farmStaff",
                principalColumn: "Id");
        }
    }
}
