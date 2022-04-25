using Microsoft.EntityFrameworkCore;
using Ophelia.Entities.POCOEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ophelia.Repositories.EFCore.DataContext
{
    public class OpheliaContext: DbContext
    {
        
        public OpheliaContext(DbContextOptions<OpheliaContext> options) :
            base(options){ } 
           
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(c => c.Id)
                .HasMaxLength(12);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Customer>()
                .Property(c => c.BirthDate)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Product>()
                .Property(p => p.UnitPrice)
                .IsRequired()
                .HasDefaultValue(0);

            modelBuilder.Entity<Product>()
               .Property(p => p.Stock)
               .IsRequired()
               .HasDefaultValue(0);

            modelBuilder.Entity<Order>()
               .Property(o => o.CustomerId)
               .HasMaxLength(12)
               .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderDate)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .Property(o => o.ShipAddress)
                .HasMaxLength(300)
                .IsRequired();

            modelBuilder.Entity<OrderDetail>()
                .HasKey(od => new { od.OrderId, od.ProductId });

            modelBuilder.Entity<Order>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<OrderDetail>()
               .HasOne<Order>()
               .WithMany()
               .HasForeignKey(od => od.OrderId);

            modelBuilder.Entity<OrderDetail>()
               .HasOne<Product>()
               .WithMany()
               .HasForeignKey(od => od.ProductId);
        }
    }
}
