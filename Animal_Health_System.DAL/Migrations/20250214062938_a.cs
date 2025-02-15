using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medications_medicationStocks_MedicationStockId",
                table: "medications");

            migrationBuilder.DropForeignKey(
                name: "FK_medications_prescriptions_PrescriptionId",
                table: "medications");

            migrationBuilder.DropTable(
                name: "breedingReports");

            migrationBuilder.DropTable(
                name: "healthReports");

            migrationBuilder.DropTable(
                name: "medicationStocks");

            migrationBuilder.DropTable(
                name: "prescriptions");

            migrationBuilder.DropTable(
                name: "productionRecords");

            migrationBuilder.DropTable(
                name: "treatmentPlans");

            migrationBuilder.DropTable(
                name: "vaccineReminders");

            migrationBuilder.DropIndex(
                name: "IX_medications_MedicationStockId",
                table: "medications");

            migrationBuilder.DropIndex(
                name: "IX_medications_PrescriptionId",
                table: "medications");

            migrationBuilder.DropColumn(
                name: "MedicationStockId",
                table: "medications");

            migrationBuilder.DropColumn(
                name: "PrescriptionId",
                table: "medications");

            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "medicalRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "healthStatusLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HealthStatusDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthStatus = table.Column<int>(type: "int", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    MedicalExaminationId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_healthStatusLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_healthStatusLogs_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_healthStatusLogs_medicalExaminations_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "medicalExaminations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_medicalRecords_FarmId",
                table: "medicalRecords",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_healthStatusLogs_AnimalId",
                table: "healthStatusLogs",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_healthStatusLogs_MedicalExaminationId",
                table: "healthStatusLogs",
                column: "MedicalExaminationId");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalRecords_farms_FarmId",
                table: "medicalRecords",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicalRecords_farms_FarmId",
                table: "medicalRecords");

            migrationBuilder.DropTable(
                name: "healthStatusLogs");

            migrationBuilder.DropIndex(
                name: "IX_medicalRecords_FarmId",
                table: "medicalRecords");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "medicalRecords");

            migrationBuilder.AddColumn<int>(
                name: "MedicationStockId",
                table: "medications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrescriptionId",
                table: "medications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "breedingReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    MatingId = table.Column<int>(type: "int", nullable: false),
                    BirthCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FarmId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MatingDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfOffspring = table.Column<int>(type: "int", nullable: false),
                    PregnancyStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breedingReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_breedingReports_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_breedingReports_farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_breedingReports_matings_MatingId",
                        column: x => x.MatingId,
                        principalTable: "matings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "healthReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmId = table.Column<int>(type: "int", nullable: false),
                    FarmStaffId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HealthyAnimals = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SickAnimals = table.Column<int>(type: "int", nullable: false),
                    TotalAnimals = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_healthReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_healthReports_farmStaff_FarmStaffId",
                        column: x => x.FarmStaffId,
                        principalTable: "farmStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_healthReports_farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medicationStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicationStocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalExaminationId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prescriptions_medicalExaminations_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "medicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "productionRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateProduction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityProduced = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeProduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productionRecords_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "treatmentPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalExaminationId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TreatmentDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treatmentPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_treatmentPlans_medicalExaminations_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "medicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vaccineReminders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    VaccineId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsNotified = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReminderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccineReminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vaccineReminders_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vaccineReminders_vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "vaccines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_medications_MedicationStockId",
                table: "medications",
                column: "MedicationStockId");

            migrationBuilder.CreateIndex(
                name: "IX_medications_PrescriptionId",
                table: "medications",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_breedingReports_AnimalId_ReportDate",
                table: "breedingReports",
                columns: new[] { "AnimalId", "ReportDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_breedingReports_FarmId",
                table: "breedingReports",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_breedingReports_MatingId",
                table: "breedingReports",
                column: "MatingId");

            migrationBuilder.CreateIndex(
                name: "IX_healthReports_FarmId_ReportDate",
                table: "healthReports",
                columns: new[] { "FarmId", "ReportDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_healthReports_FarmStaffId",
                table: "healthReports",
                column: "FarmStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_medicationStocks_Name",
                table: "medicationStocks",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_MedicalExaminationId_CreatedAt",
                table: "prescriptions",
                columns: new[] { "MedicalExaminationId", "CreatedAt" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productionRecords_AnimalId_DateProduction",
                table: "productionRecords",
                columns: new[] { "AnimalId", "DateProduction" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_treatmentPlans_MedicalExaminationId",
                table: "treatmentPlans",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_treatmentPlans_Name",
                table: "treatmentPlans",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vaccineReminders_AnimalId_VaccineId",
                table: "vaccineReminders",
                columns: new[] { "AnimalId", "VaccineId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vaccineReminders_VaccineId",
                table: "vaccineReminders",
                column: "VaccineId");

            migrationBuilder.AddForeignKey(
                name: "FK_medications_medicationStocks_MedicationStockId",
                table: "medications",
                column: "MedicationStockId",
                principalTable: "medicationStocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_medications_prescriptions_PrescriptionId",
                table: "medications",
                column: "PrescriptionId",
                principalTable: "prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
