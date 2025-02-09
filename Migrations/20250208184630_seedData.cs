using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pharmacy_POS_System.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, "Tylenol" },
                    { 2, "Advil" },
                    { 3, "Zyrtec" },
                    { 4, "Nature Made" },
                    { 5, "Neutrogena" },
                    { 6, "Vicks" },
                    { 7, "Pepto-Bismol" },
                    { 8, "Bayer" },
                    { 9, "Aquaphor" },
                    { 10, "Glucerna" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Pain Relief" },
                    { 2, "Allergy & Sinus" },
                    { 3, "Cold & Flu" },
                    { 4, "Vitamins & Supplements" },
                    { 5, "Skin Care" },
                    { 6, "Digestive Health" },
                    { 7, "First Aid" },
                    { 8, "Diabetes Care" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "DefaultDiscount", "Description", "Name", "Price", "ProductImage", "Stock" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 2, 9, 0, 46, 26, 734, DateTimeKind.Local).AddTicks(2959), 0.0, "Pain reliever and fever reducer.", "Tylenol Extra Strength", 5.9900000000000002, "tylenol.jpg", 100 },
                    { 2, 2, 1, new DateTime(2025, 2, 9, 0, 46, 26, 734, DateTimeKind.Local).AddTicks(2982), 0.0, "Fast pain relief for headaches and muscle aches.", "Advil Liqui-Gels", 6.4900000000000002, "advil.jpg", 120 },
                    { 3, 8, 1, new DateTime(2025, 2, 9, 0, 46, 26, 734, DateTimeKind.Local).AddTicks(2991), 8.0, "Pain relief and heart health support.", "Bayer Aspirin", 4.9900000000000002, "bayer.jpg", 90 },
                    { 4, 3, 2, new DateTime(2025, 2, 9, 0, 46, 26, 734, DateTimeKind.Local).AddTicks(2993), 8.0, "24-hour allergy relief.", "Zyrtec Allergy Tablets", 12.99, "zyrtec.jpg", 80 },
                    { 5, 3, 2, new DateTime(2025, 2, 9, 0, 46, 26, 734, DateTimeKind.Local).AddTicks(2998), 7.0, "Fast-acting allergy relief.", "Claritin Non-Drowsy", 14.99, "claritin.jpg", 110 },
                    { 6, 3, 2, new DateTime(2025, 2, 9, 0, 46, 26, 734, DateTimeKind.Local).AddTicks(3005), 0.0, "Allergy nasal relief spray.", "Flonase Nasal Spray", 18.989999999999998, "flonase.jpg", 75 },
                    { 7, 6, 3, new DateTime(2025, 2, 9, 0, 46, 26, 734, DateTimeKind.Local).AddTicks(3007), 0.0, "Cold and flu relief.", "Vicks DayQuil", 8.9900000000000002, "dayquil.jpg", 95 },
                    { 8, 6, 3, new DateTime(2025, 2, 9, 0, 46, 26, 734, DateTimeKind.Local).AddTicks(3012), 6.0, "Nighttime flu relief.", "Vicks NyQuil", 9.4900000000000002, "nyquil.jpg", 90 },
                    { 9, 6, 3, new DateTime(2025, 2, 9, 0, 46, 26, 734, DateTimeKind.Local).AddTicks(3016), 8.0, "Expectorant and cough suppressant.", "Mucinex DM", 11.99, "mucinex.jpg", 85 },
                    { 10, 4, 4, new DateTime(2025, 2, 9, 0, 46, 26, 734, DateTimeKind.Local).AddTicks(3021), 7.0, "Supports immune health.", "Vitamin C Gummies", 9.9900000000000002, "vitamin_c.jpg", 150 },
                    { 11, 4, 4, new DateTime(2025, 2, 9, 0, 46, 26, 734, DateTimeKind.Local).AddTicks(3024), 0.0, "Daily essential vitamins.", "Nature Made Multivitamin", 13.99, "multivitamin.jpg", 130 },
                    { 12, 4, 4, new DateTime(2025, 2, 9, 0, 46, 26, 734, DateTimeKind.Local).AddTicks(3029), 8.0, "Supports heart and brain health.", "Fish Oil Omega-3", 15.99, "fish_oil.jpg", 110 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "BrandId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);
        }
    }
}
