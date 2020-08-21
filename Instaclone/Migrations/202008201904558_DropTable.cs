namespace Instaclone.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddFollow : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.Follows",
                    c => new
                    {
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                        FollowerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FolloweeId, t.FollowerId })
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId, cascadeDelete: true)
                .Index(t => t.FolloweeId)
                .Index(t => t.FollowerId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "FollowerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "FolloweeId", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "FollowerId" });
            DropIndex("dbo.Follows", new[] { "FolloweeId" });
            DropTable("dbo.Follows");
        }
    }
}
