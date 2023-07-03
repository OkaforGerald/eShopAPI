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
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData(
                new Store
                {
                    Id  = new Guid("971a9744-6e67-4347-bf0f-2265e95ff8ff"),
                    Name = "Nike Inc.",
                    Email = "media.africa@nike.com",
                    PhoneNumber = "1-800-379-6453",
                    Url = "www.nike.com",
                    Address = "Washington County near Beaverton, Oregon, U.S.",
                    Country = "United States",

                },
                 new Store
                 {
                     Id = new Guid("b3e9b76f-afa8-4a75-972b-1efb76d4d4fd"),
                     Name = "Adidas AG",
                     Email = "media.africa@adidas.com",
                     PhoneNumber = "+49 9132 84 2352",
                     Url = "www.adidas.com",
                     Address = "Herzogenaurach, Bavaria, Germany.",
                     Country = "Germany",

                 },
                  new Store
                  {
                      Id = new Guid("966d779e-c693-4abe-bbc3-325ecc71b48d"),
                      Name = "Puma SE",
                      Email = "media.africa@puma.com",
                      PhoneNumber = "+44-800-379-6453",
                      Url = "us.puma.com",
                      Address = "Herzogenaurach, Bavaria, Germany.",
                      Country = "Germany",
                  }
              );
        }
    }
}
