using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class data : Migration
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
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
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
                name: "medications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vaccines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccines", x => x.Id);
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "owners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_owners_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_veterinarians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_veterinarians_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "farms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_farms_owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FarmId = table.Column<int>(type: "int", nullable: false),
                    MedicalRecordId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_animals_farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    FarmId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farmHealthSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_farmHealthSummaries_farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "farmStaff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FarmId = table.Column<int>(type: "int", nullable: false),
                    DateHired = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_farmStaff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_farmStaff_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                    FarmId = table.Column<int>(type: "int", nullable: false),
                    MaleAnimalId = table.Column<int>(type: "int", nullable: false),
                    FemaleAnimalId = table.Column<int>(type: "int", nullable: false),
                    Ispregnancyevent = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_matings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_matings_animals_FemaleAnimalId",
                        column: x => x.FemaleAnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_matings_animals_MaleAnimalId",
                        column: x => x.MaleAnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_matings_farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "medicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalRecords_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    FarmId = table.Column<int>(type: "int", nullable: false),
                    VeterinarianId = table.Column<int>(type: "int", nullable: false),
                    FarmStaffId = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appointments_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appointments_farmStaff_FarmStaffId",
                        column: x => x.FarmStaffId,
                        principalTable: "farmStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appointments_farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_appointments_veterinarians_VeterinarianId",
                        column: x => x.VeterinarianId,
                        principalTable: "veterinarians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    MatingId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pregnancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_pregnancies_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_pregnancies_matings_MatingId",
                        column: x => x.MatingId,
                        principalTable: "matings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    MedicalRecordId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animalHealthHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_animalHealthHistories_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_animalHealthHistories_medicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "medicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ExaminationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    MedicalRecordId = table.Column<int>(type: "int", nullable: false),
                    VeterinarianId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalExaminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalExaminations_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_medicalExaminations_medicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "medicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medicalExaminations_veterinarians_VeterinarianId",
                        column: x => x.VeterinarianId,
                        principalTable: "veterinarians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vaccineHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdministrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VeterinarianId = table.Column<int>(type: "int", nullable: false),
                    medicalRecordId = table.Column<int>(type: "int", nullable: false),
                    VaccineId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccineHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vaccineHistories_medicalRecords_medicalRecordId",
                        column: x => x.medicalRecordId,
                        principalTable: "medicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vaccineHistories_vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "vaccines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vaccineHistories_veterinarians_VeterinarianId",
                        column: x => x.VeterinarianId,
                        principalTable: "veterinarians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_appointmentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_appointmentHistories_appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "births",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PregnancyId = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfOffspring = table.Column<int>(type: "int", nullable: false),
                    BirthCondition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_births", x => x.Id);
                    table.ForeignKey(
                        name: "FK_births_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_births_pregnancies_PregnancyId",
                        column: x => x.PregnancyId,
                        principalTable: "pregnancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    SenderType = table.Column<int>(type: "int", nullable: false),
                    RecipientType = table.Column<int>(type: "int", nullable: false),
                    FarmStaffId = table.Column<int>(type: "int", nullable: true),
                    VeterinarianId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: true),
                    PregnancyId = table.Column<int>(type: "int", nullable: true),
                    AnimalId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notifications_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_notifications_farmStaff_FarmStaffId",
                        column: x => x.FarmStaffId,
                        principalTable: "farmStaff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_notifications_owners_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "owners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_notifications_pregnancies_PregnancyId",
                        column: x => x.PregnancyId,
                        principalTable: "pregnancies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_notifications_veterinarians_VeterinarianId",
                        column: x => x.VeterinarianId,
                        principalTable: "veterinarians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3155ed94-b4d0-4e14-ab4d-53c68d725401", null, "Admin", "ADMIN" },
                    { "409901fa-62fc-4352-a873-b674d5140611", null, "Veterinarian", "VETERINARIAN" },
                    { "62a9c6e3-04be-4a4c-9a4a-1aa2a32d0c66", null, "FarmStaff", "FARMSTAFF" },
                    { "9428f1f4-2c39-4fce-892c-85f349322fd0", null, "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "21d4f4a9-8e26-416e-9d6b-a5c7e5b170d3", 0, null, "ab0986af-f4ab-4ae5-a0e3-8c8950abbbc8", "admin@medc.com", true, null, false, null, "ADMIN@MEDC.COM", "ADMIN@MEDC.COM", "AQAAAAIAAYagAAAAEJsvZKvRwX1kU5OL/p81DshNOMampbSH2+XOkxKHXggS+UVUqAX0G5u79IAPw46bNw==", null, false, 0, "39595ece-dcc8-4bf7-a1dd-460d67b482da", false, "admin@medc.com" },
                    { "86854584-fb05-4bfa-ae19-51dc71540f59", 0, null, "b29133d0-6af0-4a78-ad8e-cf30aae1fce7", "owner@medc.com", true, null, false, null, "OWNER@MEDC.COM", "OWNER@MEDC.COM", "AQAAAAIAAYagAAAAELkLrlrAs6K3xkEaoDh0MrJA8LLNe6xEDIuWWHypM3X9EbnLtLraa7jTn0++f3CiYw==", null, false, 1, "74198433-d4bc-4b2c-8ea3-35995276f5e4", false, "owner@medc.com" },
                    { "b9ac39b7-df87-4572-a369-d1083a507b4e", 0, null, "0136d547-2bee-4fcd-a404-d12ac0c4b67d", "veterinarian@medc.com", true, null, false, null, "VETERINARIAN@MEDC.COM", "VETERINARIAN@MEDC.COM", "AQAAAAIAAYagAAAAEEsB60cXXkTM1sIKSKQ5g0njizTrvxuNCZ5ryde03iImtqBSpZMB4+ZIKU887DYVLQ==", null, false, 3, "4810df72-eab1-423c-9054-c9577b64431a", false, "veterinarian@medc.com" },
                    { "bc254da1-e0eb-4818-ab6f-90e7ece2eb07", 0, null, "532909e4-bf8f-471b-ba70-ccab42c0e788", "farmstaff@medc.com", true, null, false, null, "FARMSTAFF@MEDC.COM", "FARMSTAFF@MEDC.COM", "AQAAAAIAAYagAAAAENnoNMCF2drlzyCsgwQKlhG0o7jBuVDCqYLuR4nRC7lFMrq02B96ZfS/ntszsN0CqA==", null, false, 2, "2f5a8e88-38d7-4ce4-89c6-a817a97e7b03", false, "farmstaff@medc.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9428f1f4-2c39-4fce-892c-85f349322fd0", "86854584-fb05-4bfa-ae19-51dc71540f59" },
                    { "409901fa-62fc-4352-a873-b674d5140611", "b9ac39b7-df87-4572-a369-d1083a507b4e" },
                    { "62a9c6e3-04be-4a4c-9a4a-1aa2a32d0c66", "bc254da1-e0eb-4818-ab6f-90e7ece2eb07" }
                });

            migrationBuilder.InsertData(
                table: "owners",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Email", "FullName", "IsDeleted", "PhoneNumber", "UpdatedAt" },
                values: new object[] { 1, "86854584-fb05-4bfa-ae19-51dc71540f59", new DateTime(2025, 2, 24, 19, 45, 2, 947, DateTimeKind.Utc).AddTicks(2945), "owner@medc.com", "John Doe", false, "123-456-7890", new DateTime(2025, 2, 24, 19, 45, 2, 947, DateTimeKind.Utc).AddTicks(2952) });

            migrationBuilder.InsertData(
                table: "veterinarians",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Email", "FullName", "IsDeleted", "PhoneNumber", "Specialty", "UpdatedAt", "YearsOfExperience", "salary" },
                values: new object[] { 1, "b9ac39b7-df87-4572-a369-d1083a507b4e", new DateTime(2025, 2, 24, 19, 45, 3, 13, DateTimeKind.Utc).AddTicks(2385), "veterinarian@medc.com", "Dr. Smith", false, "123-456-7890", "Small Animal", new DateTime(2025, 2, 24, 19, 45, 3, 13, DateTimeKind.Utc).AddTicks(2392), 5, 50000m });

            migrationBuilder.CreateIndex(
                name: "Idx_AnimalHealthHistory_AnimalId_MedicalRecordId",
                table: "animalHealthHistories",
                columns: new[] { "AnimalId", "MedicalRecordId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_AnimalHealthHistory_Name_EventDate",
                table: "animalHealthHistories",
                columns: new[] { "Name", "EventDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_animalHealthHistories_MedicalRecordId",
                table: "animalHealthHistories",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_animals_FarmId_Name",
                table: "animals",
                columns: new[] { "FarmId", "Name" },
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_appointments_AnimalId_AppointmentDate_VeterinarianId",
                table: "appointments",
                columns: new[] { "AnimalId", "AppointmentDate", "VeterinarianId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_appointments_FarmId",
                table: "appointments",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_appointments_FarmStaffId",
                table: "appointments",
                column: "FarmStaffId");

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
                name: "IX_births_AnimalId",
                table: "births",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_births_PregnancyId",
                table: "births",
                column: "PregnancyId");

            migrationBuilder.CreateIndex(
                name: "IX_farmHealthSummaries_FarmId",
                table: "farmHealthSummaries",
                column: "FarmId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_farms_Name_OwnerId",
                table: "farms",
                columns: new[] { "Name", "OwnerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_farms_OwnerId",
                table: "farms",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_farmStaff_AnimalId",
                table: "farmStaff",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_farmStaff_ApplicationUserId",
                table: "farmStaff",
                column: "ApplicationUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_farmStaff_FarmId_FullName",
                table: "farmStaff",
                columns: new[] { "FarmId", "FullName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_matings_FarmId",
                table: "matings",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_matings_FemaleAnimalId",
                table: "matings",
                column: "FemaleAnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_matings_MaleAnimalId_FemaleAnimalId_MatingDate",
                table: "matings",
                columns: new[] { "MaleAnimalId", "FemaleAnimalId", "MatingDate" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExamination_Medication_MedicationsId",
                table: "MedicalExamination_Medication",
                column: "MedicationsId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalExaminations_AnimalId_ExaminationDate",
                table: "medicalExaminations",
                columns: new[] { "AnimalId", "ExaminationDate" },
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_medicalRecords_Name",
                table: "medicalRecords",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_medications_Name",
                table: "medications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_notifications_AnimalId",
                table: "notifications",
                column: "AnimalId");

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
                name: "IX_notifications_OwnerId",
                table: "notifications",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_PregnancyId",
                table: "notifications",
                column: "PregnancyId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_VeterinarianId",
                table: "notifications",
                column: "VeterinarianId");

            migrationBuilder.CreateIndex(
                name: "IX_owners_ApplicationUserId",
                table: "owners",
                column: "ApplicationUserId",
                unique: true);

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
                name: "IX_pregnancies_MatingId",
                table: "pregnancies",
                column: "MatingId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccineHistories_medicalRecordId",
                table: "vaccineHistories",
                column: "medicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccineHistories_VaccineId",
                table: "vaccineHistories",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccineHistories_VeterinarianId",
                table: "vaccineHistories",
                column: "VeterinarianId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccines_Name",
                table: "vaccines",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_veterinarians_ApplicationUserId",
                table: "veterinarians",
                column: "ApplicationUserId",
                unique: true);

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
                name: "farmHealthSummaries");

            migrationBuilder.DropTable(
                name: "MedicalExamination_Medication");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "vaccineHistories");

            migrationBuilder.DropTable(
                name: "appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "medicalExaminations");

            migrationBuilder.DropTable(
                name: "medications");

            migrationBuilder.DropTable(
                name: "pregnancies");

            migrationBuilder.DropTable(
                name: "vaccines");

            migrationBuilder.DropTable(
                name: "farmStaff");

            migrationBuilder.DropTable(
                name: "medicalRecords");

            migrationBuilder.DropTable(
                name: "veterinarians");

            migrationBuilder.DropTable(
                name: "matings");

            migrationBuilder.DropTable(
                name: "animals");

            migrationBuilder.DropTable(
                name: "farms");

            migrationBuilder.DropTable(
                name: "owners");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
