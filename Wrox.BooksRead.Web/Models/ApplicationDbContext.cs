using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Wrox.BooksRead.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Categorie { get; set; }

        //public System.Data.Entity.DbSet<Wrox.BooksRead.Web.Models.ProductViewModel> ProductViewModels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            //modelBuilder.Entity<ApplicationUser>()
            //    .HasMany(u => u.Followers)
            //    .WithRequired(f => f.Followee)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<ApplicationUser>()
            //    .HasMany(u => u.Followees)
            //    .WithRequired(f => f.Follower)
            //    .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}