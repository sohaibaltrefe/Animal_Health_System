using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class all : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "medicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PreviousDiseases = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "medicationStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicationStocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "veterinarians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veterinarians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "farms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_farms_owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "vaccines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdministrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MedicalRecordId = table.Column<int>(type: "int", nullable: true),
                    VeterinarianId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vaccines_medicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "medicalRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_vaccines_veterinarians_VeterinarianId",
                        column: x => x.VeterinarianId,
                        principalTable: "veterinarians",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CurrentHealthStatus = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FarmId = table.Column<int>(type: "int", nullable: true),
                    MedicalRecordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_animals_farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_animals_medicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "medicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "farmHealthSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAnimals = table.Column<int>(type: "int", nullable: false),
                    HealthyAnimals = table.Column<int>(type: "int", nullable: false),
                    SickAnimals = table.Column<int>(type: "int", nullable: false),
                    UnderTreatment = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FarmId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farmHealthSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_farmHealthSummaries_farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "animalHealthHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EventType = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    MedicalRecordiD = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animalHealthHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_animalHealthHistories_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_animalHealthHistories_medicalRecords_MedicalRecordiD",
                        column: x => x.MedicalRecordiD,
                        principalTable: "medicalRecords",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "farmStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FarmId = table.Column<int>(type: "int", nullable: true),
                    VeterinarianId = table.Column<int>(type: "int", nullable: true),
                    AnimalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farmStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_farmStaff_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_farmStaff_farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_farmStaff_veterinarians_VeterinarianId",
                        column: x => x.VeterinarianId,
                        principalTable: "veterinarians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "matings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MaleAnimalId = table.Column<int>(type: "int", nullable: true),
                    FemaleAnimalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_matings_animals_FemaleAnimalId",
                        column: x => x.FemaleAnimalId,
                        principalTable: "animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_matings_animals_MaleAnimalId",
                        column: x => x.MaleAnimalId,
                        principalTable: "animals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "pregnancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedBirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualBirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    HasComplications = table.Column<bool>(type: "bit", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnimalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pregnancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pregnancies_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "pregnancyNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnimalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pregnancyNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pregnancyNotifications_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "vaccineReminders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReminderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsNotified = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    VaccineId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccineReminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vaccineReminders_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_vaccineReminders_vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "vaccines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    VeterinarianId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    FarmStaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appointments_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_appointments_farmStaff_FarmStaffId",
                        column: x => x.FarmStaffId,
                        principalTable: "farmStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_appointments_owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_appointments_veterinarians_VeterinarianId",
                        column: x => x.VeterinarianId,
                        principalTable: "veterinarians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "healthReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAnimals = table.Column<int>(type: "int", nullable: false),
                    HealthyAnimals = table.Column<int>(type: "int", nullable: false),
                    SickAnimals = table.Column<int>(type: "int", nullable: false),
                    ReportSummary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FarmId = table.Column<int>(type: "int", nullable: true),
                    FarmStaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_healthReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_healthReports_farmStaff_FarmStaffId",
                        column: x => x.FarmStaffId,
                        principalTable: "farmStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_healthReports_farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "medicalExaminations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExaminationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ExaminationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    MedicalRecordId = table.Column<int>(type: "int", nullable: true),
                    FarmStaffId = table.Column<int>(type: "int", nullable: true),
                    VeterinarianId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalExaminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalExaminations_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_medicalExaminations_farmStaff_FarmStaffId",
                        column: x => x.FarmStaffId,
                        principalTable: "farmStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_medicalExaminations_medicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "medicalRecords",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_medicalExaminations_veterinarians_VeterinarianId",
                        column: x => x.VeterinarianId,
                        principalTable: "veterinarians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    RecipientId = table.Column<int>(type: "int", nullable: true),
                    Recipient = table.Column<int>(type: "int", nullable: false),
                    FarmStaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notifications_farmStaff_FarmStaffId",
                        column: x => x.FarmStaffId,
                        principalTable: "farmStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notifications_owners_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_notifications_veterinarians_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "veterinarians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "productionRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuantityProduced = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    FarmStaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productionRecords_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_productionRecords_farmStaff_FarmStaffId",
                        column: x => x.FarmStaffId,
                        principalTable: "farmStaff",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "vaccineHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdministrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    VeterinarianId = table.Column<int>(type: "int", nullable: true),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    VaccineId = table.Column<int>(type: "int", nullable: true),
                    FarmStaffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccineHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vaccineHistories_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_vaccineHistories_farmStaff_FarmStaffId",
                        column: x => x.FarmStaffId,
                        principalTable: "farmStaff",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_vaccineHistories_vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "vaccines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_vaccineHistories_veterinarians_VeterinarianId",
                        column: x => x.VeterinarianId,
                        principalTable: "veterinarians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "breedingReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatingDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PregnancyStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfOffspring = table.Column<int>(type: "int", nullable: false),
                    BirthCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    MatingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breedingReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_breedingReports_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_breedingReports_matings_MatingId",
                        column: x => x.MatingId,
                        principalTable: "matings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "births",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PregnancyId = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfOffspring = table.Column<int>(type: "int", nullable: false),
                    BirthCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    FarmId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_births", x => x.Id);
                    table.ForeignKey(
                        name: "FK_births_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_births_farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_births_pregnancies_PregnancyId",
                        column: x => x.PregnancyId,
                        principalTable: "pregnancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "appointmentHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppointmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointmentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appointmentHistories_appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "prescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MedicalExaminationId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_prescriptions_medicalExaminations_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "medicalExaminations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "treatmentPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TreatmentDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicalExaminationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_treatmentPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_treatmentPlans_medicalExaminations_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "medicalExaminations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "medications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MedicalExaminationId = table.Column<int>(type: "int", nullable: true),
                    MedicationStockId = table.Column<int>(type: "int", nullable: true),
                    PrescriptionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medications_medicalExaminations_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "medicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_medications_medicationStocks_MedicationStockId",
                        column: x => x.MedicationStockId,
                        principalTable: "medicationStocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_medications_prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "prescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "Idx_AnimalHealthHistory_AnimalId_MedicalRecordId",
                table: "animalHealthHistories",
                columns: new[] { "AnimalId", "MedicalRecordiD" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL AND [MedicalRecordiD] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "Idx_AnimalHealthHistory_Name_EventDate",
                table: "animalHealthHistories",
                columns: new[] { "Name", "EventDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_animalHealthHistories_MedicalRecordiD",
                table: "animalHealthHistories",
                column: "MedicalRecordiD");

            migrationBuilder.CreateIndex(
                name: "IX_animals_FarmId_Name",
                table: "animals",
                columns: new[] { "FarmId", "Name" },
                unique: true,
                filter: "[FarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_animals_MedicalRecordId",
                table: "animals",
                column: "MedicalRecordId",
                unique: true,
                filter: "[MedicalRecordId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_animals_Name",
                table: "animals",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_appointmentHistories_AppointmentId",
                table: "appointmentHistories",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_appointmentHistories_Name",
                table: "appointmentHistories",
                column: "Name",
                unique: true);

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
                name: "IX_appointments_FarmStaffId",
                table: "appointments",
                column: "FarmStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_OwnerId",
                table: "appointments",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_VeterinarianId",
                table: "appointments",
                column: "VeterinarianId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_births_AnimalId_BirthDate",
                table: "births",
                columns: new[] { "AnimalId", "BirthDate" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_births_FarmId",
                table: "births",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_births_PregnancyId",
                table: "births",
                column: "PregnancyId");

            migrationBuilder.CreateIndex(
                name: "IX_breedingReports_AnimalId_ReportDate",
                table: "breedingReports",
                columns: new[] { "AnimalId", "ReportDate" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_breedingReports_MatingId",
                table: "breedingReports",
                column: "MatingId");

            migrationBuilder.CreateIndex(
                name: "IX_farmHealthSummaries_FarmId",
                table: "farmHealthSummaries",
                column: "FarmId",
                unique: true,
                filter: "[FarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_farms_Name_OwnerId",
                table: "farms",
                columns: new[] { "Name", "OwnerId" },
                unique: true,
                filter: "[OwnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_farms_OwnerId",
                table: "farms",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_farmStaff_AnimalId",
                table: "farmStaff",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_farmStaff_FarmId_FullName",
                table: "farmStaff",
                columns: new[] { "FarmId", "FullName" },
                unique: true,
                filter: "[FarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_farmStaff_VeterinarianId",
                table: "farmStaff",
                column: "VeterinarianId");

            migrationBuilder.CreateIndex(
                name: "IX_healthReports_FarmId_ReportDate",
                table: "healthReports",
                columns: new[] { "FarmId", "ReportDate" },
                unique: true,
                filter: "[FarmId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_healthReports_FarmStaffId",
                table: "healthReports",
                column: "FarmStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_matings_FemaleAnimalId",
                table: "matings",
                column: "FemaleAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_matings_MaleAnimalId_FemaleAnimalId_MatingDate",
                table: "matings",
                columns: new[] { "MaleAnimalId", "FemaleAnimalId", "MatingDate" },
                unique: true,
                filter: "[MaleAnimalId] IS NOT NULL AND [FemaleAnimalId] IS NOT NULL");

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
                name: "IX_medicalExaminations_MedicalRecordId",
                table: "medicalExaminations",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalExaminations_VeterinarianId",
                table: "medicalExaminations",
                column: "VeterinarianId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalRecords_AnimalId",
                table: "medicalRecords",
                column: "AnimalId",
                unique: true,
                filter: "[AnimalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_medications_MedicalExaminationId",
                table: "medications",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_medications_MedicationStockId",
                table: "medications",
                column: "MedicationStockId");

            migrationBuilder.CreateIndex(
                name: "IX_medications_Name",
                table: "medications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_medications_PrescriptionId",
                table: "medications",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_medicationStocks_Name",
                table: "medicationStocks",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_notifications_FarmStaffId",
                table: "notifications",
                column: "FarmStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_Name",
                table: "notifications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_notifications_RecipientId",
                table: "notifications",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_owners_Email",
                table: "owners",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pregnancies_AnimalId_MatingDate",
                table: "pregnancies",
                columns: new[] { "AnimalId", "MatingDate" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_pregnancyNotifications_AnimalId_NotificationDate",
                table: "pregnancyNotifications",
                columns: new[] { "AnimalId", "NotificationDate" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_prescriptions_MedicalExaminationId_CreatedAt",
                table: "prescriptions",
                columns: new[] { "MedicalExaminationId", "CreatedAt" },
                unique: true,
                filter: "[MedicalExaminationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_productionRecords_AnimalId_Date",
                table: "productionRecords",
                columns: new[] { "AnimalId", "Date" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_productionRecords_FarmStaffId",
                table: "productionRecords",
                column: "FarmStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_treatmentPlans_MedicalExaminationId",
                table: "treatmentPlans",
                column: "MedicalExaminationId",
                unique: true,
                filter: "[MedicalExaminationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_treatmentPlans_Name",
                table: "treatmentPlans",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vaccineHistories_AnimalId_VaccineId_AdministrationDate",
                table: "vaccineHistories",
                columns: new[] { "AnimalId", "VaccineId", "AdministrationDate" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL AND [VaccineId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_vaccineHistories_FarmStaffId",
                table: "vaccineHistories",
                column: "FarmStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccineHistories_VaccineId",
                table: "vaccineHistories",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccineHistories_VeterinarianId",
                table: "vaccineHistories",
                column: "VeterinarianId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccineReminders_AnimalId_VaccineId",
                table: "vaccineReminders",
                columns: new[] { "AnimalId", "VaccineId" },
                unique: true,
                filter: "[AnimalId] IS NOT NULL AND [VaccineId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_vaccineReminders_VaccineId",
                table: "vaccineReminders",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccines_MedicalRecordId",
                table: "vaccines",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccines_Name_AdministrationDate",
                table: "vaccines",
                columns: new[] { "Name", "AdministrationDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vaccines_VeterinarianId",
                table: "vaccines",
                column: "VeterinarianId");

            migrationBuilder.CreateIndex(
                name: "IX_veterinarians_Email",
                table: "veterinarians",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "animalHealthHistories");

            migrationBuilder.DropTable(
                name: "appointmentHistories");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "births");

            migrationBuilder.DropTable(
                name: "breedingReports");

            migrationBuilder.DropTable(
                name: "farmHealthSummaries");

            migrationBuilder.DropTable(
                name: "healthReports");

            migrationBuilder.DropTable(
                name: "medications");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "pregnancyNotifications");

            migrationBuilder.DropTable(
                name: "productionRecords");

            migrationBuilder.DropTable(
                name: "treatmentPlans");

            migrationBuilder.DropTable(
                name: "vaccineHistories");

            migrationBuilder.DropTable(
                name: "vaccineReminders");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "pregnancies");

            migrationBuilder.DropTable(
                name: "matings");

            migrationBuilder.DropTable(
                name: "medicationStocks");

            migrationBuilder.DropTable(
                name: "prescriptions");

            migrationBuilder.DropTable(
                name: "vaccines");

            migrationBuilder.DropTable(
                name: "medicalExaminations");

            migrationBuilder.DropTable(
                name: "farmStaff");

            migrationBuilder.DropTable(
                name: "animals");

            migrationBuilder.DropTable(
                name: "veterinarians");

            migrationBuilder.DropTable(
                name: "farms");

            migrationBuilder.DropTable(
                name: "medicalRecords");

            migrationBuilder.DropTable(
                name: "owners");
        }
    }
}
