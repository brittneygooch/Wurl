namespace Wurl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class superduperCOmmit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Replies", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Replies", new[] { "UserId" });
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        SenderId = c.String(maxLength: 128),
                        PostId = c.String(),
                        Title = c.String(),
                        Body = c.String(),
                        UserId = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateEdited = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .Index(t => t.SenderId);
            
            AddColumn("dbo.Posts", "EventId", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "RespondedTo", c => c.Int(nullable: false));
            DropTable("dbo.Replies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        UserId = c.String(maxLength: 128),
                        PostId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateEdited = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId);
            
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropColumn("dbo.Posts", "RespondedTo");
            DropColumn("dbo.Posts", "EventId");
            DropTable("dbo.Messages");
            CreateIndex("dbo.Replies", "UserId");
            AddForeignKey("dbo.Replies", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
