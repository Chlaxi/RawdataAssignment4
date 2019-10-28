using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assignment4
{
    public class NorthwindContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "host=localhost;db=Northwind;uid=postgres;pwd=Arazeena");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Orders
            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(m => m.Id).HasColumnName("orderid");
            modelBuilder.Entity<Order>().Property(m => m.Date).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(m => m.Required).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(m => m.Shipped).HasColumnName("shippeddate");
            modelBuilder.Entity<Order>().Property(m => m.Freight).HasColumnName("freight");
            modelBuilder.Entity<Order>().Property(m => m.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(m => m.ShipCity).HasColumnName("shipcity");


            //Order Details
            modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
            modelBuilder.Entity<OrderDetails>().Property(m => m.OrderId).HasColumnName("orderid");
            modelBuilder.Entity<OrderDetails>().Property(m => m.ProductId).HasColumnName("productid");
            modelBuilder.Entity<OrderDetails>().Property(m => m.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<OrderDetails>().Property(m => m.Quantity).HasColumnName("quantity");
            modelBuilder.Entity<OrderDetails>().Property(m => m.Discount).HasColumnName("discount");
            modelBuilder.Entity<OrderDetails>().HasKey(m => m.OrderId);
            modelBuilder.Entity<OrderDetails>().HasKey(m => m.ProductId);

            //Categories
            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(m => m.Id).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(m => m.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(m => m.Description).HasColumnName("description");

            //Products
            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(m => m.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(m => m.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(m => m.ProductName).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(m => m.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Product>().Property(m => m.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(m => m.UnitsInStock).HasColumnName("unitsinstock");
            modelBuilder.Entity<Product>().HasKey(m => m.Id);
        }
    }
}