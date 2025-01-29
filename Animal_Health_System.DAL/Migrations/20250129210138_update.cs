using System;
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
                name: "FK_farmHealthSummaries_farmHealthSummaries_FarmHealthSummaryId",
                schema: "dbo",
                table: "farmHealthSummaries");

            migrationBuilder.DropTable(
                name: "pregnancyNotifications",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_farmHealthSummaries_FarmHealthSummaryId",
                schema: "dbo",
                table: "farmHealthSummaries");

            migrationBuilder.DropColumn(
                name: "FarmHealthSummaryId",
                schema: "dbo",
                table: "farmHealthSummaries");

            migrationBuilder.DropColumn(
                name: "Age",
                schema: "dbo",
                table: "animals");

            migrationBuilder.RenameColumn(
                name: "Recipients",
                schema: "dbo",
                table: "notifications",
                newName: "RecipientType");

            migrationBuilder.RenameColumn(
                name: "Date",
                schema: "dbo",
                table: "notifications",
                newName: "NotificationDate");

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                schema: "dbo",
                table: "notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PregnancyId",
                schema: "dbo",
                table: "notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Weight",
                schema: "dbo",
                table: "animals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_notifications_AnimalId",
                schema: "dbo",
                table: "notifications",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_PregnancyId",
                schema: "dbo",
                table: "notifications",
                column: "PregnancyId");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_animals_AnimalId",
                schema: "dbo",
                table: "notifications",
                column: "AnimalId",
                principalSchema: "dbo",
                principalTable: "animals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_pregnancies_PregnancyId",
                schema: "dbo",
                table: "notifications",
                column: "PregnancyId",
                principalSchema: "dbo",
                principalTable: "pregnancies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notifications_animals_AnimalId",
                schema: "dbo",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_pregnancies_PregnancyId",
                schema: "dbo",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_AnimalId",
                schema: "dbo",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_PregnancyId",
                schema: "dbo",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "AnimalId",
                schema: "dbo",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "PregnancyId",
                schema: "dbo",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "Weight",
                schema: "dbo",
                table: "animals");

            migrationBuilder.RenameColumn(
                name: "RecipientType",
                schema: "dbo",
                table: "notifications",
                newName: "Recipients");

            migrationBuilder.RenameColumn(
                name: "NotificationDate",
                schema: "dbo",
                table: "notifications",
                newName: "Date");

            migrationBuilder.AddColumn<int>(
                name: "FarmHealthSummaryId",
                schema: "dbo",
                table: "farmHealthSummaries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Age",
                schema: "dbo",
                table: "animals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "pregnancyNotifications",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pregnancyNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pregnancyNotifications_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalSchema: "dbo",
                        principalTable: "animals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_farmHealthSummaries_FarmHealthSummaryId",
                schema: "dbo",
                table: "farmHealthSummaries",
                column: "FarmHealthSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_pregnancyNotifications_AnimalId_NotificationDate",
                schema: "dbo",
                table: "pregnancyNotifications",
                columns: new[] { "AnimalId", "NotificationDate" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_farmHealthSummaries_farmHealthSummaries_FarmHealthSummaryId",
                schema: "dbo",
                table: "farmHealthSummaries",
                column: "FarmHealthSummaryId",
                principalSchema: "dbo",
                principalTable: "farmHealthSummaries",
                principalColumn: "Id");
        }
    }
}
