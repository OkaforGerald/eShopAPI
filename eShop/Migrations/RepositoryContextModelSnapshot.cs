﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repository;

#nullable disable

namespace eShop.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9299),
                            Name = "Phone & Tablets",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9301),
                            Name = "Gaming",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9304),
                            Name = "Drinks",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9306),
                            Name = "Appliances",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("StoreId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f28f89c7-8886-481c-972d-10bcbe69749c"),
                            Brand = "Infinix",
                            CategoryId = new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9140),
                            Description = "6.6” Waterdrop Sunlight Fullscreen Crispy-smooth Colors Even Under the Sun 6.6” HD+ Resolution 500nits Peak Brightness Smart 7 PLUS is outfitted with a bright 6.6-inch HD+ screen that boasts 500 nits of peak brightness, delivering a pleasing visual experience whether it’s outdoors or in sunny weather. ",
                            Name = "Infinix Smart 7 Plus 3GB RAM/64GB ROM Android 12- Green",
                            Price = 63800m,
                            Quantity = 100,
                            StoreId = new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("7bd9dac4-70ba-4ed5-9d7f-c350a79cfa89"),
                            Brand = "Vivo",
                            CategoryId = new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9150),
                            Description = "The display size is 6.51 inches and the screen type is an IPS LCD capacitive touchscreen that has 270 PPI density while the resolution of the screen is 720 x 1600 pixels.",
                            Name = "Vivo Y02 6.51\" 2 RAM/32GB ROM Android 12- Cosmic Grey",
                            Price = 67420m,
                            Quantity = 65,
                            StoreId = new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e5e20972-52e7-40b3-a06f-5bae24f8a2bf"),
                            Brand = "Samsung",
                            CategoryId = new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9154),
                            Description = "Samsung Galaxy A04 is a Smartphone manufactured by Samsung. The Samsung Galaxy A04 Android Smartphone has a 6.5-inch display, a 5000-mAh battery, 32GB of storage, and 3 GB of RAM.",
                            Name = "Samsung Galaxy A04 6.5\" 3GB RAM/32GB ROM Android 12 - Green",
                            Price = 71894m,
                            Quantity = 79,
                            StoreId = new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("1d2c1899-c12f-49c0-b0e3-85d0264c989f"),
                            Brand = "Infinix",
                            CategoryId = new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9158),
                            Description = "Infinix Hot 30 Play comes with a 6.86-inch HD+ IPS LCD screen with a refresh rate of 90Hz.",
                            Name = "Infinix Hot 30 Play 8GB RAM/128GB ROM",
                            Price = 93000m,
                            Quantity = 6,
                            StoreId = new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("2940a7c3-9afe-4723-b944-ab1dc06cd11f"),
                            Brand = "Itel",
                            CategoryId = new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9163),
                            Description = "Stronger battery with AI Power Master for longer-lasting entertainment and social experience. Always stay online and connected to the world. ",
                            Name = "Itel P40 6.6″ HD + Waterdrop FullScreen 64GB ROM + 7GB-BLACK",
                            Price = 56500m,
                            Quantity = 25,
                            StoreId = new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("d9364f3f-8330-42f0-aeb7-02eecf6d27f8"),
                            Brand = "Jameson",
                            CategoryId = new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9167),
                            Description = "Jameson Black Barrel is a triple-distilled, twice charred, Irish Whiskey. Charring is an age-old method for invigorating barrels to intensify the taste. ",
                            Name = "Jameson Black Barrel 70cl",
                            Price = 19501m,
                            Quantity = 5,
                            StoreId = new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("2d5623e8-c85b-4e0f-be6e-5c41964726a9"),
                            Brand = "Martell",
                            CategoryId = new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9171),
                            Description = "A sensation of fullness and generosity with notes of ginger and candied fruit, followed by distinctive hints of toasted oak from the Kentucky bourbon casks.",
                            Name = "Martell Cognac Blue Swift 75cl (VSOP)",
                            Price = 41000m,
                            Quantity = 8,
                            StoreId = new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("74b6162f-d64d-4ae7-87b5-eb23b003d95a"),
                            Brand = "Eva",
                            CategoryId = new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9175),
                            Description = "Eva bottled water has been designed to be a perfect complement to everyday moments.",
                            Name = "Eva Water 150cl x12",
                            Price = 1850m,
                            Quantity = 14,
                            StoreId = new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("9a84173c-ef20-46a2-a649-4989730bfc02"),
                            Brand = "Polystar",
                            CategoryId = new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9179),
                            Description = "Better Picture, Bigger Screen",
                            Name = "Polystar 32'' Inches LED TV",
                            Price = 72436m,
                            Quantity = 15,
                            StoreId = new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("0b4dcc71-db12-49f1-8eef-95f2d4731183"),
                            Brand = "Polystar",
                            CategoryId = new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9183),
                            Description = "Polystar Andriod Smart HD 4K TV",
                            Name = "Polystar 65 Inch Andriod Smart 4K",
                            Price = 290000m,
                            Quantity = 14,
                            StoreId = new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("a91231b1-f8b4-4d52-a54c-8bc70d76b34d"),
                            Brand = "Binatone",
                            CategoryId = new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9187),
                            Description = "A unique fan from the Binatone Typhoon Series fans designed for the highest degree of air delivery in a home setting",
                            Name = "Binatone 20 Inches Typhoon Series Stand Fan",
                            Price = 34470m,
                            Quantity = 32,
                            StoreId = new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("02a65d6c-03a7-45b7-813a-6bc2d441aa87"),
                            Brand = "Binatone",
                            CategoryId = new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9199),
                            Description = "This is fan is a onetime investment and is perfect for domestic use.",
                            Name = "Binatone 16 Inches Standing Fan",
                            Price = 19699m,
                            Quantity = 100,
                            StoreId = new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("0ff1feff-f735-44dc-b83b-63d720e34895"),
                            Brand = "Sony Computer Entertainment",
                            CategoryId = new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9203),
                            Description = "5-inch display, Single-chip custom processor, CPU: x86-64 AMD “Jaar”",
                            Name = "Sony Computer Entertainment PlayStation 4 Console 500gb",
                            Price = 155000m,
                            Quantity = 23,
                            StoreId = new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("c696df54-d6d8-4e77-8c6c-babf265e44ef"),
                            Brand = "Sony Computer Entertainment",
                            CategoryId = new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9208),
                            Description = "",
                            Name = "Sony Computer Entertainment Gran Turismo 5",
                            Price = 2500m,
                            Quantity = 82,
                            StoreId = new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("3b4a05ed-e66c-4014-bb0a-5d8404afd881"),
                            Brand = "Microsoft",
                            CategoryId = new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"),
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(9213),
                            Description = "Introducing the Xbox Series S, the smallest, sleekest Xbox console ever. Experience the speed and performance of a next-yygen all-digital console at an accessible price point.",
                            Name = "Microsoft Xbox Series S Console 512 GB SSD",
                            Price = 340000m,
                            Quantity = 2,
                            StoreId = new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Entities.Models.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stores");

                    b.HasData(
                        new
                        {
                            Id = new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                            Address = "Washington County near Beaverton, Oregon, U.S.",
                            Country = "United States",
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(8862),
                            Email = "media.africa@nike.com",
                            Name = "Nike Inc.",
                            PhoneNumber = "1-800-379-6453",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "www.nike.com"
                        },
                        new
                        {
                            Id = new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                            Address = "Herzogenaurach, Bavaria, Germany.",
                            Country = "Germany",
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(8895),
                            Email = "media.africa@adidas.com",
                            Name = "Adidas AG",
                            PhoneNumber = "+49 9132 84 2352",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "www.adidas.com"
                        },
                        new
                        {
                            Id = new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                            Address = "Herzogenaurach, Bavaria, Germany.",
                            Country = "Germany",
                            CreatedAt = new DateTime(2023, 7, 6, 23, 47, 32, 354, DateTimeKind.Local).AddTicks(8900),
                            Email = "media.africa@puma.com",
                            Name = "Puma SE",
                            PhoneNumber = "+44-800-379-6453",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Url = "us.puma.com"
                        });
                });

            modelBuilder.Entity("Entities.Models.Product", b =>
                {
                    b.HasOne("Entities.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Models.Store", "Store")
                        .WithMany("Products")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Entities.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Entities.Models.Store", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
