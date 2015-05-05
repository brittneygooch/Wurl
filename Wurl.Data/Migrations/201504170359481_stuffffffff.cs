namespace Wurl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stuffffffff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.Int(nullable: false, identity: true),
                        HostId = c.String(),
                        UserId = c.String(),
                        User = c.String(),
                        IsAttending = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AttendanceId);
            
            AddColumn("dbo.Events", "City", c => c.String());
            AlterColumn("dbo.Events", "Rating", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Rating", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "City");
            DropTable("dbo.Attendances");
        }
    }
}
