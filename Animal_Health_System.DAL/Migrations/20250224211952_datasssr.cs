using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class datasssr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39e20152-d287-40b6-8d0b-91d16a2f9e24", null, "Owner", "OWNER" },
                    { "4f5ab0c9-ab78-4fde-b965-1e784090b03e", null, "FarmStaff", "FARMSTAFF" },
                    { "6718366f-9a2c-4ff9-a636-9e921ed4b59e", null, "Admin", "ADMIN" },
                    { "7a93bdf8-3cd5-4091-8e9c-d39a8ad8a82d", null, "Veterinarian", "VETERINARIAN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6c742aa7-9293-41cc-ba62-03f1de2e81a9", 0, null, "688b5258-4de3-4960-bc0b-e643f49e919e", "veterinarian@medc.com", true, null, false, null, "VETERINARIAN@MEDC.COM", "VETERINARIAN@MEDC.COM", "AQAAAAIAAYagAAAAEPgQ5H9gI5MRwsV9t/pPYru+TOa00TjzJ3rYvFMvI8jfjA2XdpQwf+kjBAqvtLFzTw==", null, false, "Veterinarian", "59055c33-5d41-4375-9668-0246e0cb15ae", false, "veterinarian@medc.com" },
                    { "a0f98e59-b764-49c4-b318-8c578ee9f1b2", 0, null, "2830a24d-8624-4848-beb0-ec6802f51a0a", "owner@medc.com", true, null, false, null, "OWNER@MEDC.COM", "OWNER@MEDC.COM", "AQAAAAIAAYagAAAAEPHXR0mepcDgPtiUnE094GqFxlJs5lbBqwCfm/O+7UeFTdp4Q5D+8E4BnZK/Ogg8VA==", null, false, "Owner", "7a7f42e1-81e6-495e-9275-a365a3ec49c5", false, "owner@medc.com" },
                    { "e02a0899-0db9-4df2-8a9a-4e8ea9109804", 0, null, "23d86d68-d08e-4207-96f7-0bef2b197d2e", "admin@medc.com", true, null, false, null, "ADMIN@MEDC.COM", "ADMIN@MEDC.COM", "AQAAAAIAAYagAAAAEERGBt3usCm5dKAcxXbI6pmC8C9VrXxJui/OhaqRKUs384S126j0/L8zdx0nGvkC9g==", null, false, "Admin", "f4579bb6-fd89-4345-8511-55c0b4f8e52d", false, "admin@medc.com" },
                    { "e7b2b8f0-bb06-4ff7-a867-25adc5feb4bd", 0, null, "7d1a6b95-21fb-4f24-a227-09be25746e46", "farmstaff@medc.com", true, null, false, null, "FARMSTAFF@MEDC.COM", "FARMSTAFF@MEDC.COM", "AQAAAAIAAYagAAAAEFZmKuH1eF0V6QJjgyWfTeDmbPPzhGUfgcz2cFFH/CBSFCE1lNqGrecuKyhhypXczA==", null, false, "FarmStaff", "ba97b1df-d248-4407-b0f6-1e298a461185", false, "farmstaff@medc.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "7a93bdf8-3cd5-4091-8e9c-d39a8ad8a82d", "6c742aa7-9293-41cc-ba62-03f1de2e81a9" },
                    { "39e20152-d287-40b6-8d0b-91d16a2f9e24", "a0f98e59-b764-49c4-b318-8c578ee9f1b2" },
                    { "4f5ab0c9-ab78-4fde-b965-1e784090b03e", "e7b2b8f0-bb06-4ff7-a867-25adc5feb4bd" }
                });

            migrationBuilder.InsertData(
                table: "owners",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Email", "FullName", "IsDeleted", "PhoneNumber", "UpdatedAt" },
                values: new object[] { 1, "a0f98e59-b764-49c4-b318-8c578ee9f1b2", new DateTime(2025, 2, 24, 21, 19, 51, 399, DateTimeKind.Utc).AddTicks(4718), "owner@medc.com", "John Doe", false, "123-456-7890", new DateTime(2025, 2, 24, 21, 19, 51, 399, DateTimeKind.Utc).AddTicks(4727) });

            migrationBuilder.InsertData(
                table: "veterinarians",
                columns: new[] { "Id", "ApplicationUserId", "CreatedAt", "Email", "FullName", "IsDeleted", "PhoneNumber", "Specialty", "UpdatedAt", "YearsOfExperience", "salary" },
                values: new object[] { 1, "6c742aa7-9293-41cc-ba62-03f1de2e81a9", new DateTime(2025, 2, 24, 21, 19, 51, 480, DateTimeKind.Utc).AddTicks(9198), "veterinarian@medc.com", "Dr. Smith", false, "123-456-7890", "Small Animal", new DateTime(2025, 2, 24, 21, 19, 51, 480, DateTimeKind.Utc).AddTicks(9204), 5, 50000m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6718366f-9a2c-4ff9-a636-9e921ed4b59e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7a93bdf8-3cd5-4091-8e9c-d39a8ad8a82d", "6c742aa7-9293-41cc-ba62-03f1de2e81a9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "39e20152-d287-40b6-8d0b-91d16a2f9e24", "a0f98e59-b764-49c4-b318-8c578ee9f1b2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4f5ab0c9-ab78-4fde-b965-1e784090b03e", "e7b2b8f0-bb06-4ff7-a867-25adc5feb4bd" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e02a0899-0db9-4df2-8a9a-4e8ea9109804");

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
                keyValue: "39e20152-d287-40b6-8d0b-91d16a2f9e24");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f5ab0c9-ab78-4fde-b965-1e784090b03e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a93bdf8-3cd5-4091-8e9c-d39a8ad8a82d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c742aa7-9293-41cc-ba62-03f1de2e81a9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0f98e59-b764-49c4-b318-8c578ee9f1b2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7b2b8f0-bb06-4ff7-a867-25adc5feb4bd");
        }
    }
}
