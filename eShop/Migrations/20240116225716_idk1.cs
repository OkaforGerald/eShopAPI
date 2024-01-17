using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Migrations
{
    public partial class idk1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de6a23ff-0aeb-4edd-8a41-e9caff04d3c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4d160e6-17fb-40a4-9eaa-dfc4219e070b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "329386f7-10d9-4247-af41-4328985d823c", "c9326d1b-1d02-4602-af4f-82f181c7746e", "Administrator", "ADMINISTRATOR" },
                    { "a7a6bf7e-016d-4f56-b2c7-a1e54183bd94", "1378276c-c371-4132-8345-b986adf8356d", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3560));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3563));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3558));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3554));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("02a65d6c-03a7-45b7-813a-6bc2d441aa87"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3418));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0b4dcc71-db12-49f1-8eef-95f2d4731183"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3409));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ff1feff-f735-44dc-b83b-63d720e34895"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3423));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1d2c1899-c12f-49c0-b0e3-85d0264c989f"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2940a7c3-9afe-4723-b944-ab1dc06cd11f"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d5623e8-c85b-4e0f-be6e-5c41964726a9"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b4a05ed-e66c-4014-bb0a-5d8404afd881"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3433));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74b6162f-d64d-4ae7-87b5-eb23b003d95a"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3394));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7bd9dac4-70ba-4ed5-9d7f-c350a79cfa89"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3358));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9a84173c-ef20-46a2-a649-4989730bfc02"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a91231b1-f8b4-4d52-a54c-8bc70d76b34d"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3414));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c696df54-d6d8-4e77-8c6c-babf265e44ef"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3428));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9364f3f-8330-42f0-aeb7-02eecf6d27f8"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3381));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5e20972-52e7-40b3-a06f-5bae24f8a2bf"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f28f89c7-8886-481c-972d-10bcbe69749c"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 57, 14, 217, DateTimeKind.Local).AddTicks(3020));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "329386f7-10d9-4247-af41-4328985d823c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7a6bf7e-016d-4f56-b2c7-a1e54183bd94");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "de6a23ff-0aeb-4edd-8a41-e9caff04d3c5", "a1118b67-0fd0-40e8-ad19-74058e0472df", "User", "USER" },
                    { "f4d160e6-17fb-40a4-9eaa-dfc4219e070b", "5aa160c3-2d57-49dc-a47b-0fbe0ab165b8", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(4168));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(4166));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(4161));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("02a65d6c-03a7-45b7-813a-6bc2d441aa87"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3983));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0b4dcc71-db12-49f1-8eef-95f2d4731183"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3974));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ff1feff-f735-44dc-b83b-63d720e34895"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3988));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1d2c1899-c12f-49c0-b0e3-85d0264c989f"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3940));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2940a7c3-9afe-4723-b944-ab1dc06cd11f"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3944));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d5623e8-c85b-4e0f-be6e-5c41964726a9"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3959));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b4a05ed-e66c-4014-bb0a-5d8404afd881"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74b6162f-d64d-4ae7-87b5-eb23b003d95a"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3964));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7bd9dac4-70ba-4ed5-9d7f-c350a79cfa89"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3924));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9a84173c-ef20-46a2-a649-4989730bfc02"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a91231b1-f8b4-4d52-a54c-8bc70d76b34d"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3979));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c696df54-d6d8-4e77-8c6c-babf265e44ef"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3993));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9364f3f-8330-42f0-aeb7-02eecf6d27f8"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3949));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5e20972-52e7-40b3-a06f-5bae24f8a2bf"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3929));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f28f89c7-8886-481c-972d-10bcbe69749c"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3565));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3492));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 23, 31, 17, 571, DateTimeKind.Local).AddTicks(3559));
        }
    }
}
