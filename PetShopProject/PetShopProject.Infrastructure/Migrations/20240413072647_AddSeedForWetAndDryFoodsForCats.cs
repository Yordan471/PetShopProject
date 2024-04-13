using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopProject.Infrastructure.Migrations
{
    public partial class AddSeedForWetAndDryFoodsForCats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98cdd9b2-8c6a-49de-92e0-a1a997d1468e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f609e18-5d81-4261-86ba-e35e14f2727f", "AQAAAAEAACcQAAAAELigL17yi3S0nv7JXD2FXDah4WugtLphXd7Xyeu6KzYC3mAT9j+2cxlQ5bqMvKfKTA==" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "AnimalType", "CategoryId", "ImageUrl", "LongDescription", "Name", "Price", "Quantity", "ShortDescription" },
                values: new object[,]
                {
                    { 26, "Котка", 1, "~/Images/Products/Cats/DryFoods/Royal_Canin_Indoor_Cat.jpg", "Пълноценна суха храна за котки над 1 година, живеещи предимно на закрито. Помага за поддържане на идеално тегло и здравето на пикочните пътища.", "Royal Canin Indoor 27", 45.99m, 500, "Суха храна за котки живеещи на закрито" },
                    { 27, "Котка", 1, "~/Images/Products/Cats/DryFoods/Hills_Science_Plan_Adult_Optimal_Care.jpg", "Висококачествена суха храна за котки от 1 до 6 години с пиле. Поддържа здравето на кожата и козината, и подпомага храносмилането.", "Hill's Science Plan Adult Optimal Care", 39.99m, 500, "Суха храна за възрастни котки" },
                    { 28, "Котка", 1, "~/Images/Products/Cats/DryFoods/Purina_Pro_Plan_Sterilised.jpg", "Пълноценна суха храна за кастрирани котки. Съдържа пуешко месо и е с намалено съдържание на мазнини за поддържане на идеално тегло.", "Purina Pro Plan Sterilised", 42.99m, 500, "Суха храна за кастрирани котки" },
                    { 29, "Котка", 1, "~/Images/Products/Cats/DryFoods/whiskas_adult.jpg", "Пълноценна и балансирана суха храна за котки над 1 година с високо съдържание на пилешко месо. Поддържа естествените защитни сили на организма.", "Whiskas Adult", 24.99m, 500, "Суха храна за възрастни котки с пиле" },
                    { 30, "Котка", 1, "~/Images/Products/Cats/DryFoods/animonda_carny_adult.jpg", "Висококачествена суха храна за възрастни котки с говеждо, пуешко и заешко месо. Без зърнени съставки и с добавен таурин за здраво сърце.", "Animonda Carny Adult", 37.99m, 500, "Суха храна за възрастни котки" },
                    { 31, "Котка", 2, "~/Images/Products/Cats/WetFoods/royalcanin_instinctivein_gelee.jpg", "Пълноценна консервирана храна за котки над 1 година в желе. Поддържа идеално тегло и жизненост благодарение на балансираното съдържание на хранителни вещества.", "Royal Canin Instinctive в желе", 2.99m, 500, "Консервирана храна за котки в желе" },
                    { 32, "Котка", 2, "~/Images/Products/Cats/WetFoods/whiskas_pauch_pileshko_meso.jpg", "Пълноценна консервирана храна за възрастни котки с високо съдържание на пилешко месо в сос. Осигурява балансирано хранене и поддържа здравето на уринарния тракт.", "Whiskas Adult с пиле в сос", 1.99m, 500, "Консервирана храна за възрастни котки" },
                    { 33, "Котка", 2, "~/Images/Products/Cats/WetFoods/Purina_Felix_Fantastic.jpg", "Консервирана храна за котки с апетитни парченца говеждо месо в желе. Съдържа всички необходими хранителни вещества за здраве и жизненост.", "Purina Felix Fantastic с говеждо в желе", 2.49m, 500, "Консервирана храна за котки с говеждо" },
                    { 34, "Котка", 2, "~/Images/Products/Cats/WetFoods/animonda_vomfeinsten_adult.jpg", "Висококачествена консервирана храна за възрастни котки с пуешко и заешко месо. Без зърнени съставки, изкуствени оцветители и консерванти.", "Animonda Vom Feinsten Adult с пуешко и заешко", 3.29m, 500, "Консервирана храна за възрастни котки" },
                    { 35, "Котка", 2, "~/Images/Products/Cats/WetFoods/hills_science_plan_dult_cat_wet_food.jpg", "Пълноценна консервирана храна за възрастни котки с риба тон. Поддържа здравето на кожата и козината, и подпомага функцията на уринарния тракт.", "Hill's Science Plan Adult", 3.99m, 500, "Консервирана храна за котки с риба тон" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("98cdd9b2-8c6a-49de-92e0-a1a997d1468e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "63e48b0a-6256-4bc9-96ef-e694520e050f", "AQAAAAEAACcQAAAAEJtOvGtSQ/u238/dLSuJdLvlZKBA23m4elIdlm1iDOPRJbuEcAlNFlaGkUml0a6kCQ==" });
        }
    }
}
