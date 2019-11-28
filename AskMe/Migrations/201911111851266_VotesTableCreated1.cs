namespace AskMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VotesTableCreated1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagQuestions",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Question_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Question_PostId })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_PostId, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Question_PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagQuestions", "Question_PostId", "dbo.Questions");
            DropForeignKey("dbo.TagQuestions", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagQuestions", new[] { "Question_PostId" });
            DropIndex("dbo.TagQuestions", new[] { "Tag_Id" });
            DropTable("dbo.TagQuestions");
            DropTable("dbo.Tags");
        }
    }
}
