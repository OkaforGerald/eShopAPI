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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                    new Category
                    {
                        Id = new Guid("cd1d6922-19de-4fe9-87d1-9ac4988d0c9c"),
                        Name = "Phone & Tablets"
                    },
                    new Category
                    {
                        Id = new Guid("771cbbbb-52dc-49d1-90e3-d9b42c27eae1"),
                        Name = "Gaming"
                    },
                     new Category
                     {
                         Id = new Guid("28781549-ee77-4214-a7fd-1069b83ee02a"),
                         Name = "Drinks"
                     },
                      new Category
                      {
                          Id = new Guid("6f4d6e11-5f8c-464f-91a0-824ee2e31c49"),
                          Name = "Appliances"
                      }
                );
        }
    }
}
