using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Instaclone.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Follow> Follows { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Follow>()
                .HasRequired(f => f.Followee)
                .WithMany(u => u.Followers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Follow>()
                .HasRequired(f => f.Follower)
                .WithMany(u => u.Followees)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}