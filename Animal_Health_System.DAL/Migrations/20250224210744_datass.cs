using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class datass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "260a2ee0-5bb5-4047-9550-9873ba07fa67", null, "FarmStaff", "FARMSTAFF" },
                    { "45700a12-dd07-48da-88f3-7d0cedf5e2c7", null, "Veterinarian", "VETERINARIAN" },
                    { "d5c6aecc-947d-43e7-ac01-727e9ebda46b", null, "Admin", "ADMIN" },
                    { "dfda3e3d-dda8-40c7-8cf3-09e4d6087bd0", null, "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1687b06c-3c63-4246-b89c-513f2e3a767c", 0, null, "e977c667-0e6a-4518-a5f0-4b833baac649", "farmstaff@medc.com", true, null, false, null, "FARMSTAFF@MEDC.COM", "FARMSTAFF@MEDC.COM", "AQAAAAIAAYagAAAAEAdorzPlqRWXNsA7kXVwEl+f8H9lRNLDs7T4CtLwfdp8JTdyqV+EcyZLDUbM3cdYLA==", null, false, "FarmStaff", "d503dedd-e692-43a1-8776-c1457a9fb537", false, "farmstaff@medc.com" },
                    { "7000b361-ccf9-445c-ad99-6c41aba41132", 0, null, "32d1e6a9-fdc5-4cae-898d-f1da1222d518", "owner@medc.com", true, null, false, null, "OWNER@MEDC.COM", "OWNER@MEDC.COM", "AQAAAAIAAYagAAAAEOGFHFVtlXJyy+sxhYQXVqkqARicbFDyHjPSUxh46RhZCwAuz/5b5TIQUR1wVh/cYA==", null, false, "Owner", "eaadd420-a34e-4c92-8765-af660ad45e53", false, "owner@medc.com" },
                    { "a3afee06-6658-4d02-be60-f61ab55a381c", 0, null, "aedde1b6-cc2c-4cbb-980c-eafd89874e77", "admin@medc.com", true, null, false, null, "ADMIN@MEDC.COM", "ADMIN@MEDC.COM", "AQAAAAIAAYagAAAAEItGe1tFFeWglXQ3+Is5+9KlWr1OL/5IYA/GAHkDTklUBAcxdSrmEThgPzOwG6lffg==", null, false, "Admin", "66ee480c-3343-45e8-b529-6687d5cf2e8e", false, "admin@medc.com" },
                    { "b697790c-f54d-4d61-866d-36bcf8a796ad", 0, null, "6ae2463d-46b0-4b31-83e2-533cfdf66fa6", "veterinarian@medc.com", true, null, false, null, "VETERINARIAN@MEDC.COM", "VETERINARIAN@MEDC.COM", "AQAAAAIAAYagAAAAEBmUGrONwC122Wld3Mw56ELJ5HFjC35hA+9MPbD4XKNqC8lEphffbVVEnCpTk5l66g==", null, false, "Veterinarian", "e5811b24-761f-45a9-92b5-2c2df01cc637", false, "veterinarian@medc.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "260a2ee0-5bb5-4047-9550-9873ba07fa67", "1687b06c-3c63-4246-b89c-513f2e3a767c" },
                    { "dfda3e3d-dda8-40c7-8cf3-09e4d6087bd0", "7000b361-ccf9-445c-ad99-6c41aba41132" },
                    { "45700a12-dd07-48da-88f3-7d0cedf5e2c7", "b697790c-f54d-4d61-866d-36bcf8a796ad" }
                });

            migrationBuilder.InsertData(
                table: "owners",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Email", "FullName", "IsDeleted", "PhoneNumber", "UpdatedAt" },
                values: new object[] { 1, "7000b361-ccf9-445c-ad99-6c41aba41132", new DateTime(2025, 2, 24, 21, 7, 43, 19, DateTimeKind.Utc).AddTicks(3228), "owner@medc.com", "John Doe", false, "123-456-7890", new DateTime(2025, 2, 24, 21, 7, 43, 19, DateTimeKind.Utc).AddTicks(3236) });

            migrationBuilder.InsertData(
                table: "veterinarians",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Email", "FullName", "IsDeleted", "PhoneNumber", "Specialty", "UpdatedAt", "YearsOfExperience", "salary" },
                values: new object[] { 1, "b697790c-f54d-4d61-866d-36bcf8a796ad", new DateTime(2025, 2, 24, 21, 7, 43, 87, DateTimeKind.Utc).AddTicks(9588), "veterinarian@medc.com", "Dr. Smith", false, "123-456-7890", "Small Animal", new DateTime(2025, 2, 24, 21, 7, 43, 87, DateTimeKind.Utc).AddTicks(9596), 5, 50000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5c6aecc-947d-43e7-ac01-727e9ebda46b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "260a2ee0-5bb5-4047-9550-9873ba07fa67", "1687b06c-3c63-4246-b89c-513f2e3a767c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dfda3e3d-dda8-40c7-8cf3-09e4d6087bd0", "7000b361-ccf9-445c-ad99-6c41aba41132" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "45700a12-dd07-48da-88f3-7d0cedf5e2c7", "b697790c-f54d-4d61-866d-36bcf8a796ad" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3afee06-6658-4d02-be60-f61ab55a381c");

            migrationBuilder.DeleteData(
                table: "owners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "veterinarians",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "260a2ee0-5bb5-4047-9550-9873ba07fa67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45700a12-dd07-48da-88f3-7d0cedf5e2c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dfda3e3d-dda8-40c7-8cf3-09e4d6087bd0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1687b06c-3c63-4246-b89c-513f2e3a767c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7000b361-ccf9-445c-ad99-6c41aba41132");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b697790c-f54d-4d61-866d-36bcf8a796ad");
        }
    }
}
