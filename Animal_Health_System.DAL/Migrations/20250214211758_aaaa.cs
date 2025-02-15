using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class aaaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medications_medicalExaminations_MedicalExaminationId",
                table: "medications");

            migrationBuilder.DropIndex(
                name: "IX_medications_MedicalExaminationId",
                table: "medications");

            migrationBuilder.DropColumn(
                name: "MedicalExaminationId",
                table: "medications");

            migrationBuilder.CreateTable(
                name: "MedicalExamination_Medication",
                columns: table => new
                {
                    MedicalExaminationsId = table.Column<int>(type: "int", nullable: false),
                    MedicationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExamination_Medication", x => new { x.MedicalExaminationsId, x.MedicationsId });
                    table.ForeignKey(
                        name: "FK_MedicalExamination_Medication_medicalExaminations_MedicalExaminationsId",
                        column: x => x.MedicalExaminationsId,
                        principalTable: "medicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalExamination_Medication_medications_MedicationsId",
                        column: x => x.MedicationsId,
                        principalTable: "medications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExamination_Medication_MedicationsId",
                table: "MedicalExamination_Medication",
                column: "MedicationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalExamination_Medication");

            migrationBuilder.AddColumn<int>(
                name: "MedicalExaminationId",
                table: "medications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_medications_MedicalExaminationId",
                table: "medications",
                column: "MedicalExaminationId");

            migrationBuilder.AddForeignKey(
                name: "FK_medications_medicalExaminations_MedicalExaminationId",
                table: "medications",
                column: "MedicalExaminationId",
                principalTable: "medicalExaminations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
