namespace Instaclone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
