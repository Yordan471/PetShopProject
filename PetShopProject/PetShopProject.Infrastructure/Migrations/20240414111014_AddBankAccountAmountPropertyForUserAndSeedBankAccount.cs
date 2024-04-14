using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopProject.Infrastructure.Migrations
{
    public partial class AddBankAccountAmountPropertyForUserAndSeedBankAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BankAccountAmount",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                comment: "User's money");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98cdd9b2-8c6a-49de-92e0-a1a997d1468e"),
                columns: new[] { "BankAccountAmount", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { 10000m, "ed2ecf0b-0d42-462f-8530-b6f76127880c", "AQAAAAEAACcQAAAAEKsmivj/ZllokKz9YWxC8NYRvDS6RToBhC0iotuG9Yn9xDEgAhldsnvr08xqP/+HXQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccountAmount",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98cdd9b2-8c6a-49de-92e0-a1a997d1468e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f609e18-5d81-4261-86ba-e35e14f2727f", "AQAAAAEAACcQAAAAELigL17yi3S0nv7JXD2FXDah4WugtLphXd7Xyeu6KzYC3mAT9j+2cxlQ5bqMvKfKTA==" });
        }
    }
}
