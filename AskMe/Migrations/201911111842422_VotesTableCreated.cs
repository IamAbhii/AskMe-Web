namespace AskMe.Migrations
{
  using System.Data.Entity.Migrations;

  public partial class VotesTableCreated : DbMigration
  {
    public override void Up()
    {
      CreateTable(
          "dbo.Votes",
          c => new
          {
            Id = c.Int(nullable: false, identity: true),
            VotedDateTime = c.DateTime(nullable: false),
            UserId = c.String(nullable: false, maxLength: 128),
            PostId = c.Int(nullable: false),
          })
          .PrimaryKey(t => t.Id)
          .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
          .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: false)//changed from true to false for avoiding cycle in cascade delete path
          .Index(t => t.UserId)
          .Index(t => t.PostId);

    }

    public override void Down()
    {
      DropForeignKey("dbo.Votes", "UserId", "dbo.AspNetUsers");
      DropForeignKey("dbo.Votes", "PostId", "dbo.Posts");
      DropIndex("dbo.Votes", new[] { "PostId" });
      DropIndex("dbo.Votes", new[] { "UserId" });
      DropTable("dbo.Votes");
    }
  }
}
