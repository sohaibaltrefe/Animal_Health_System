using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Animal_Health_System.DAL.Migrations
{
    /// <inheritdoc />
    public partial class datasss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c210945-5ce7-4f85-83b7-3ec2f924d7b4", null, "Owner", "OWNER" },
                    { "42d16c81-3fd2-4b32-a124-6cdc7eac81e0", null, "Veterinarian", "VETERINARIAN" },
                    { "82d3cc43-884f-4645-b14b-5e0c9f203974", null, "FarmStaff", "FARMSTAFF" },
                    { "db4aa3d3-9624-4d4d-9f06-b6a3e754f107", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "081f06dd-9a60-4659-a706-e5fb11235349", 0, null, "401c9c8c-b30c-41b3-a982-1724048f3f1f", "admin@medc.com", true, null, false, null, "ADMIN@MEDC.COM", "ADMIN@MEDC.COM", "AQAAAAIAAYagAAAAEPlXRrigjzkDMs22fHPCW90sHycswz7QeEFtaSUccWCBgEzOnlDmzrof26xqoPs9yA==", null, false, "Admin", "f237e474-58d1-40b5-a27b-e17789d72265", false, "admin@medc.com" },
                    { "6a4e1c98-6d0e-4f06-8115-d00c23666eaa", 0, null, "f87c7a93-b609-4f41-84e7-0e29298bad80", "veterinarian@medc.com", true, null, false, null, "VETERINARIAN@MEDC.COM", "VETERINARIAN@MEDC.COM", "AQAAAAIAAYagAAAAEOaEknNUERJvoCE9C7iBoS7u1MlO+kJukC+9JGbxdjX7JItgqp5fAP7YoucVld9NIw==", null, false, "Veterinarian", "b8a042e8-a192-447e-8702-625e2be68c23", false, "veterinarian@medc.com" },
                    { "ab6103c4-e8d7-498e-82be-3879847ccbda", 0, null, "6fb91ebc-248a-4baa-8709-054b06e71028", "farmstaff@medc.com", true, null, false, null, "FARMSTAFF@MEDC.COM", "FARMSTAFF@MEDC.COM", "AQAAAAIAAYagAAAAECTsj4/dbuDZb77cf0MMxMCyH3+zTPcWRpGQFnxPnD9AnwfxHv664BI5RrSexVGcrg==", null, false, "FarmStaff", "e5d559a5-803f-4999-8661-0a7a2a05380e", false, "farmstaff@medc.com" },
                    { "c8bf3466-ec8f-4f41-a4f9-3ccbd186b930", 0, null, "60952052-97b9-4052-8252-9c526eb7543e", "owner@medc.com", true, null, false, null, "OWNER@MEDC.COM", "OWNER@MEDC.COM", "AQAAAAIAAYagAAAAENvL5keWnVZU+nm7VJPXr9934toQhxp9EXv87XL5TMJlilCKqrfIlMlGlwFehD8qWQ==", null, false, "Owner", "14892a1e-61e9-4c33-9a84-036fe6fc9a51", false, "owner@medc.com" }
                });

            migrationBuilder.UpdateData(
                table: "owners",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "CreatedAt", "UpdatedAt" },
                values: new object[] { "c8bf3466-ec8f-4f41-a4f9-3ccbd186b930", new DateTime(2025, 2, 24, 21, 14, 33, 248, DateTimeKind.Utc).AddTicks(1560), new DateTime(2025, 2, 24, 21, 14, 33, 248, DateTimeKind.Utc).AddTicks(1568) });

            migrationBuilder.UpdateData(
                table: "veterinarians",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "CreatedAt", "UpdatedAt" },
                values: new object[] { "6a4e1c98-6d0e-4f06-8115-d00c23666eaa", new DateTime(2025, 2, 24, 21, 14, 33, 309, DateTimeKind.Utc).AddTicks(3685), new DateTime(2025, 2, 24, 21, 14, 33, 309, DateTimeKind.Utc).AddTicks(3693) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "42d16c81-3fd2-4b32-a124-6cdc7eac81e0", "6a4e1c98-6d0e-4f06-8115-d00c23666eaa" },
                    { "82d3cc43-884f-4645-b14b-5e0c9f203974", "ab6103c4-e8d7-498e-82be-3879847ccbda" },
                    { "0c210945-5ce7-4f85-83b7-3ec2f924d7b4", "c8bf3466-ec8f-4f41-a4f9-3ccbd186b930" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db4aa3d3-9624-4d4d-9f06-b6a3e754f107");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "42d16c81-3fd2-4b32-a124-6cdc7eac81e0", "6a4e1c98-6d0e-4f06-8115-d00c23666eaa" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "82d3cc43-884f-4645-b14b-5e0c9f203974", "ab6103c4-e8d7-498e-82be-3879847ccbda" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0c210945-5ce7-4f85-83b7-3ec2f924d7b4", "c8bf3466-ec8f-4f41-a4f9-3ccbd186b930" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "081f06dd-9a60-4659-a706-e5fb11235349");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c210945-5ce7-4f85-83b7-3ec2f924d7b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "42d16c81-3fd2-4b32-a124-6cdc7eac81e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82d3cc43-884f-4645-b14b-5e0c9f203974");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6a4e1c98-6d0e-4f06-8115-d00c23666eaa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ab6103c4-e8d7-498e-82be-3879847ccbda");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8bf3466-ec8f-4f41-a4f9-3ccbd186b930");

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

            migrationBuilder.UpdateData(
                table: "owners",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "CreatedAt", "UpdatedAt" },
                values: new object[] { "7000b361-ccf9-445c-ad99-6c41aba41132", new DateTime(2025, 2, 24, 21, 7, 43, 19, DateTimeKind.Utc).AddTicks(3228), new DateTime(2025, 2, 24, 21, 7, 43, 19, DateTimeKind.Utc).AddTicks(3236) });

            migrationBuilder.UpdateData(
                table: "veterinarians",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationUserId", "CreatedAt", "UpdatedAt" },
                values: new object[] { "b697790c-f54d-4d61-866d-36bcf8a796ad", new DateTime(2025, 2, 24, 21, 7, 43, 87, DateTimeKind.Utc).AddTicks(9588), new DateTime(2025, 2, 24, 21, 7, 43, 87, DateTimeKind.Utc).AddTicks(9596) });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "260a2ee0-5bb5-4047-9550-9873ba07fa67", "1687b06c-3c63-4246-b89c-513f2e3a767c" },
                    { "dfda3e3d-dda8-40c7-8cf3-09e4d6087bd0", "7000b361-ccf9-445c-ad99-6c41aba41132" },
                    { "45700a12-dd07-48da-88f3-7d0cedf5e2c7", "b697790c-f54d-4d61-866d-36bcf8a796ad" }
                });
        }
    }
}
