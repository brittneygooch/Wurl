namespace Wurl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "SendId", c => c.String());
            DropColumn("dbo.Messages", "SendToId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "SendToId", c => c.String());
            DropColumn("dbo.Messages", "SendId");
        }
    }
}
