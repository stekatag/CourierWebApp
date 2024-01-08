using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CourierWebApp.Models;

namespace CourierWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<DeliveryItem>()
            //    .HasKey(di => new { di.DeliveryId, di.ItemId });
            modelBuilder.Entity<DeliveryItem>()
                        .HasOne(di => di.Delivery)
                        .WithMany(d => d.DeliveryItems)
                        .HasForeignKey(di => di.DeliveryId)
                        .OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<Units> Unit { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<CourierWebApp.Models.DeliveryItem> DeliveryItem { get; set; }
    }
}
