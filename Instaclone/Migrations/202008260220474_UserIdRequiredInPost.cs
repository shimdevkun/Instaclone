namespace Instaclone.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UserIdRequiredInPost : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "UserId" });
            AlterColumn("dbo.Posts", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Posts", "UserId");
            AddForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "UserId" });
            AlterColumn("dbo.Posts", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "UserId");
            AddForeignKey("dbo.Posts", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
