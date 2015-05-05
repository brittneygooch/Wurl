namespace Wurl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherCommit : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Messages", name: "SenderId", newName: "Sender_Id");
            RenameIndex(table: "dbo.Messages", name: "IX_SenderId", newName: "IX_Sender_Id");
            AddColumn("dbo.Events", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "SendToId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "SendToId");
            DropColumn("dbo.Events", "Rating");
            RenameIndex(table: "dbo.Messages", name: "IX_Sender_Id", newName: "IX_SenderId");
            RenameColumn(table: "dbo.Messages", name: "Sender_Id", newName: "SenderId");
        }
    }
}
