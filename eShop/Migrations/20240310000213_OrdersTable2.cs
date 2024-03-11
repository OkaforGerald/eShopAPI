using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Migrations
{
    public partial class OrdersTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Orders_OrderId",
                table: "Products");

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

            migrationBuilder.CreateTable(
                name: "OrdersProducts",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_ProductId",
                table: "OrdersProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersProducts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc16783b-0758-44f2-b2c3-ebd5f8562267");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed0cf42d-a97e-4a29-a318-61281b28c312");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
