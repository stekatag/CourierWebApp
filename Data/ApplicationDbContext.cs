using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CourierWebApp.Models;
using Microsoft.AspNetCore.Identity;

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

            // Demo user account
            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser()
                {
                    Id = ADMIN_ID,
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin123#"),
                    SecurityStamp = Guid.NewGuid().ToString()
                });

            // Set up composite key
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
        public DbSet<DeliveryItem> DeliveryItem { get; set; }
    }
}
