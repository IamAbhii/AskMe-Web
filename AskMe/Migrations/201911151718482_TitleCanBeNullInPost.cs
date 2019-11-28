namespace AskMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TitleCanBeNullInPost : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false));
        }
    }
}
