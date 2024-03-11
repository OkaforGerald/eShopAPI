using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Migrations
{
    public partial class OrdersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "696703e5-5a6d-4cb3-b672-3c0b7ad684a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84592251-65f3-4e3d-b838-2c317af55c13");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Buyer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "166200cb-a8ff-4bfc-96f5-569a9d3f0925", "37195a47-b7f5-4c1c-9b8b-7e248a5490f1", "Administrator", "ADMINISTRATOR" },
                    { "7df34d1b-eb60-4419-98e7-78db9388418d", "bb19a1c2-d978-4b1e-ad5f-2f8956eac7aa", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(165));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(166));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(163));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("02a65d6c-03a7-45b7-813a-6bc2d441aa87"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(45));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0b4dcc71-db12-49f1-8eef-95f2d4731183"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(38));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ff1feff-f735-44dc-b83b-63d720e34895"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(50));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1d2c1899-c12f-49c0-b0e3-85d0264c989f"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(10));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2940a7c3-9afe-4723-b944-ab1dc06cd11f"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(15));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d5623e8-c85b-4e0f-be6e-5c41964726a9"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(23));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b4a05ed-e66c-4014-bb0a-5d8404afd881"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(58));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74b6162f-d64d-4ae7-87b5-eb23b003d95a"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(27));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7bd9dac4-70ba-4ed5-9d7f-c350a79cfa89"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(1));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9a84173c-ef20-46a2-a649-4989730bfc02"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(31));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a91231b1-f8b4-4d52-a54c-8bc70d76b34d"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(41));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c696df54-d6d8-4e77-8c6c-babf265e44ef"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(54));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9364f3f-8330-42f0-aeb7-02eecf6d27f8"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(19));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5e20972-52e7-40b3-a06f-5bae24f8a2bf"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 545, DateTimeKind.Local).AddTicks(6));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f28f89c7-8886-481c-972d-10bcbe69749c"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 544, DateTimeKind.Local).AddTicks(9992));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 544, DateTimeKind.Local).AddTicks(9739));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 544, DateTimeKind.Local).AddTicks(9706));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 9, 23, 52, 12, 544, DateTimeKind.Local).AddTicks(9735));

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderId",
                table: "Products",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Products_OrderId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "166200cb-a8ff-4bfc-96f5-569a9d3f0925");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7df34d1b-eb60-4419-98e7-78db9388418d");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "696703e5-5a6d-4cb3-b672-3c0b7ad684a0", "3b3db488-9904-48c3-b46a-d4158173d66e", "User", "USER" },
                    { "84592251-65f3-4e3d-b838-2c317af55c13", "8cdd4c43-7652-40f7-bf67-febbd481a361", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9879));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9871));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9860));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("02a65d6c-03a7-45b7-813a-6bc2d441aa87"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9346));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0b4dcc71-db12-49f1-8eef-95f2d4731183"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ff1feff-f735-44dc-b83b-63d720e34895"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9354));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1d2c1899-c12f-49c0-b0e3-85d0264c989f"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2940a7c3-9afe-4723-b944-ab1dc06cd11f"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d5623e8-c85b-4e0f-be6e-5c41964726a9"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b4a05ed-e66c-4014-bb0a-5d8404afd881"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9376));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74b6162f-d64d-4ae7-87b5-eb23b003d95a"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9315));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7bd9dac4-70ba-4ed5-9d7f-c350a79cfa89"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9138));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9a84173c-ef20-46a2-a649-4989730bfc02"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a91231b1-f8b4-4d52-a54c-8bc70d76b34d"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c696df54-d6d8-4e77-8c6c-babf265e44ef"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9364f3f-8330-42f0-aeb7-02eecf6d27f8"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9298));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5e20972-52e7-40b3-a06f-5bae24f8a2bf"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9172));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f28f89c7-8886-481c-972d-10bcbe69749c"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(9045));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(8538));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(8472));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 6, 21, 48, 14, 701, DateTimeKind.Local).AddTicks(8532));
        }
    }
}
