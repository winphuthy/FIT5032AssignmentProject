namespace FIT5032AssignmentProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "TherapistId", "dbo.Therapists");
            DropIndex("dbo.Orders", new[] { "TherapistId" });
            AddColumn("dbo.Orders", "ServiceId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Comment", c => c.String(maxLength: 300));
            CreateIndex("dbo.Orders", "ServiceId");
            AddForeignKey("dbo.Orders", "ServiceId", "dbo.Services", "Id", cascadeDelete: true);
            DropColumn("dbo.Orders", "TherapistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "TherapistId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "ServiceId", "dbo.Services");
            DropIndex("dbo.Orders", new[] { "ServiceId" });
            DropColumn("dbo.Orders", "Comment");
            DropColumn("dbo.Orders", "ServiceId");
            CreateIndex("dbo.Orders", "TherapistId");
            AddForeignKey("dbo.Orders", "TherapistId", "dbo.Therapists", "TherapistID", cascadeDelete: true);
        }
    }
}
