namespace Wurl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imagesCommit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "ImgUrl");
        }
    }
}
