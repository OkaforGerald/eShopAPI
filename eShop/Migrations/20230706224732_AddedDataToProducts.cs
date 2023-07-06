using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShop.Migrations
{
    public partial class AddedDataToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9304), "Drinks", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9306), "Appliances", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9301), "Gaming", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9299), "Phone & Tablets", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                column: "CreatedAt",
                value: new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(8900));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                column: "CreatedAt",
                value: new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                column: "CreatedAt",
                value: new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(8895));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryId", "CreatedAt", "Description", "Name", "Price", "Quantity", "StoreId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("02a65d6c-03a7-45b7-813a-6bc2d441aa87"), "Binatone", new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9199), "This is fan is a onetime investment and is perfect for domestic use.", "Binatone 16 Inches Standing Fan", 19699m, 100, new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0b4dcc71-db12-49f1-8eef-95f2d4731183"), "Polystar", new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9183), "Polystar Andriod Smart HD 4K TV", "Polystar 65 Inch Andriod Smart 4K", 290000m, 14, new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0ff1feff-f735-44dc-b83b-63d720e34895"), "Sony Computer Entertainment", new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9203), "5-inch display, Single-chip custom processor, CPU: x86-64 AMD “Jaar”", "Sony Computer Entertainment PlayStation 4 Console 500gb", 155000m, 23, new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1d2c1899-c12f-49c0-b0e3-85d0264c989f"), "Infinix", new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9158), "Infinix Hot 30 Play comes with a 6.86-inch HD+ IPS LCD screen with a refresh rate of 90Hz.", "Infinix Hot 30 Play 8GB RAM/128GB ROM", 93000m, 6, new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2940a7c3-9afe-4723-b944-ab1dc06cd11f"), "Itel", new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9163), "Stronger battery with AI Power Master for longer-lasting entertainment and social experience. Always stay online and connected to the world. ", "Itel P40 6.6″ HD + Waterdrop FullScreen 64GB ROM + 7GB-BLACK", 56500m, 25, new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2d5623e8-c85b-4e0f-be6e-5c41964726a9"), "Martell", new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9171), "A sensation of fullness and generosity with notes of ginger and candied fruit, followed by distinctive hints of toasted oak from the Kentucky bourbon casks.", "Martell Cognac Blue Swift 75cl (VSOP)", 41000m, 8, new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3b4a05ed-e66c-4014-bb0a-5d8404afd881"), "Microsoft", new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9213), "Introducing the Xbox Series S, the smallest, sleekest Xbox console ever. Experience the speed and performance of a next-yygen all-digital console at an accessible price point.", "Microsoft Xbox Series S Console 512 GB SSD", 340000m, 2, new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74b6162f-d64d-4ae7-87b5-eb23b003d95a"), "Eva", new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9175), "Eva bottled water has been designed to be a perfect complement to everyday moments.", "Eva Water 150cl x12", 1850m, 14, new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7bd9dac4-70ba-4ed5-9d7f-c350a79cfa89"), "Vivo", new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9150), "The display size is 6.51 inches and the screen type is an IPS LCD capacitive touchscreen that has 270 PPI density while the resolution of the screen is 720 x 1600 pixels.", "Vivo Y02 6.51\" 2 RAM/32GB ROM Android 12- Cosmic Grey", 67420m, 65, new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9a84173c-ef20-46a2-a649-4989730bfc02"), "Polystar", new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9179), "Better Picture, Bigger Screen", "Polystar 32'' Inches LED TV", 72436m, 15, new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a91231b1-f8b4-4d52-a54c-8bc70d76b34d"), "Binatone", new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9187), "A unique fan from the Binatone Typhoon Series fans designed for the highest degree of air delivery in a home setting", "Binatone 20 Inches Typhoon Series Stand Fan", 34470m, 32, new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c696df54-d6d8-4e77-8c6c-babf265e44ef"), "Sony Computer Entertainment", new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9208), "", "Sony Computer Entertainment Gran Turismo 5", 2500m, 82, new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9364f3f-8330-42f0-aeb7-02eecf6d27f8"), "Jameson", new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9167), "Jameson Black Barrel is a triple-distilled, twice charred, Irish Whiskey. Charring is an age-old method for invigorating barrels to intensify the taste. ", "Jameson Black Barrel 70cl", 19501m, 5, new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5e20972-52e7-40b3-a06f-5bae24f8a2bf"), "Samsung", new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9154), "Samsung Galaxy A04 is a Smartphone manufactured by Samsung. The Samsung Galaxy A04 Android Smartphone has a 6.5-inch display, a 5000-mAh battery, 32GB of storage, and 3 GB of RAM.", "Samsung Galaxy A04 6.5\" 3GB RAM/32GB ROM Android 12 - Green", 71894m, 79, new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f28f89c7-8886-481c-972d-10bcbe69749c"), "Infinix", new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"), new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9140), "6.6” Waterdrop Sunlight Fullscreen Crispy-smooth Colors Even Under the Sun 6.6” HD+ Resolution 500nits Peak Brightness Smart 7 PLUS is outfitted with a bright 6.6-inch HD+ screen that boasts 500 nits of peak brightness, delivering a pleasing visual experience whether it’s outdoors or in sunny weather. ", "Infinix Smart 7 Plus 3GB RAM/64GB ROM Android 12- Green", 63800m, 100, new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("02a65d6c-03a7-45b7-813a-6bc2d441aa87"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0b4dcc71-db12-49f1-8eef-95f2d4731183"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0ff1feff-f735-44dc-b83b-63d720e34895"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1d2c1899-c12f-49c0-b0e3-85d0264c989f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2940a7c3-9afe-4723-b944-ab1dc06cd11f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d5623e8-c85b-4e0f-be6e-5c41964726a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("3b4a05ed-e66c-4014-bb0a-5d8404afd881"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("74b6162f-d64d-4ae7-87b5-eb23b003d95a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7bd9dac4-70ba-4ed5-9d7f-c350a79cfa89"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9a84173c-ef20-46a2-a649-4989730bfc02"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a91231b1-f8b4-4d52-a54c-8bc70d76b34d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("c696df54-d6d8-4e77-8c6c-babf265e44ef"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d9364f3f-8330-42f0-aeb7-02eecf6d27f8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e5e20972-52e7-40b3-a06f-5bae24f8a2bf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("f28f89c7-8886-481c-972d-10bcbe69749c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"));

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
    }
}
