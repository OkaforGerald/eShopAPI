using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Migrations
{
    public partial class IntialValuesForStores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Country", "CreatedAt", "Email", "Name", "PhoneNumber", "UpdatedAt", "Url" },
                values: new object[] { new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"), "Herzogenaurach, Bavaria, Germany.", "Germany", new DateTime(2023, 7, 1, 17, 53, 34, 165, DateTimeKind.Local).AddTicks(4215), "media.africa@puma.com", "Puma SE", "+44-800-379-6453", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "us.puma.com" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Country", "CreatedAt", "Email", "Name", "PhoneNumber", "UpdatedAt", "Url" },
                values: new object[] { new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"), "Washington County near Beaverton, Oregon, U.S.", "United States", new DateTime(2023, 7, 1, 17, 53, 34, 165, DateTimeKind.Local).AddTicks(4179), "media.africa@nike.com", "Nike Inc.", "1-800-379-6453", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.nike.com" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Country", "CreatedAt", "Email", "Name", "PhoneNumber", "UpdatedAt", "Url" },
                values: new object[] { new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"), "Herzogenaurach, Bavaria, Germany.", "Germany", new DateTime(2023, 7, 1, 17, 53, 34, 165, DateTimeKind.Local).AddTicks(4209), "media.africa@adidas.com", "Adidas AG", "+49 9132 84 2352", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "www.adidas.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"));

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"));
        }
    }
}
