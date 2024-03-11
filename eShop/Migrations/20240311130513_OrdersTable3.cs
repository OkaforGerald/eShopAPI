using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Migrations
{
    public partial class OrdersTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc16783b-0758-44f2-b2c3-ebd5f8562267");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed0cf42d-a97e-4a29-a318-61281b28c312");

            migrationBuilder.AddColumn<int>(
                name: "QuantityOrdered",
                table: "OrdersProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9156815e-c29e-46ad-b7ae-2809eaa5850b", "ea175499-159e-45d7-9530-8aef5777c742", "Administrator", "ADMINISTRATOR" },
                    { "d43c8eb3-031a-4d2a-ac58-d904a278f7d8", "67cc7e16-91d9-45fd-978f-2d32adfbd6d2", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(817));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(819));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(816));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(812));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("02a65d6c-03a7-45b7-813a-6bc2d441aa87"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(690));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0b4dcc71-db12-49f1-8eef-95f2d4731183"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ff1feff-f735-44dc-b83b-63d720e34895"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(694));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1d2c1899-c12f-49c0-b0e3-85d0264c989f"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(418));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2940a7c3-9afe-4723-b944-ab1dc06cd11f"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d5623e8-c85b-4e0f-be6e-5c41964726a9"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(671));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b4a05ed-e66c-4014-bb0a-5d8404afd881"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(705));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74b6162f-d64d-4ae7-87b5-eb23b003d95a"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(674));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7bd9dac4-70ba-4ed5-9d7f-c350a79cfa89"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(409));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9a84173c-ef20-46a2-a649-4989730bfc02"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(678));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a91231b1-f8b4-4d52-a54c-8bc70d76b34d"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(686));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c696df54-d6d8-4e77-8c6c-babf265e44ef"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(702));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9364f3f-8330-42f0-aeb7-02eecf6d27f8"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(665));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5e20972-52e7-40b3-a06f-5bae24f8a2bf"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f28f89c7-8886-481c-972d-10bcbe69749c"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(322));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(97));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(67));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 11, 14, 5, 12, 983, DateTimeKind.Local).AddTicks(92));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9156815e-c29e-46ad-b7ae-2809eaa5850b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d43c8eb3-031a-4d2a-ac58-d904a278f7d8");

            migrationBuilder.DropColumn(
                name: "QuantityOrdered",
                table: "OrdersProducts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cc16783b-0758-44f2-b2c3-ebd5f8562267", "18f03dad-48db-4af2-a869-73092722e25e", "User", "USER" },
                    { "ed0cf42d-a97e-4a29-a318-61281b28c312", "23e939f5-5b59-4124-a1c8-a857ad0cbdf4", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(8090));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(8092));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(8088));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(8084));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("02a65d6c-03a7-45b7-813a-6bc2d441aa87"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7966));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0b4dcc71-db12-49f1-8eef-95f2d4731183"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7958));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ff1feff-f735-44dc-b83b-63d720e34895"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7971));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1d2c1899-c12f-49c0-b0e3-85d0264c989f"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7929));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2940a7c3-9afe-4723-b944-ab1dc06cd11f"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7936));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d5623e8-c85b-4e0f-be6e-5c41964726a9"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b4a05ed-e66c-4014-bb0a-5d8404afd881"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7979));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74b6162f-d64d-4ae7-87b5-eb23b003d95a"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7949));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7bd9dac4-70ba-4ed5-9d7f-c350a79cfa89"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7919));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9a84173c-ef20-46a2-a649-4989730bfc02"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7953));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a91231b1-f8b4-4d52-a54c-8bc70d76b34d"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7961));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c696df54-d6d8-4e77-8c6c-babf265e44ef"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7976));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9364f3f-8330-42f0-aeb7-02eecf6d27f8"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7940));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5e20972-52e7-40b3-a06f-5bae24f8a2bf"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7923));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f28f89c7-8886-481c-972d-10bcbe69749c"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7494));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7450));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 1, 2, 12, 297, DateTimeKind.Local).AddTicks(7489));
        }
    }
}
