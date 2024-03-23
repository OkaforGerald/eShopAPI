using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configurations;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CartItem>()
                .HasKey(ci => new {ci.CartId, ci.ProductId});

            modelBuilder.Entity<OrderProducts>()
                .HasKey(ci => new { ci.OrderId, ci.ProductId });

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(c => c.CartId);

            modelBuilder.Entity<OrderProducts>()
                .HasOne(ci => ci.Order)
                .WithMany(c => c.OrderProducts)
                .HasForeignKey(c => c.OrderId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany(c => c.CartItems)
                .HasForeignKey(c => c.ProductId);

            modelBuilder.Entity<OrderProducts>()
               .HasOne(ci => ci.Product)
               .WithMany(c => c.OrderProducts)
               .HasForeignKey(c => c.ProductId);

            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Store>? Stores { get; set; }

        public DbSet<Product>? Products { get; set; }

        public DbSet<Category>? Categories { get; set; }

        public DbSet<Cart>? Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProducts> OrdersProducts { get; set;}

        public DbSet<RatingAndReview> RatingAndReviews { get; set; }
    }
}
