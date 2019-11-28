namespace AskMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTitlePropertyInPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Title");
        }
    }
}
