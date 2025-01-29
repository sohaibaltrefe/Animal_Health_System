using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class aaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animalHealthHistories_medicalRecords_MedicalRecordiD",
                table: "animalHealthHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_animals_farms_FarmId",
                table: "animals");

            migrationBuilder.DropForeignKey(
                name: "FK_animals_medicalRecords_MedicalRecordId",
                table: "animals");

            migrationBuilder.DropForeignKey(
                name: "FK_appointmentHistories_appointments_AppointmentId",
                table: "appointmentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_animals_AnimalId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_owners_OwnerId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_veterinarians_VeterinarianId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_births_animals_AnimalId",
                table: "births");

            migrationBuilder.DropForeignKey(
                name: "FK_births_farms_FarmId",
                table: "births");

            migrationBuilder.DropForeignKey(
                name: "FK_births_pregnancies_PregnancyId",
                table: "births");

            migrationBuilder.DropForeignKey(
                name: "FK_breedingReports_animals_AnimalId",
                table: "breedingReports");

            migrationBuilder.DropForeignKey(
                name: "FK_breedingReports_matings_MatingId",
                table: "breedingReports");

            migrationBuilder.DropForeignKey(
                name: "FK_farms_owners_OwnerId",
                table: "farms");

            migrationBuilder.DropForeignKey(
                name: "FK_farmStaff_farms_FarmId",
                table: "farmStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_farmStaff_veterinarians_VeterinarianId",
                table: "farmStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalExaminations_animals_AnimalId",
                table: "medicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalExaminations_veterinarians_VeterinarianId",
                table: "medicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_medications_medicalExaminations_MedicalExaminationId",
                table: "medications");

            migrationBuilder.DropForeignKey(
                name: "FK_medications_medicationStocks_MedicationStockId",
                table: "medications");

            migrationBuilder.DropForeignKey(
                name: "FK_medications_prescriptions_PrescriptionId",
                table: "medications");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_farmStaff_FarmStaffId",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_owners_RecipientId",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_veterinarians_RecipientId",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_pregnancies_animals_AnimalId",
                table: "pregnancies");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_animals_AnimalId",
                table: "vaccineHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_vaccines_VaccineId",
                table: "vaccineHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_veterinarians_VeterinarianId",
                table: "vaccineHistories");

            migrationBuilder.DropIndex(
                name: "IX_treatmentPlans_MedicalExaminationId",
                table: "treatmentPlans");

            migrationBuilder.DropIndex(
                name: "IX_notifications_RecipientId",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_farmStaff_VeterinarianId",
                table: "farmStaff");

            migrationBuilder.DropIndex(
                name: "IX_animals_MedicalRecordId",
                table: "animals");

            migrationBuilder.DropIndex(
                name: "Idx_AnimalHealthHistory_AnimalId_MedicalRecordId",
                table: "animalHealthHistories");

            migrationBuilder.DropColumn(
                name: "PreviousDiseases",
                table: "medicalRecords");

            migrationBuilder.DropColumn(
                name: "VeterinarianId",
                table: "farmStaff");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "veterinarians",
                newName: "veterinarians",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "vaccines",
                newName: "vaccines",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "vaccineReminders",
                newName: "vaccineReminders",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "vaccineHistories",
                newName: "vaccineHistories",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "treatmentPlans",
                newName: "treatmentPlans",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "productionRecords",
                newName: "productionRecords",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "prescriptions",
                newName: "prescriptions",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "pregnancyNotifications",
                newName: "pregnancyNotifications",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "pregnancies",
                newName: "pregnancies",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "owners",
                newName: "owners",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "notifications",
                newName: "notifications",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "medicationStocks",
                newName: "medicationStocks",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "medications",
                newName: "medications",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "medicalRecords",
                newName: "medicalRecords",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "medicalExaminations",
                newName: "medicalExaminations",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "matings",
                newName: "matings",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "healthReports",
                newName: "healthReports",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "farmStaff",
                newName: "farmStaff",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "farms",
                newName: "farms",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "farmHealthSummaries",
                newName: "farmHealthSummaries",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "breedingReports",
                newName: "breedingReports",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "births",
                newName: "births",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "appointments",
                newName: "appointments",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "appointmentHistories",
                newName: "appointmentHistories",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "animals",
                newName: "animals",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "animalHealthHistories",
                newName: "animalHealthHistories",
                newSchema: "dbo");

            migrationBuilder.RenameColumn(
                name: "Type",
                schema: "dbo",
                table: "productionRecords",
                newName: "TypeProduction");

            migrationBuilder.RenameColumn(
                name: "Date",
                schema: "dbo",
                table: "productionRecords",
                newName: "DateProduction");

            migrationBuilder.RenameIndex(
                name: "IX_productionRecords_AnimalId_Date",
                schema: "dbo",
                table: "productionRecords",
                newName: "IX_productionRecords_AnimalId_DateProduction");

            migrationBuilder.RenameColumn(
                name: "Recipient",
                schema: "dbo",
                table: "notifications",
                newName: "Recipients");

            migrationBuilder.RenameColumn(
                name: "Role",
                schema: "dbo",
                table: "farmStaff",
                newName: "JobTitle");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                schema: "dbo",
                table: "farms",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                schema: "dbo",
                table: "appointments",
                newName: "FarmId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_OwnerId",
                schema: "dbo",
                table: "appointments",
                newName: "IX_appointments_FarmId");

            migrationBuilder.RenameColumn(
                name: "MedicalRecordiD",
                schema: "dbo",
                table: "animalHealthHistories",
                newName: "MedicalRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_animalHealthHistories_MedicalRecordiD",
                schema: "dbo",
                table: "animalHealthHistories",
                newName: "IX_animalHealthHistories_MedicalRecordId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "veterinarians",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "veterinarians",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "vaccines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "vaccines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "vaccineReminders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "vaccineReminders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "vaccineHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "vaccineHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "treatmentPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "treatmentPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "productionRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "productionRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "prescriptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "pregnancyNotifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "pregnancyNotifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "pregnancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "pregnancies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "owners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "owners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FarmStaffId",
                schema: "dbo",
                table: "notifications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                schema: "dbo",
                table: "notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VeterinarianId",
                schema: "dbo",
                table: "notifications",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "medications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "medications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "medicalRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "medicalRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "medicalExaminations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "medicalExaminations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "matings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "matings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "healthReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "healthReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "farmStaff",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "farmStaff",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateHired",
                schema: "dbo",
                table: "farmStaff",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "farms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "farmHealthSummaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "farmHealthSummaries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FarmHealthSummaryId",
                schema: "dbo",
                table: "farmHealthSummaries",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "breedingReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "breedingReports",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FarmId",
                schema: "dbo",
                table: "breedingReports",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "births",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "births",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                schema: "dbo",
                table: "appointments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "appointmentHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "appointmentHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "animals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "animals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "animalHealthHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "dbo",
                table: "animalHealthHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_treatmentPlans_MedicalExaminationId",
                schema: "dbo",
                table: "treatmentPlans",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_OwnerId",
                schema: "dbo",
                table: "notifications",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_VeterinarianId",
                schema: "dbo",
                table: "notifications",
                column: "VeterinarianId");

            migrationBuilder.CreateIndex(
                name: "IX_farmHealthSummaries_FarmHealthSummaryId",
                schema: "dbo",
                table: "farmHealthSummaries",
                column: "FarmHealthSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_breedingReports_FarmId",
                schema: "dbo",
                table: "breedingReports",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "Idx_AnimalHealthHistory_AnimalId_MedicalRecordId",
                schema: "dbo",
                table: "animalHealthHistories",
                columns: new[] { "AnimalId", "MedicalRecordId" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL AND [MedicalRecordId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_animalHealthHistories_medicalRecords_MedicalRecordId",
                schema: "dbo",
                table: "animalHealthHistories",
                column: "MedicalRecordId",
                principalSchema: "dbo",
                principalTable: "medicalRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_animals_farms_FarmId",
                schema: "dbo",
                table: "animals",
                column: "FarmId",
                principalSchema: "dbo",
                principalTable: "farms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointmentHistories_appointments_AppointmentId",
                schema: "dbo",
                table: "appointmentHistories",
                column: "AppointmentId",
                principalSchema: "dbo",
                principalTable: "appointments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_animals_AnimalId",
                schema: "dbo",
                table: "appointments",
                column: "AnimalId",
                principalSchema: "dbo",
                principalTable: "animals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_farms_FarmId",
                schema: "dbo",
                table: "appointments",
                column: "FarmId",
                principalSchema: "dbo",
                principalTable: "farms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_veterinarians_VeterinarianId",
                schema: "dbo",
                table: "appointments",
                column: "VeterinarianId",
                principalSchema: "dbo",
                principalTable: "veterinarians",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_births_animals_AnimalId",
                schema: "dbo",
                table: "births",
                column: "AnimalId",
                principalSchema: "dbo",
                principalTable: "animals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_births_farms_FarmId",
                schema: "dbo",
                table: "births",
                column: "FarmId",
                principalSchema: "dbo",
                principalTable: "farms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_births_pregnancies_PregnancyId",
                schema: "dbo",
                table: "births",
                column: "PregnancyId",
                principalSchema: "dbo",
                principalTable: "pregnancies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_breedingReports_animals_AnimalId",
                schema: "dbo",
                table: "breedingReports",
                column: "AnimalId",
                principalSchema: "dbo",
                principalTable: "animals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_breedingReports_farms_FarmId",
                schema: "dbo",
                table: "breedingReports",
                column: "FarmId",
                principalSchema: "dbo",
                principalTable: "farms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_breedingReports_matings_MatingId",
                schema: "dbo",
                table: "breedingReports",
                column: "MatingId",
                principalSchema: "dbo",
                principalTable: "matings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_farmHealthSummaries_farmHealthSummaries_FarmHealthSummaryId",
                schema: "dbo",
                table: "farmHealthSummaries",
                column: "FarmHealthSummaryId",
                principalSchema: "dbo",
                principalTable: "farmHealthSummaries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_farms_owners_OwnerId",
                schema: "dbo",
                table: "farms",
                column: "OwnerId",
                principalSchema: "dbo",
                principalTable: "owners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_farmStaff_farms_FarmId",
                schema: "dbo",
                table: "farmStaff",
                column: "FarmId",
                principalSchema: "dbo",
                principalTable: "farms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalExaminations_animals_AnimalId",
                schema: "dbo",
                table: "medicalExaminations",
                column: "AnimalId",
                principalSchema: "dbo",
                principalTable: "animals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalExaminations_veterinarians_VeterinarianId",
                schema: "dbo",
                table: "medicalExaminations",
                column: "VeterinarianId",
                principalSchema: "dbo",
                principalTable: "veterinarians",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalRecords_animals_AnimalId",
                schema: "dbo",
                table: "medicalRecords",
                column: "AnimalId",
                principalSchema: "dbo",
                principalTable: "animals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_medications_medicalExaminations_MedicalExaminationId",
                schema: "dbo",
                table: "medications",
                column: "MedicalExaminationId",
                principalSchema: "dbo",
                principalTable: "medicalExaminations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_medications_medicationStocks_MedicationStockId",
                schema: "dbo",
                table: "medications",
                column: "MedicationStockId",
                principalSchema: "dbo",
                principalTable: "medicationStocks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_medications_prescriptions_PrescriptionId",
                schema: "dbo",
                table: "medications",
                column: "PrescriptionId",
                principalSchema: "dbo",
                principalTable: "prescriptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_farmStaff_FarmStaffId",
                schema: "dbo",
                table: "notifications",
                column: "FarmStaffId",
                principalSchema: "dbo",
                principalTable: "farmStaff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_owners_OwnerId",
                schema: "dbo",
                table: "notifications",
                column: "OwnerId",
                principalSchema: "dbo",
                principalTable: "owners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_veterinarians_VeterinarianId",
                schema: "dbo",
                table: "notifications",
                column: "VeterinarianId",
                principalSchema: "dbo",
                principalTable: "veterinarians",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_pregnancies_animals_AnimalId",
                schema: "dbo",
                table: "pregnancies",
                column: "AnimalId",
                principalSchema: "dbo",
                principalTable: "animals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineHistories_animals_AnimalId",
                schema: "dbo",
                table: "vaccineHistories",
                column: "AnimalId",
                principalSchema: "dbo",
                principalTable: "animals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineHistories_vaccines_VaccineId",
                schema: "dbo",
                table: "vaccineHistories",
                column: "VaccineId",
                principalSchema: "dbo",
                principalTable: "vaccines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineHistories_veterinarians_VeterinarianId",
                schema: "dbo",
                table: "vaccineHistories",
                column: "VeterinarianId",
                principalSchema: "dbo",
                principalTable: "veterinarians",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animalHealthHistories_medicalRecords_MedicalRecordId",
                schema: "dbo",
                table: "animalHealthHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_animals_farms_FarmId",
                schema: "dbo",
                table: "animals");

            migrationBuilder.DropForeignKey(
                name: "FK_appointmentHistories_appointments_AppointmentId",
                schema: "dbo",
                table: "appointmentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_animals_AnimalId",
                schema: "dbo",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_farms_FarmId",
                schema: "dbo",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_veterinarians_VeterinarianId",
                schema: "dbo",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_births_animals_AnimalId",
                schema: "dbo",
                table: "births");

            migrationBuilder.DropForeignKey(
                name: "FK_births_farms_FarmId",
                schema: "dbo",
                table: "births");

            migrationBuilder.DropForeignKey(
                name: "FK_births_pregnancies_PregnancyId",
                schema: "dbo",
                table: "births");

            migrationBuilder.DropForeignKey(
                name: "FK_breedingReports_animals_AnimalId",
                schema: "dbo",
                table: "breedingReports");

            migrationBuilder.DropForeignKey(
                name: "FK_breedingReports_farms_FarmId",
                schema: "dbo",
                table: "breedingReports");

            migrationBuilder.DropForeignKey(
                name: "FK_breedingReports_matings_MatingId",
                schema: "dbo",
                table: "breedingReports");

            migrationBuilder.DropForeignKey(
                name: "FK_farmHealthSummaries_farmHealthSummaries_FarmHealthSummaryId",
                schema: "dbo",
                table: "farmHealthSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_farms_owners_OwnerId",
                schema: "dbo",
                table: "farms");

            migrationBuilder.DropForeignKey(
                name: "FK_farmStaff_farms_FarmId",
                schema: "dbo",
                table: "farmStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalExaminations_animals_AnimalId",
                schema: "dbo",
                table: "medicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalExaminations_veterinarians_VeterinarianId",
                schema: "dbo",
                table: "medicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalRecords_animals_AnimalId",
                schema: "dbo",
                table: "medicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_medications_medicalExaminations_MedicalExaminationId",
                schema: "dbo",
                table: "medications");

            migrationBuilder.DropForeignKey(
                name: "FK_medications_medicationStocks_MedicationStockId",
                schema: "dbo",
                table: "medications");

            migrationBuilder.DropForeignKey(
                name: "FK_medications_prescriptions_PrescriptionId",
                schema: "dbo",
                table: "medications");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_farmStaff_FarmStaffId",
                schema: "dbo",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_owners_OwnerId",
                schema: "dbo",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_veterinarians_VeterinarianId",
                schema: "dbo",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_pregnancies_animals_AnimalId",
                schema: "dbo",
                table: "pregnancies");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_animals_AnimalId",
                schema: "dbo",
                table: "vaccineHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_vaccines_VaccineId",
                schema: "dbo",
                table: "vaccineHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_veterinarians_VeterinarianId",
                schema: "dbo",
                table: "vaccineHistories");

            migrationBuilder.DropIndex(
                name: "IX_treatmentPlans_MedicalExaminationId",
                schema: "dbo",
                table: "treatmentPlans");

            migrationBuilder.DropIndex(
                name: "IX_notifications_OwnerId",
                schema: "dbo",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_VeterinarianId",
                schema: "dbo",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_farmHealthSummaries_FarmHealthSummaryId",
                schema: "dbo",
                table: "farmHealthSummaries");

            migrationBuilder.DropIndex(
                name: "IX_breedingReports_FarmId",
                schema: "dbo",
                table: "breedingReports");

            migrationBuilder.DropIndex(
                name: "Idx_AnimalHealthHistory_AnimalId_MedicalRecordId",
                schema: "dbo",
                table: "animalHealthHistories");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                schema: "dbo",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "VeterinarianId",
                schema: "dbo",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "dbo",
                table: "medicalRecords");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "dbo",
                table: "medicalRecords");

            migrationBuilder.DropColumn(
                name: "DateHired",
                schema: "dbo",
                table: "farmStaff");

            migrationBuilder.DropColumn(
                name: "FarmHealthSummaryId",
                schema: "dbo",
                table: "farmHealthSummaries");

            migrationBuilder.DropColumn(
                name: "FarmId",
                schema: "dbo",
                table: "breedingReports");

            migrationBuilder.DropColumn(
                name: "EndDate",
                schema: "dbo",
                table: "appointments");

            migrationBuilder.RenameTable(
                name: "veterinarians",
                schema: "dbo",
                newName: "veterinarians");

            migrationBuilder.RenameTable(
                name: "vaccines",
                schema: "dbo",
                newName: "vaccines");

            migrationBuilder.RenameTable(
                name: "vaccineReminders",
                schema: "dbo",
                newName: "vaccineReminders");

            migrationBuilder.RenameTable(
                name: "vaccineHistories",
                schema: "dbo",
                newName: "vaccineHistories");

            migrationBuilder.RenameTable(
                name: "treatmentPlans",
                schema: "dbo",
                newName: "treatmentPlans");

            migrationBuilder.RenameTable(
                name: "productionRecords",
                schema: "dbo",
                newName: "productionRecords");

            migrationBuilder.RenameTable(
                name: "prescriptions",
                schema: "dbo",
                newName: "prescriptions");

            migrationBuilder.RenameTable(
                name: "pregnancyNotifications",
                schema: "dbo",
                newName: "pregnancyNotifications");

            migrationBuilder.RenameTable(
                name: "pregnancies",
                schema: "dbo",
                newName: "pregnancies");

            migrationBuilder.RenameTable(
                name: "owners",
                schema: "dbo",
                newName: "owners");

            migrationBuilder.RenameTable(
                name: "notifications",
                schema: "dbo",
                newName: "notifications");

            migrationBuilder.RenameTable(
                name: "medicationStocks",
                schema: "dbo",
                newName: "medicationStocks");

            migrationBuilder.RenameTable(
                name: "medications",
                schema: "dbo",
                newName: "medications");

            migrationBuilder.RenameTable(
                name: "medicalRecords",
                schema: "dbo",
                newName: "medicalRecords");

            migrationBuilder.RenameTable(
                name: "medicalExaminations",
                schema: "dbo",
                newName: "medicalExaminations");

            migrationBuilder.RenameTable(
                name: "matings",
                schema: "dbo",
                newName: "matings");

            migrationBuilder.RenameTable(
                name: "healthReports",
                schema: "dbo",
                newName: "healthReports");

            migrationBuilder.RenameTable(
                name: "farmStaff",
                schema: "dbo",
                newName: "farmStaff");

            migrationBuilder.RenameTable(
                name: "farms",
                schema: "dbo",
                newName: "farms");

            migrationBuilder.RenameTable(
                name: "farmHealthSummaries",
                schema: "dbo",
                newName: "farmHealthSummaries");

            migrationBuilder.RenameTable(
                name: "breedingReports",
                schema: "dbo",
                newName: "breedingReports");

            migrationBuilder.RenameTable(
                name: "births",
                schema: "dbo",
                newName: "births");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "dbo",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "dbo",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "dbo",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "dbo",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "dbo",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "dbo",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "dbo",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "appointments",
                schema: "dbo",
                newName: "appointments");

            migrationBuilder.RenameTable(
                name: "appointmentHistories",
                schema: "dbo",
                newName: "appointmentHistories");

            migrationBuilder.RenameTable(
                name: "animals",
                schema: "dbo",
                newName: "animals");

            migrationBuilder.RenameTable(
                name: "animalHealthHistories",
                schema: "dbo",
                newName: "animalHealthHistories");

            migrationBuilder.RenameColumn(
                name: "TypeProduction",
                table: "productionRecords",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "DateProduction",
                table: "productionRecords",
                newName: "Date");

            migrationBuilder.RenameIndex(
                name: "IX_productionRecords_AnimalId_DateProduction",
                table: "productionRecords",
                newName: "IX_productionRecords_AnimalId_Date");

            migrationBuilder.RenameColumn(
                name: "Recipients",
                table: "notifications",
                newName: "Recipient");

            migrationBuilder.RenameColumn(
                name: "JobTitle",
                table: "farmStaff",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "farms",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "FarmId",
                table: "appointments",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_FarmId",
                table: "appointments",
                newName: "IX_appointments_OwnerId");

            migrationBuilder.RenameColumn(
                name: "MedicalRecordId",
                table: "animalHealthHistories",
                newName: "MedicalRecordiD");

            migrationBuilder.RenameIndex(
                name: "IX_animalHealthHistories_MedicalRecordId",
                table: "animalHealthHistories",
                newName: "IX_animalHealthHistories_MedicalRecordiD");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "veterinarians",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "veterinarians",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "vaccines",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "vaccines",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "vaccineReminders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "vaccineReminders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "vaccineHistories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "vaccineHistories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "treatmentPlans",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "treatmentPlans",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "productionRecords",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "productionRecords",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "prescriptions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "pregnancyNotifications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "pregnancyNotifications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "pregnancies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "pregnancies",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "owners",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "owners",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "notifications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "FarmStaffId",
                table: "notifications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "notifications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "medications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "medications",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "PreviousDiseases",
                table: "medicalRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "medicalExaminations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "medicalExaminations",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "matings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "matings",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "healthReports",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "healthReports",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "farmStaff",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "farmStaff",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "VeterinarianId",
                table: "farmStaff",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "farms",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "farms",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "farmHealthSummaries",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "farmHealthSummaries",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "breedingReports",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "breedingReports",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "births",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "births",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "appointments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "appointments",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "appointmentHistories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "appointmentHistories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "animals",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "animals",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "animalHealthHistories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "animalHealthHistories",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_treatmentPlans_MedicalExaminationId",
                table: "treatmentPlans",
                column: "MedicalExaminationId",
                unique: true,
                filter: "[MedicalExaminationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_RecipientId",
                table: "notifications",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_farmStaff_VeterinarianId",
                table: "farmStaff",
                column: "VeterinarianId");

            migrationBuilder.CreateIndex(
                name: "IX_animals_MedicalRecordId",
                table: "animals",
                column: "MedicalRecordId",
                unique: true,
                filter: "[MedicalRecordId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "Idx_AnimalHealthHistory_AnimalId_MedicalRecordId",
                table: "animalHealthHistories",
                columns: new[] { "AnimalId", "MedicalRecordiD" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL AND [MedicalRecordiD] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_animalHealthHistories_medicalRecords_MedicalRecordiD",
                table: "animalHealthHistories",
                column: "MedicalRecordiD",
                principalTable: "medicalRecords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_animals_farms_FarmId",
                table: "animals",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_animals_medicalRecords_MedicalRecordId",
                table: "animals",
                column: "MedicalRecordId",
                principalTable: "medicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_appointmentHistories_appointments_AppointmentId",
                table: "appointmentHistories",
                column: "AppointmentId",
                principalTable: "appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_animals_AnimalId",
                table: "appointments",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_owners_OwnerId",
                table: "appointments",
                column: "OwnerId",
                principalTable: "owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_veterinarians_VeterinarianId",
                table: "appointments",
                column: "VeterinarianId",
                principalTable: "veterinarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_births_animals_AnimalId",
                table: "births",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_births_farms_FarmId",
                table: "births",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_births_pregnancies_PregnancyId",
                table: "births",
                column: "PregnancyId",
                principalTable: "pregnancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_breedingReports_animals_AnimalId",
                table: "breedingReports",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_breedingReports_matings_MatingId",
                table: "breedingReports",
                column: "MatingId",
                principalTable: "matings",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_farms_owners_OwnerId",
                table: "farms",
                column: "OwnerId",
                principalTable: "owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_farmStaff_farms_FarmId",
                table: "farmStaff",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_farmStaff_veterinarians_VeterinarianId",
                table: "farmStaff",
                column: "VeterinarianId",
                principalTable: "veterinarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_medicalExaminations_animals_AnimalId",
                table: "medicalExaminations",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_medicalExaminations_veterinarians_VeterinarianId",
                table: "medicalExaminations",
                column: "VeterinarianId",
                principalTable: "veterinarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_medications_medicalExaminations_MedicalExaminationId",
                table: "medications",
                column: "MedicalExaminationId",
                principalTable: "medicalExaminations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_medications_medicationStocks_MedicationStockId",
                table: "medications",
                column: "MedicationStockId",
                principalTable: "medicationStocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_medications_prescriptions_PrescriptionId",
                table: "medications",
                column: "PrescriptionId",
                principalTable: "prescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_farmStaff_FarmStaffId",
                table: "notifications",
                column: "FarmStaffId",
                principalTable: "farmStaff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_owners_RecipientId",
                table: "notifications",
                column: "RecipientId",
                principalTable: "owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_veterinarians_RecipientId",
                table: "notifications",
                column: "RecipientId",
                principalTable: "veterinarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_pregnancies_animals_AnimalId",
                table: "pregnancies",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineHistories_animals_AnimalId",
                table: "vaccineHistories",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineHistories_vaccines_VaccineId",
                table: "vaccineHistories",
                column: "VaccineId",
                principalTable: "vaccines",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineHistories_veterinarians_VeterinarianId",
                table: "vaccineHistories",
                column: "VeterinarianId",
                principalTable: "veterinarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
