using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class upda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animalHealthHistories_animals_AnimalId",
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
                name: "FK_appointments_farmStaff_FarmStaffId",
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
                name: "FK_births_pregnancies_PregnancyId",
                schema: "dbo",
                table: "births");

            migrationBuilder.DropForeignKey(
                name: "FK_breedingReports_animals_AnimalId",
                schema: "dbo",
                table: "breedingReports");

            migrationBuilder.DropForeignKey(
                name: "FK_breedingReports_matings_MatingId",
                schema: "dbo",
                table: "breedingReports");

            migrationBuilder.DropForeignKey(
                name: "FK_farmHealthSummaries_farms_FarmId",
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
                name: "FK_healthReports_farmStaff_FarmStaffId",
                schema: "dbo",
                table: "healthReports");

            migrationBuilder.DropForeignKey(
                name: "FK_matings_animals_FemaleAnimalId",
                schema: "dbo",
                table: "matings");

            migrationBuilder.DropForeignKey(
                name: "FK_matings_animals_MaleAnimalId",
                schema: "dbo",
                table: "matings");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalExaminations_animals_AnimalId",
                schema: "dbo",
                table: "medicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalExaminations_farmStaff_FarmStaffId",
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
                name: "FK_notifications_animals_AnimalId",
                schema: "dbo",
                table: "notifications");

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
                name: "FK_prescriptions_medicalExaminations_MedicalExaminationId",
                schema: "dbo",
                table: "prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_productionRecords_animals_AnimalId",
                schema: "dbo",
                table: "productionRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_productionRecords_farmStaff_FarmStaffId",
                schema: "dbo",
                table: "productionRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_treatmentPlans_medicalExaminations_MedicalExaminationId",
                schema: "dbo",
                table: "treatmentPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_animals_AnimalId",
                schema: "dbo",
                table: "vaccineHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_farmStaff_FarmStaffId",
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

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                schema: "dbo",
                table: "animals");

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

            migrationBuilder.AddColumn<decimal>(
                name: "salary",
                table: "veterinarians",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "salary",
                table: "farmStaff",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_animalHealthHistories_animals_AnimalId",
                table: "animalHealthHistories",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_animals_farms_FarmId",
                table: "animals",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_appointmentHistories_appointments_AppointmentId",
                table: "appointmentHistories",
                column: "AppointmentId",
                principalTable: "appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_animals_AnimalId",
                table: "appointments",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_farmStaff_FarmStaffId",
                table: "appointments",
                column: "FarmStaffId",
                principalTable: "farmStaff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_farms_FarmId",
                table: "appointments",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_veterinarians_VeterinarianId",
                table: "appointments",
                column: "VeterinarianId",
                principalTable: "veterinarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_births_animals_AnimalId",
                table: "births",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_births_pregnancies_PregnancyId",
                table: "births",
                column: "PregnancyId",
                principalTable: "pregnancies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_breedingReports_animals_AnimalId",
                table: "breedingReports",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_breedingReports_matings_MatingId",
                table: "breedingReports",
                column: "MatingId",
                principalTable: "matings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_farmHealthSummaries_farms_FarmId",
                table: "farmHealthSummaries",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_farms_owners_OwnerId",
                table: "farms",
                column: "OwnerId",
                principalTable: "owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_farmStaff_farms_FarmId",
                table: "farmStaff",
                column: "FarmId",
                principalTable: "farms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_healthReports_farmStaff_FarmStaffId",
                table: "healthReports",
                column: "FarmStaffId",
                principalTable: "farmStaff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_matings_animals_FemaleAnimalId",
                table: "matings",
                column: "FemaleAnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_matings_animals_MaleAnimalId",
                table: "matings",
                column: "MaleAnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_medicalExaminations_animals_AnimalId",
                table: "medicalExaminations",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_medicalExaminations_farmStaff_FarmStaffId",
                table: "medicalExaminations",
                column: "FarmStaffId",
                principalTable: "farmStaff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_medicalExaminations_veterinarians_VeterinarianId",
                table: "medicalExaminations",
                column: "VeterinarianId",
                principalTable: "veterinarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_medicalRecords_animals_AnimalId",
                table: "medicalRecords",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_medications_medicalExaminations_MedicalExaminationId",
                table: "medications",
                column: "MedicalExaminationId",
                principalTable: "medicalExaminations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_animals_AnimalId",
                table: "notifications",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_farmStaff_FarmStaffId",
                table: "notifications",
                column: "FarmStaffId",
                principalTable: "farmStaff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_owners_OwnerId",
                table: "notifications",
                column: "OwnerId",
                principalTable: "owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_notifications_veterinarians_VeterinarianId",
                table: "notifications",
                column: "VeterinarianId",
                principalTable: "veterinarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_prescriptions_medicalExaminations_MedicalExaminationId",
                table: "prescriptions",
                column: "MedicalExaminationId",
                principalTable: "medicalExaminations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productionRecords_animals_AnimalId",
                table: "productionRecords",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productionRecords_farmStaff_FarmStaffId",
                table: "productionRecords",
                column: "FarmStaffId",
                principalTable: "farmStaff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_treatmentPlans_medicalExaminations_MedicalExaminationId",
                table: "treatmentPlans",
                column: "MedicalExaminationId",
                principalTable: "medicalExaminations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineHistories_animals_AnimalId",
                table: "vaccineHistories",
                column: "AnimalId",
                principalTable: "animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineHistories_farmStaff_FarmStaffId",
                table: "vaccineHistories",
                column: "FarmStaffId",
                principalTable: "farmStaff",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineHistories_vaccines_VaccineId",
                table: "vaccineHistories",
                column: "VaccineId",
                principalTable: "vaccines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccineHistories_veterinarians_VeterinarianId",
                table: "vaccineHistories",
                column: "VeterinarianId",
                principalTable: "veterinarians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_animalHealthHistories_animals_AnimalId",
                table: "animalHealthHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_animals_farms_FarmId",
                table: "animals");

            migrationBuilder.DropForeignKey(
                name: "FK_appointmentHistories_appointments_AppointmentId",
                table: "appointmentHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_animals_AnimalId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_farmStaff_FarmStaffId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_farms_FarmId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_veterinarians_VeterinarianId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_births_animals_AnimalId",
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
                name: "FK_farmHealthSummaries_farms_FarmId",
                table: "farmHealthSummaries");

            migrationBuilder.DropForeignKey(
                name: "FK_farms_owners_OwnerId",
                table: "farms");

            migrationBuilder.DropForeignKey(
                name: "FK_farmStaff_farms_FarmId",
                table: "farmStaff");

            migrationBuilder.DropForeignKey(
                name: "FK_healthReports_farmStaff_FarmStaffId",
                table: "healthReports");

            migrationBuilder.DropForeignKey(
                name: "FK_matings_animals_FemaleAnimalId",
                table: "matings");

            migrationBuilder.DropForeignKey(
                name: "FK_matings_animals_MaleAnimalId",
                table: "matings");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalExaminations_animals_AnimalId",
                table: "medicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalExaminations_farmStaff_FarmStaffId",
                table: "medicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalExaminations_veterinarians_VeterinarianId",
                table: "medicalExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalRecords_animals_AnimalId",
                table: "medicalRecords");

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
                name: "FK_notifications_animals_AnimalId",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_farmStaff_FarmStaffId",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_owners_OwnerId",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_notifications_veterinarians_VeterinarianId",
                table: "notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_prescriptions_medicalExaminations_MedicalExaminationId",
                table: "prescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_productionRecords_animals_AnimalId",
                table: "productionRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_productionRecords_farmStaff_FarmStaffId",
                table: "productionRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_treatmentPlans_medicalExaminations_MedicalExaminationId",
                table: "treatmentPlans");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_animals_AnimalId",
                table: "vaccineHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_farmStaff_FarmStaffId",
                table: "vaccineHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_vaccines_VaccineId",
                table: "vaccineHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccineHistories_veterinarians_VeterinarianId",
                table: "vaccineHistories");

            migrationBuilder.DropColumn(
                name: "salary",
                table: "veterinarians");

            migrationBuilder.DropColumn(
                name: "salary",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                schema: "dbo",
                table: "animals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_animalHealthHistories_animals_AnimalId",
                schema: "dbo",
                table: "animalHealthHistories",
                column: "AnimalId",
                principalSchema: "dbo",
                principalTable: "animals",
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
                name: "FK_appointments_farmStaff_FarmStaffId",
                schema: "dbo",
                table: "appointments",
                column: "FarmStaffId",
                principalSchema: "dbo",
                principalTable: "farmStaff",
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
                name: "FK_breedingReports_matings_MatingId",
                schema: "dbo",
                table: "breedingReports",
                column: "MatingId",
                principalSchema: "dbo",
                principalTable: "matings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_farmHealthSummaries_farms_FarmId",
                schema: "dbo",
                table: "farmHealthSummaries",
                column: "FarmId",
                principalSchema: "dbo",
                principalTable: "farms",
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
                name: "FK_healthReports_farmStaff_FarmStaffId",
                schema: "dbo",
                table: "healthReports",
                column: "FarmStaffId",
                principalSchema: "dbo",
                principalTable: "farmStaff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_matings_animals_FemaleAnimalId",
                schema: "dbo",
                table: "matings",
                column: "FemaleAnimalId",
                principalSchema: "dbo",
                principalTable: "animals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_matings_animals_MaleAnimalId",
                schema: "dbo",
                table: "matings",
                column: "MaleAnimalId",
                principalSchema: "dbo",
                principalTable: "animals",
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
                name: "FK_medicalExaminations_farmStaff_FarmStaffId",
                schema: "dbo",
                table: "medicalExaminations",
                column: "FarmStaffId",
                principalSchema: "dbo",
                principalTable: "farmStaff",
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
                name: "FK_notifications_animals_AnimalId",
                schema: "dbo",
                table: "notifications",
                column: "AnimalId",
                principalSchema: "dbo",
                principalTable: "animals",
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
                name: "FK_prescriptions_medicalExaminations_MedicalExaminationId",
                schema: "dbo",
                table: "prescriptions",
                column: "MedicalExaminationId",
                principalSchema: "dbo",
                principalTable: "medicalExaminations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_productionRecords_animals_AnimalId",
                schema: "dbo",
                table: "productionRecords",
                column: "AnimalId",
                principalSchema: "dbo",
                principalTable: "animals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_productionRecords_farmStaff_FarmStaffId",
                schema: "dbo",
                table: "productionRecords",
                column: "FarmStaffId",
                principalSchema: "dbo",
                principalTable: "farmStaff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_treatmentPlans_medicalExaminations_MedicalExaminationId",
                schema: "dbo",
                table: "treatmentPlans",
                column: "MedicalExaminationId",
                principalSchema: "dbo",
                principalTable: "medicalExaminations",
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
                name: "FK_vaccineHistories_farmStaff_FarmStaffId",
                schema: "dbo",
                table: "vaccineHistories",
                column: "FarmStaffId",
                principalSchema: "dbo",
                principalTable: "farmStaff",
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
    }
}
