using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class datas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3155ed94-b4d0-4e14-ab4d-53c68d725401");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9428f1f4-2c39-4fce-892c-85f349322fd0", "86854584-fb05-4bfa-ae19-51dc71540f59" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "409901fa-62fc-4352-a873-b674d5140611", "b9ac39b7-df87-4572-a369-d1083a507b4e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "62a9c6e3-04be-4a4c-9a4a-1aa2a32d0c66", "bc254da1-e0eb-4818-ab6f-90e7ece2eb07" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "21d4f4a9-8e26-416e-9d6b-a5c7e5b170d3");

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
                keyValue: "409901fa-62fc-4352-a873-b674d5140611");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62a9c6e3-04be-4a4c-9a4a-1aa2a32d0c66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9428f1f4-2c39-4fce-892c-85f349322fd0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86854584-fb05-4bfa-ae19-51dc71540f59");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b9ac39b7-df87-4572-a369-d1083a507b4e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc254da1-e0eb-4818-ab6f-90e7ece2eb07");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }
    }
}
