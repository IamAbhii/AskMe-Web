namespace AskMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuestionAnswerTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .ForeignKey("dbo.Questions", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Posts", t => t.PostId)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "QuestionId", "dbo.Questions");
            DropForeignKey("dbo.Questions", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Answers", "PostId", "dbo.Posts");
            DropIndex("dbo.Questions", new[] { "PostId" });
            DropIndex("dbo.Answers", new[] { "QuestionId" });
            DropIndex("dbo.Answers", new[] { "PostId" });
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
