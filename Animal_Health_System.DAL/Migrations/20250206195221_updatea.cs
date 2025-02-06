using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animalHealthHistories_medicalRecords_MedicalRecordId",
                table: "animalHealthHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_births_farms_FarmId",
                table: "births");

            migrationBuilder.DropForeignKey(
                name: "FK_healthReports_farms_FarmId",
                table: "healthReports");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalExaminations_farmStaff_FarmStaffId",
                table: "medicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalExaminations_medicalRecords_MedicalRecordId",
                table: "medicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_productionRecords_farmStaff_FarmStaffId",
                table: "productionRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineReminders_animals_AnimalId",
                table: "vaccineReminders");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineReminders_vaccines_VaccineId",
                table: "vaccineReminders");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccines_medicalRecords_MedicalRecordId",
                table: "vaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccines_veterinarians_VeterinarianId",
                table: "vaccines");

            migrationBuilder.DropIndex(
                name: "IX_vaccineReminders_AnimalId_VaccineId",
                table: "vaccineReminders");

            migrationBuilder.DropIndex(
                name: "IX_vaccineHistories_AnimalId_VaccineId_AdministrationDate",
                table: "vaccineHistories");

            migrationBuilder.DropIndex(
                name: "IX_productionRecords_AnimalId_DateProduction",
                table: "productionRecords");

            migrationBuilder.DropIndex(
                name: "IX_productionRecords_FarmStaffId",
                table: "productionRecords");

            migrationBuilder.DropIndex(
                name: "IX_prescriptions_MedicalExaminationId_CreatedAt",
                table: "prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_medicalRecords_AnimalId",
                table: "medicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_medicalExaminations_AnimalId_ExaminationDate",
                table: "medicalExaminations");

            migrationBuilder.DropIndex(
                name: "IX_medicalExaminations_FarmStaffId",
                table: "medicalExaminations");

            migrationBuilder.DropIndex(
                name: "IX_matings_MaleAnimalId_FemaleAnimalId_MatingDate",
                table: "matings");

            migrationBuilder.DropIndex(
                name: "IX_healthReports_FarmId_ReportDate",
                table: "healthReports");

            migrationBuilder.DropIndex(
                name: "IX_farmStaff_FarmId_FullName",
                table: "farmStaff");

            migrationBuilder.DropIndex(
                name: "IX_farms_Name_OwnerId",
                table: "farms");

            migrationBuilder.DropIndex(
                name: "IX_farmHealthSummaries_FarmId",
                table: "farmHealthSummaries");

            migrationBuilder.DropIndex(
                name: "IX_breedingReports_AnimalId_ReportDate",
                table: "breedingReports");

            migrationBuilder.DropIndex(
                name: "IX_births_AnimalId_BirthDate",
                table: "births");

            migrationBuilder.DropIndex(
                name: "IX_appointments_AnimalId_AppointmentDate",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_AnimalId_AppointmentDate_VeterinarianId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_animals_FarmId_Name",
                table: "animals");

            migrationBuilder.DropIndex(
                name: "Idx_AnimalHealthHistory_AnimalId_MedicalRecordId",
                table: "animalHealthHistories");

            migrationBuilder.DropColumn(
                name: "FarmStaffId",
                table: "productionRecords");

            migrationBuilder.DropColumn(
                name: "FarmStaffId",
                table: "medicalExaminations");

            migrationBuilder.RenameColumn(
                name: "RecipientId",
                table: "notifications",
                newName: "SenderId");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarianId",
                table: "vaccines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalRecordId",
                table: "vaccines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VaccineId",
                table: "vaccineReminders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "vaccineReminders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarianId",
                table: "vaccineHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VaccineId",
                table: "vaccineHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FarmStaffId",
                table: "vaccineHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "vaccineHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "treatmentPlans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "productionRecords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "notifications",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SenderType",
                table: "notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PrescriptionId",
                table: "medications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicationStockId",
                table: "medications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "medications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "medicalRecords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarianId",
                table: "medicalExaminations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalRecordId",
                table: "medicalExaminations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "medicalExaminations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaleAnimalId",
                table: "matings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FemaleAnimalId",
                table: "matings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                table: "matings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FarmStaffId",
                table: "healthReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "healthReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "farmStaff",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "farms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "farmHealthSummaries",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MatingId",
                table: "breedingReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "breedingReports",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "births",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "births",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarianId",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FarmStaffId",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "appointments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "appointmentHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalRecordId",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "animals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalRecordId",
                table: "animalHealthHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "animalHealthHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "farmVeterinarians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FarmId = table.Column<int>(type: "int", nullable: false),
                    VeterinarianId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farmVeterinarians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_farmVeterinarians_farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_farmVeterinarians_veterinarians_VeterinarianId",
                        column: x => x.VeterinarianId,
                        principalTable: "veterinarians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vaccineReminders_AnimalId_VaccineId",
                table: "vaccineReminders",
                columns: new[] { "AnimalId", "VaccineId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vaccineHistories_AnimalId_VaccineId_AdministrationDate",
                table: "vaccineHistories",
                columns: new[] { "AnimalId", "VaccineId", "AdministrationDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productionRecords_AnimalId_DateProduction",
                table: "productionRecords",
                columns: new[] { "AnimalId", "DateProduction" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_MedicalExaminationId_CreatedAt",
                table: "prescriptions",
                columns: new[] { "MedicalExaminationId", "CreatedAt" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_medicalRecords_AnimalId",
                table: "medicalRecords",
                column: "AnimalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_medicalExaminations_AnimalId_ExaminationDate",
                table: "medicalExaminations",
                columns: new[] { "AnimalId", "ExaminationDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_matings_FarmId",
                table: "matings",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_matings_MaleAnimalId_FemaleAnimalId_MatingDate",
                table: "matings",
                columns: new[] { "MaleAnimalId", "FemaleAnimalId", "MatingDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_healthReports_FarmId_ReportDate",
                table: "healthReports",
                columns: new[] { "FarmId", "ReportDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_farmStaff_FarmId_FullName",
                table: "farmStaff",
                columns: new[] { "FarmId", "FullName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_farms_Name_OwnerId",
                table: "farms",
                columns: new[] { "Name", "OwnerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_farmHealthSummaries_FarmId",
                table: "farmHealthSummaries",
                column: "FarmId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_breedingReports_AnimalId_ReportDate",
                table: "breedingReports",
                columns: new[] { "AnimalId", "ReportDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_births_AnimalId_BirthDate",
                table: "births",
                columns: new[] { "AnimalId", "BirthDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_appointments_AnimalId_AppointmentDate",
                table: "appointments",
                columns: new[] { "AnimalId", "AppointmentDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_appointments_AnimalId_AppointmentDate_VeterinarianId",
                table: "appointments",
                columns: new[] { "AnimalId", "AppointmentDate", "VeterinarianId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_animals_FarmId_Name",
                table: "animals",
                columns: new[] { "FarmId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_AnimalHealthHistory_AnimalId_MedicalRecordId",
                table: "animalHealthHistories",
                columns: new[] { "AnimalId", "MedicalRecordId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_farmVeterinarians_FarmId",
                table: "farmVeterinarians",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_farmVeterinarians_VeterinarianId",
                table: "farmVeterinarians",
                column: "VeterinarianId");

            migrationBuilder.AddForeignKey(
                name: "FK_animalHealthHistories_medicalRecords_MedicalRecordId",
                table: "animalHealthHistories",
                column: "MedicalRecordId",
                principalTable: "medicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_births_farms_FarmId",
                table: "births",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_healthReports_farms_FarmId",
                table: "healthReports",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_matings_farms_FarmId",
                table: "matings",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medicalExaminations_medicalRecords_MedicalRecordId",
                table: "medicalExaminations",
                column: "MedicalRecordId",
                principalTable: "medicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineReminders_animals_AnimalId",
                table: "vaccineReminders",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineReminders_vaccines_VaccineId",
                table: "vaccineReminders",
                column: "VaccineId",
                principalTable: "vaccines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccines_medicalRecords_MedicalRecordId",
                table: "vaccines",
                column: "MedicalRecordId",
                principalTable: "medicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccines_veterinarians_VeterinarianId",
                table: "vaccines",
                column: "VeterinarianId",
                principalTable: "veterinarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animalHealthHistories_medicalRecords_MedicalRecordId",
                table: "animalHealthHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_births_farms_FarmId",
                table: "births");

            migrationBuilder.DropForeignKey(
                name: "FK_healthReports_farms_FarmId",
                table: "healthReports");

            migrationBuilder.DropForeignKey(
                name: "FK_matings_farms_FarmId",
                table: "matings");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalExaminations_medicalRecords_MedicalRecordId",
                table: "medicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineReminders_animals_AnimalId",
                table: "vaccineReminders");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineReminders_vaccines_VaccineId",
                table: "vaccineReminders");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccines_medicalRecords_MedicalRecordId",
                table: "vaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccines_veterinarians_VeterinarianId",
                table: "vaccines");

            migrationBuilder.DropTable(
                name: "farmVeterinarians");

            migrationBuilder.DropIndex(
                name: "IX_vaccineReminders_AnimalId_VaccineId",
                table: "vaccineReminders");

            migrationBuilder.DropIndex(
                name: "IX_vaccineHistories_AnimalId_VaccineId_AdministrationDate",
                table: "vaccineHistories");

            migrationBuilder.DropIndex(
                name: "IX_productionRecords_AnimalId_DateProduction",
                table: "productionRecords");

            migrationBuilder.DropIndex(
                name: "IX_prescriptions_MedicalExaminationId_CreatedAt",
                table: "prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_medicalRecords_AnimalId",
                table: "medicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_medicalExaminations_AnimalId_ExaminationDate",
                table: "medicalExaminations");

            migrationBuilder.DropIndex(
                name: "IX_matings_FarmId",
                table: "matings");

            migrationBuilder.DropIndex(
                name: "IX_matings_MaleAnimalId_FemaleAnimalId_MatingDate",
                table: "matings");

            migrationBuilder.DropIndex(
                name: "IX_healthReports_FarmId_ReportDate",
                table: "healthReports");

            migrationBuilder.DropIndex(
                name: "IX_farmStaff_FarmId_FullName",
                table: "farmStaff");

            migrationBuilder.DropIndex(
                name: "IX_farms_Name_OwnerId",
                table: "farms");

            migrationBuilder.DropIndex(
                name: "IX_farmHealthSummaries_FarmId",
                table: "farmHealthSummaries");

            migrationBuilder.DropIndex(
                name: "IX_breedingReports_AnimalId_ReportDate",
                table: "breedingReports");

            migrationBuilder.DropIndex(
                name: "IX_births_AnimalId_BirthDate",
                table: "births");

            migrationBuilder.DropIndex(
                name: "IX_appointments_AnimalId_AppointmentDate",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_AnimalId_AppointmentDate_VeterinarianId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_animals_FarmId_Name",
                table: "animals");

            migrationBuilder.DropIndex(
                name: "Idx_AnimalHealthHistory_AnimalId_MedicalRecordId",
                table: "animalHealthHistories");

            migrationBuilder.DropColumn(
                name: "SenderType",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "FarmId",
                table: "matings");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "notifications",
                newName: "RecipientId");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarianId",
                table: "vaccines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalRecordId",
                table: "vaccines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VaccineId",
                table: "vaccineReminders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "vaccineReminders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarianId",
                table: "vaccineHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VaccineId",
                table: "vaccineHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FarmStaffId",
                table: "vaccineHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "vaccineHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "treatmentPlans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "productionRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FarmStaffId",
                table: "productionRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "prescriptions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "notifications",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "PrescriptionId",
                table: "medications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MedicationStockId",
                table: "medications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalExaminationId",
                table: "medications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "medicalRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarianId",
                table: "medicalExaminations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalRecordId",
                table: "medicalExaminations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "medicalExaminations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FarmStaffId",
                table: "medicalExaminations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaleAnimalId",
                table: "matings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FemaleAnimalId",
                table: "matings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FarmStaffId",
                table: "healthReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "healthReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "farmStaff",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "farms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "farmHealthSummaries",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MatingId",
                table: "breedingReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "breedingReports",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "births",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "births",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VeterinarianId",
                table: "appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FarmStaffId",
                table: "appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "appointments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "appointmentHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalRecordId",
                table: "animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FarmId",
                table: "animals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalRecordId",
                table: "animalHealthHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AnimalId",
                table: "animalHealthHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_vaccineReminders_AnimalId_VaccineId",
                table: "vaccineReminders",
                columns: new[] { "AnimalId", "VaccineId" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL AND [VaccineId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_vaccineHistories_AnimalId_VaccineId_AdministrationDate",
                table: "vaccineHistories",
                columns: new[] { "AnimalId", "VaccineId", "AdministrationDate" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL AND [VaccineId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_productionRecords_AnimalId_DateProduction",
                table: "productionRecords",
                columns: new[] { "AnimalId", "DateProduction" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_productionRecords_FarmStaffId",
                table: "productionRecords",
                column: "FarmStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_MedicalExaminationId_CreatedAt",
                table: "prescriptions",
                columns: new[] { "MedicalExaminationId", "CreatedAt" },
                unique: true,
                filter: "[MedicalExaminationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_medicalRecords_AnimalId",
                table: "medicalRecords",
                column: "AnimalId",
                unique: true,
                filter: "[AnimalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_medicalExaminations_AnimalId_ExaminationDate",
                table: "medicalExaminations",
                columns: new[] { "AnimalId", "ExaminationDate" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_medicalExaminations_FarmStaffId",
                table: "medicalExaminations",
                column: "FarmStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_matings_MaleAnimalId_FemaleAnimalId_MatingDate",
                table: "matings",
                columns: new[] { "MaleAnimalId", "FemaleAnimalId", "MatingDate" },
                unique: true,
                filter: "[MaleAnimalId] IS NOT NULL AND [FemaleAnimalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_healthReports_FarmId_ReportDate",
                table: "healthReports",
                columns: new[] { "FarmId", "ReportDate" },
                unique: true,
                filter: "[FarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_farmStaff_FarmId_FullName",
                table: "farmStaff",
                columns: new[] { "FarmId", "FullName" },
                unique: true,
                filter: "[FarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_farms_Name_OwnerId",
                table: "farms",
                columns: new[] { "Name", "OwnerId" },
                unique: true,
                filter: "[OwnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_farmHealthSummaries_FarmId",
                table: "farmHealthSummaries",
                column: "FarmId",
                unique: true,
                filter: "[FarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_breedingReports_AnimalId_ReportDate",
                table: "breedingReports",
                columns: new[] { "AnimalId", "ReportDate" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_births_AnimalId_BirthDate",
                table: "births",
                columns: new[] { "AnimalId", "BirthDate" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_AnimalId_AppointmentDate",
                table: "appointments",
                columns: new[] { "AnimalId", "AppointmentDate" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_AnimalId_AppointmentDate_VeterinarianId",
                table: "appointments",
                columns: new[] { "AnimalId", "AppointmentDate", "VeterinarianId" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL AND [VeterinarianId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_animals_FarmId_Name",
                table: "animals",
                columns: new[] { "FarmId", "Name" },
                unique: true,
                filter: "[FarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "Idx_AnimalHealthHistory_AnimalId_MedicalRecordId",
                table: "animalHealthHistories",
                columns: new[] { "AnimalId", "MedicalRecordId" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL AND [MedicalRecordId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_animalHealthHistories_medicalRecords_MedicalRecordId",
                table: "animalHealthHistories",
                column: "MedicalRecordId",
                principalTable: "medicalRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_births_farms_FarmId",
                table: "births",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_healthReports_farms_FarmId",
                table: "healthReports",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalExaminations_farmStaff_FarmStaffId",
                table: "medicalExaminations",
                column: "FarmStaffId",
                principalTable: "farmStaff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_medicalExaminations_medicalRecords_MedicalRecordId",
                table: "medicalExaminations",
                column: "MedicalRecordId",
                principalTable: "medicalRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_productionRecords_farmStaff_FarmStaffId",
                table: "productionRecords",
                column: "FarmStaffId",
                principalTable: "farmStaff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineReminders_animals_AnimalId",
                table: "vaccineReminders",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineReminders_vaccines_VaccineId",
                table: "vaccineReminders",
                column: "VaccineId",
                principalTable: "vaccines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vaccines_medicalRecords_MedicalRecordId",
                table: "vaccines",
                column: "MedicalRecordId",
                principalTable: "medicalRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vaccines_veterinarians_VeterinarianId",
                table: "vaccines",
                column: "VeterinarianId",
                principalTable: "veterinarians",
                principalColumn: "Id");
        }
    }
}
