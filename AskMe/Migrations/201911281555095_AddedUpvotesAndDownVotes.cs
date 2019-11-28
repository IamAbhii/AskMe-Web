namespace AskMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUpvotesAndDownVotes : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Votes", newName: "DownVotes");
            CreateTable(
                "dbo.UpVotes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VotedDateTime = c.DateTime(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserId)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.UpVotes", new[] { "PostId" });
            DropIndex("dbo.UpVotes", new[] { "UserId" });
            DropTable("dbo.UpVotes");
            RenameTable(name: "dbo.DownVotes", newName: "Votes");
        }
    }
}
