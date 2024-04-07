using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopProject.Infrastructure.Migrations
{
    public partial class ChangingSeedAdminSeedAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6f45410f-ae12-46bf-a736-429395a0574d"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Addresses");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "PostalCode", "Street" },
                values: new object[] { 1, "Sofia", "1000", "ul. Lelin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressId", "ConcurrencyStamp", "ContactPreferance", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RecipientName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("98cdd9b2-8c6a-49de-92e0-a1a997d1468e"), 0, 1, "821119eb-f357-4e58-b935-d30f4a58a016", 0, "jordan4.71@abv.bg", false, "Yordan", "Ivanov", false, null, "JORDAN4.71@ABV.BG", "IVANOV", "AQAAAAEAACcQAAAAEGJqBYgaJGAGcy1iuWNHSyVel5EziV3TLOSGBL87aSM6339gpiZbkyh8BFlGRLEycA==", null, false, "", null, false, "Ivanov" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98cdd9b2-8c6a-49de-92e0-a1a997d1468e"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                comment: "User identifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("6f45410f-ae12-46bf-a736-429395a0574d"), "51808c16-04e9-4716-846a-31abc6db4a61", "Name", "ADMIN" });
        }
    }
}
