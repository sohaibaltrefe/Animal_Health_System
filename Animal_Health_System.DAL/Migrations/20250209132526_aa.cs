using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class aa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentHealthStatus",
                table: "animals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentHealthStatus",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
