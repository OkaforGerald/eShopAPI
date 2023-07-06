using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Migrations
{
    public partial class SchemaChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                column: "CreatedAt",
                value: new DateTime(2023, 7, 6, 22, 16, 3, 742, DateTimeKind.Local).AddTicks(9970));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                column: "CreatedAt",
                value: new DateTime(2023, 7, 6, 22, 16, 3, 742, DateTimeKind.Local).AddTicks(9937));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                column: "CreatedAt",
                value: new DateTime(2023, 7, 6, 22, 16, 3, 742, DateTimeKind.Local).AddTicks(9965));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                column: "CreatedAt",
                value: new DateTime(2023, 7, 1, 17, 53, 34, 165, DateTimeKind.Local).AddTicks(4215));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                column: "CreatedAt",
                value: new DateTime(2023, 7, 1, 17, 53, 34, 165, DateTimeKind.Local).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                column: "CreatedAt",
                value: new DateTime(2023, 7, 1, 17, 53, 34, 165, DateTimeKind.Local).AddTicks(4209));
        }
    }
}
