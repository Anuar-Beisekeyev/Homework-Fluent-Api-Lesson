using FluentApiLesson.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApiLesson.Data
{
    class DishesContext : DbContext
    {
        public DishesContext()
        {
            Database.Migrate();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public  DbSet<ProductDish> ProductDishes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-3S2N5VP; Database=FluentApiLesson; Trusted_Connection = true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                 .ToTable("products")
                 .Property(product => product.Id)
                 .HasColumnName("ID");

            modelBuilder.Entity<Product>()
                .HasKey(product => product.Id);

            modelBuilder.Entity<Product>()
                .Property(product => product.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();    

            modelBuilder.Entity<Dish>()
                .ToTable("dishes")
                .Property(dish => dish.Id)
                .HasColumnName("ID");

            modelBuilder.Entity<Dish>()
                .HasKey(dish => dish.Id);

            modelBuilder.Entity<Dish>()
                .Property(dish => dish.Name)
                .HasColumnName("name")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<ProductDish>()
                .HasKey(productDish => new { productDish.ProductId, productDish.DishId });

            modelBuilder.Entity<ProductDish>()
               .HasOne(productDish => productDish.Product)
               .WithMany(productDish => productDish.ProductDishes)
               .HasForeignKey(productDish => productDish.ProductId);

            modelBuilder.Entity<ProductDish>()
               .HasOne(productDish => productDish.Dish)
               .WithMany(productDish => productDish.ProductDishes)
               .HasForeignKey(productDish => productDish.DishId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
