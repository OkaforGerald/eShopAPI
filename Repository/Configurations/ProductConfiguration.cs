using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                    new Product
                    {
                        Id = new Guid("f28f89c7-8886-481c-972d-10bcbe69749c"),
                        Name = "Infinix Smart 7 Plus 3GB RAM/64GB ROM Android 12- Green",
                        Description = "6.6” Waterdrop Sunlight Fullscreen Crispy-smooth Colors Even Under the Sun 6.6” HD+ Resolution 500nits Peak Brightness Smart 7 PLUS is outfitted with a bright 6.6-inch HD+ screen that boasts 500 nits of peak brightness, delivering a pleasing visual experience whether it’s outdoors or in sunny weather. ",
                        Brand = "Infinix",
                        Price = 63800,
                        Quantity = 100,
                        CategoryId = new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                        StoreId = new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                    },
                    new Product
                    {
                        Id = new Guid("7bd9dac4-70ba-4ed5-9d7f-c350a79cfa89"),
                        Name = "Vivo Y02 6.51\" 2 RAM/32GB ROM Android 12- Cosmic Grey",
                        Description = "The display size is 6.51 inches and the screen type is an IPS LCD capacitive touchscreen that has 270 PPI density while the resolution of the screen is 720 x 1600 pixels.",
                        Brand = "Vivo",
                        Price = 67420,
                        Quantity = 65,
                        CategoryId = new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                        StoreId = new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                    },
                    new Product
                    {
                        Id = new Guid("e5e20972-52e7-40b3-a06f-5bae24f8a2bf"),
                        Name = "Samsung Galaxy A04 6.5\" 3GB RAM/32GB ROM Android 12 - Green",
                        Description = "Samsung Galaxy A04 is a Smartphone manufactured by Samsung. The Samsung Galaxy A04 Android Smartphone has a 6.5-inch display, a 5000-mAh battery, 32GB of storage, and 3 GB of RAM.",
                        Brand = "Samsung",
                        Price = 71894,
                        Quantity = 79,
                        CategoryId = new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                        StoreId = new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                    },
                    new Product
                    {
                        Id = new Guid("1d2c1899-c12f-49c0-b0e3-85d0264c989f"),
                        Name = "Infinix Hot 30 Play 8GB RAM/128GB ROM",
                        Description = "Infinix Hot 30 Play comes with a 6.86-inch HD+ IPS LCD screen with a refresh rate of 90Hz.",
                        Brand = "Infinix",
                        Price = 93000,
                        Quantity = 6,
                        CategoryId = new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                        StoreId = new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                    },
                    new Product
                    {
                        Id = new Guid("2940a7c3-9afe-4723-b944-ab1dc06cd11f"),
                        Name = "Itel P40 6.6″ HD + Waterdrop FullScreen 64GB ROM + 7GB-BLACK",
                        Description = "Stronger battery with AI Power Master for longer-lasting entertainment and social experience. Always stay online and connected to the world. ",
                        Brand = "Itel",
                        Price = 56500,
                        Quantity = 25,
                        CategoryId = new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                        StoreId = new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                    },
                    new Product
                    {
                        Id = new Guid("d9364f3f-8330-42f0-aeb7-02eecf6d27f8"),
                        Name = "Jameson Black Barrel 70cl",
                        Description = "Jameson Black Barrel is a triple-distilled, twice charred, Irish Whiskey. Charring is an age-old method for invigorating barrels to intensify the taste. ",
                        Brand = "Jameson",
                        Price = 19501,
                        Quantity = 5,
                        CategoryId = new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"),
                        StoreId = new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                    },
                     new Product
                     {
                         Id = new Guid("2d5623e8-c85b-4e0f-be6e-5c41964726a9"),
                         Name = "Martell Cognac Blue Swift 75cl (VSOP)",
                         Description = "A sensation of fullness and generosity with notes of ginger and candied fruit, followed by distinctive hints of toasted oak from the Kentucky bourbon casks.",
                         Brand = "Martell",
                         Price = 41000,
                         Quantity = 8,
                         CategoryId = new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"),
                         StoreId = new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                     },
                      new Product
                      {
                          Id = new Guid("74b6162f-d64d-4ae7-87b5-eb23b003d95a"),
                          Name = "Eva Water 150cl x12",
                          Description = "Eva bottled water has been designed to be a perfect complement to everyday moments.",
                          Brand = "Eva",
                          Price = 1850,
                          Quantity = 14,
                          CategoryId = new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"),
                          StoreId = new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                      },
                       new Product
                       {
                           Id = new Guid("9a84173c-ef20-46a2-a649-4989730bfc02"),
                           Name = "Polystar 32'' Inches LED TV",
                           Description = "Better Picture, Bigger Screen",
                           Brand = "Polystar",
                           Price = 72436,
                           Quantity = 15,
                           CategoryId = new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                           StoreId = new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                       },
                        new Product
                        {
                            Id = new Guid("0b4dcc71-db12-49f1-8eef-95f2d4731183"),
                            Name = "Polystar 65 Inch Andriod Smart 4K",
                            Description = "Polystar Andriod Smart HD 4K TV",
                            Brand = "Polystar",
                            Price = 290000,
                            Quantity = 14,
                            CategoryId = new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                            StoreId = new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                        },
                         new Product
                         {
                             Id = new Guid("a91231b1-f8b4-4d52-a54c-8bc70d76b34d"),
                             Name = "Binatone 20 Inches Typhoon Series Stand Fan",
                             Description = "A unique fan from the Binatone Typhoon Series fans designed for the highest degree of air delivery in a home setting",
                             Brand = "Binatone",
                             Price = 34470,
                             Quantity = 32,
                             CategoryId = new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                             StoreId = new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                         }, 
                         new Product
                         {
                             Id = new Guid("02a65d6c-03a7-45b7-813a-6bc2d441aa87"),
                             Name = "Binatone 16 Inches Standing Fan",
                             Description = "This is fan is a onetime investment and is perfect for domestic use.",
                             Brand = "Binatone",
                             Price = 19699,
                             Quantity = 100,
                             CategoryId = new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                             StoreId = new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                         }, 
                         new Product
                         {
                             Id = new Guid("0ff1feff-f735-44dc-b83b-63d720e34895"),
                             Name = "Sony Computer Entertainment PlayStation 4 Console 500gb",
                             Description = "5-inch display, Single-chip custom processor, CPU: x86-64 AMD “Jaar”",
                             Brand = "Sony Computer Entertainment",
                             Price = 155000,
                             Quantity = 23,
                             CategoryId = new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"),
                             StoreId = new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                         }, 
                         new Product
                         {
                             Id = new Guid("c696df54-d6d8-4e77-8c6c-babf265e44ef"),
                             Name = "Sony Computer Entertainment Gran Turismo 5",
                             Description = "",
                             Brand = "Sony Computer Entertainment",
                             Price = 2500,
                             Quantity = 82,
                             CategoryId = new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"),
                             StoreId = new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                         },
                         new Product
                         {
                             Id = new Guid("3b4a05ed-e66c-4014-bb0a-5d8404afd881"),
                             Name = "Microsoft Xbox Series S Console 512 GB SSD",
                             Description = "Introducing the Xbox Series S, the smallest, sleekest Xbox console ever. Experience the speed and performance of a next-yygen all-digital console at an accessible price point.",
                             Brand = "Microsoft",
                             Price = 340000,
                             Quantity = 2,
                             CategoryId = new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"),
                             StoreId = new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                         }
                );
        }
    }
}
