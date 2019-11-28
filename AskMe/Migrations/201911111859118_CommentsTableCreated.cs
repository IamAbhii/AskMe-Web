namespace AskMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentsTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CommentText = c.String(nullable: false),
                        AnswerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.AnswerId, cascadeDelete: true)
                .Index(t => t.AnswerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "AnswerId", "dbo.Answers");
            DropIndex("dbo.Comments", new[] { "AnswerId" });
            DropTable("dbo.Comments");
        }
    }
}
