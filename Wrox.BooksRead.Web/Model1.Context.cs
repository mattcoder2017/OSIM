﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wrox.BooksRead.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EFDBEntities : DbContext, IEFDBEntities
    {
        public EFDBEntities()
            : base("name=EFDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Ignore(t => t.PriceIsChanged);

            //modelBuilder.Entity<AspNetRole>()
            //   .HasMany(e => e.AspNetUsers)
            //   .WithMany(e => e.AspNetRoles)
            //   .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            //modelBuilder.Entity<AspNetUser>()
            //    .HasMany(e => e.AspNetUserClaims)
            //    .WithRequired(e => e.AspNetUser)
            //    .HasForeignKey(e => e.UserId);

            //modelBuilder.Entity<AspNetUser>()
            //    .HasMany(e => e.AspNetUserLogins)
            //    .WithRequired(e => e.AspNetUser)
            //    .HasForeignKey(e => e.UserId);

            //modelBuilder.Entity<AspNetUser>()
            //    .HasMany(e => e.ProductSubscriptions)
            //    .WithRequired(e => e.AspNetUser)
            //    .HasForeignKey(e => e.UserId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<AspNetUser>()
            //    .HasMany(e => e.ProductUserSubscriptions)
            //    .WithRequired(e => e.AspNetUser)
            //    .HasForeignKey(e => e.UserId)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.UserProductNotifiations)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.UserProductNotifications)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithRequired(e => e.Category1)
                .HasForeignKey(e => e.Category)
                .WillCascadeOnDelete(false);

           modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductNotifications)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.ProductSubscriptions)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductNotification>()
                .HasMany(e => e.UserProductNotifiations)
                .WithRequired(e => e.ProductNotification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductNotification>()
                .HasMany(e => e.UserProductNotifications)
                .WithRequired(e => e.ProductNotification)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductNotification> ProductNotifications { get; set; }
        public virtual DbSet<UserProductNotification> UserProductNotifications { get; set; }
        public virtual DbSet<ProductSubscription> ProductSubscriptions { get; set; }
        public virtual DbSet<UserProductNotifiation> UserProductNotifiations { get; set; }
    }
}
