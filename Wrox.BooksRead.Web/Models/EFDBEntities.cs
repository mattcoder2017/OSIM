namespace Wrox.BooksRead.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFDBEntities : DbContext, IEFDBEntities
    {
        public EFDBEntities()
            : base("name=EFDBEntities")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductNotification> ProductNotifications { get; set; }
        public virtual DbSet<ProductUserSubscription> ProductUserSubscriptions { get; set; }
        public virtual DbSet<UserProductNotification> UserProductNotifications { get; set; }
        public virtual DbSet<ProductSubscription> ProductSubscriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.ProductSubscriptions)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.ProductUserSubscriptions)
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
                .HasMany(e => e.UserProductNotifications)
                .WithRequired(e => e.ProductNotification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>().Ignore(i => i.PriceIsChanged);

            base.OnModelCreating(modelBuilder);
        }
    }

    public partial class ReadEFDBEntities : DbContext, IEFDBEntities
    {
        public ReadEFDBEntities()
            : base("name=EFDBEntities")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductNotification> ProductNotifications { get; set; }
        public virtual DbSet<ProductUserSubscription> ProductUserSubscriptions { get; set; }
        public virtual DbSet<UserProductNotification> UserProductNotifications { get; set; }
        public virtual DbSet<ProductSubscription> ProductSubscriptions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.ProductSubscriptions)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.ProductUserSubscriptions)
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
                .HasMany(e => e.UserProductNotifications)
                .WithRequired(e => e.ProductNotification)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>().Ignore(i => i.PriceIsChanged);
            base.OnModelCreating(modelBuilder);
        }
    }
}