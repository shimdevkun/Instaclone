namespace Instaclone.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Instaclone.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Instaclone.Models.ApplicationDbContext";
        }

        protected override void Seed(Instaclone.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //var passwordHasher = new PasswordHasher();

            //var users = new List<ApplicationUser>
            //{
            //    new ApplicationUser
            //    {
            //        Name = "Jack",
            //        UserName = "jack@domain.com",
            //        Email = "jack@domain.com",
            //        PasswordHash = passwordHasher.HashPassword("Jack1_domain")
            //    },
            //    new ApplicationUser
            //    {
            //        Name = "Mike",
            //        UserName = "mike@domain.com",
            //        Email = "mike@domain.com",
            //        PasswordHash = passwordHasher.HashPassword("Mike1_domain")
            //    },
            //    new ApplicationUser
            //    {
            //        Name = "Alice",
            //        UserName = "alice@domain.com",
            //        Email = "alice@domain.com",
            //        PasswordHash = passwordHasher.HashPassword("Alice1_domain")
            //    },
            //};

            //users.ForEach(u => context.Users.AddOrUpdate(x => x.UserName, u));

            //var posts = new List<Post>
            //{
            // throws not valid url but works through UI???
            //new Post
            //{
            //    UserId = context.Users.Single(u => u.Name == "Jack").Id,
            //    ImageSrc = "https://source.unsplash.com/eCktzGjC-iU",
            //    Description = "Playing with the boys",
            //    DateTime = new DateTime(2020, 06, 25)
            //},
            //new Post
            //{
            //    UserId = context.Users.Single(u => u.Name == "Jack").Id,
            //    ImageSrc = "https://source.unsplash.com/fzOITuS1DIQ",
            //    Description = "Strategy requires thought, tactics require observation",
            //    DateTime = new DateTime(2020, 07, 10)
            //}
            //,new Post
            //{
            //    UserId = context.Users.Single(u => u.Name == "Jack").Id,
            //    ImageSrc = "https://source.unsplash.com/3mWxKnqET3E",
            //    Description = "New lights for my pc setup ;p",
            //    DateTime = new DateTime(2020, 07, 23)
            //},
            //new Post
            //{
            //    UserId = context.Users.Single(u => u.Name == "Mike").Id,
            //    ImageSrc = "https://source.unsplash.com/OBufvGMaBaQ",
            //    Description = "Just walking by...",
            //    DateTime = new DateTime(2020, 07, 15)
            //},
            //new Post
            //{
            //    UserId = context.Users.Single(u => u.Name == "Mike").Id,
            //    ImageSrc = "https://source.unsplash.com/0woyPEJQ7jc",
            //    Description = "Have a game to unwind the day.",
            //    DateTime = new DateTime(2020, 08, 07)
            //},
            //new Post
            //{
            //    UserId = context.Users.Single(u => u.Name == "Alice").Id,
            //    ImageSrc = "https://source.unsplash.com/ruujV5lGSIw",
            //    Description = "Taking a little break :3",
            //    DateTime = new DateTime(2020, 08, 03)
            //},
            //new Post
            //{
            //    UserId = context.Users.Single(u => u.Name == "Alice").Id,
            //    ImageSrc = "https://source.unsplash.com/8jqna7aA-vs",
            //    Description = "Life is like riding a bicycle. To keep your balance you must keep moving",
            //    DateTime = new DateTime(2020, 08, 03)
            //}
            //};

            //context.Posts.AddRange(posts);

            //SaveChanges(context);
        }

        //private void SaveChanges(DbContext context)
        //{
        //    try
        //    {
        //        context.SaveChanges();
        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        StringBuilder sb = new StringBuilder();

        //        foreach (var failure in ex.EntityValidationErrors)
        //        {
        //            sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
        //            foreach (var error in failure.ValidationErrors)
        //            {
        //                sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
        //                sb.AppendLine();
        //            }
        //        }

        //        throw new DbEntityValidationException(
        //            "Entity Validation Failed - errors follow:\n" +
        //            sb.ToString(), ex
        //        ); // Add the original exception as the innerException
        //    }
        //}
    }
}
