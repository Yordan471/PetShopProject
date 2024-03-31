using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopProject.Infrastructure.Migrations
{
    public partial class ChangeImageUrlPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/DryFoods/Royal_Canin_Adult.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/DryFoods/Hills_Science_Plan_Puppy.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/DryFoods/Purina_Pro_Plan_Adult_Dog.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/DryFoods/Arcana_Wild_Pairie_Adult_Dog.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/DryFoods/ORIJEN_Six_Fish Dry_Dog_Food.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/WetFoods/Royal_Canin_Wet_Good.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/WetFoods/Hills_Science_Diet_Wet_Food.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/WetFoods/Purina_ONE_SmartBlend.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/WetFoods/Pedigree_Chopped_Ground_Food.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/WetFoods/CESAR_Adult_Wet_Dog_Food.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/Treats/Zukes_Mini_Naturals_Dog.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/Treats/Blue_Buffalo_Wilderness_Trail_Treats.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/Treats/Greenies_Original_Dog_Dental_Chew.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/Treats/Pup-Peroni_Original_Lean_Beef_Flavor.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/Treats/Wellness_Soft_Puppy_Bites.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/SupplementsVitamins/nuvet_plus.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/SupplementsVitamins/Zesty_Paws_Multivitamin.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/SupplementsVitamins/Pet_Honesty_Omega-3_Oil.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/SupplementsVitamins/VetriScience_GlycoFlex.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/SupplementsVitamins/Purina_Pro_Plan_Fortiflora.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/Аccessories/KONG_Classic_Dog_Toy.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/Аccessories/Furhaven_Orthopedic_Dog_Bed.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/Аccessories/Ruffwear_Front_Range_Dog_Harness.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/Аccessories/Chuckit!_Ultra_Ball.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "ImageUrl",
                value: "~/Images/Products/Dogs/Аccessories/Nylabone_Dura_Chew.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/DryFoods/Royal_Canin_Adult.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/DryFoods/Hills_Science_Plan_Puppy.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/DryFoods/Purina_Pro_Plan_Adult_Dog.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/DryFoods/Arcana_Wild_Pairie_Adult_Dog.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/DryFoods/ORIJEN_Six_Fish Dry_Dog_Food.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/WetFoods/Royal_Canin_Wet_Good.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/WetFoods/Hills_Science_Diet_Wet_Food.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/WetFoods/Purina_ONE_SmartBlend.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/WetFoods/Pedigree_Chopped_Ground_Food.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/WetFoods/CESAR_Adult_Wet_Dog_Food.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/Treats/Zukes_Mini_Naturals_Dog.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/Treats/Blue_Buffalo_Wilderness_Trail_Treats.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/Treats/Greenies_Original_Dog_Dental_Chew.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/Treats/Pup-Peroni_Original_Lean_Beef_Flavor.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/Treats/Wellness_Soft_Puppy_Bites.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/SupplementsVitamins/nuvet_plus.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/SupplementsVitamins/Zesty_Paws_Multivitamin.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/SupplementsVitamins/Pet_Honesty_Omega-3_Oil.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/SupplementsVitamins/VetriScience_GlycoFlex.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/SupplementsVitamins/Purina_Pro_Plan_Fortiflora.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/Аccessories/KONG_Classic_Dog_Toy.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/Аccessories/Furhaven_Orthopedic_Dog_Bed.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/Аccessories/Ruffwear_Front_Range_Dog_Harness.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/Аccessories/Chuckit!_Ultra_Ball.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                column: "ImageUrl",
                value: "wwwroot/Images/Products/Dogs/Аccessories/Nylabone_Dura_Chew.jpg");
        }
    }
}
