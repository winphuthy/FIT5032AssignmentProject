namespace FIT5032AssignmentProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RatingTime = c.DateTime(nullable: false),
                        Content = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderTime = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                        TherapistId = c.Int(nullable: false),
                        RatingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderRatings", t => t.RatingId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .ForeignKey("dbo.Therapists", t => t.TherapistId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.TherapistId)
                .Index(t => t.RatingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "TherapistId", "dbo.Therapists");
            DropForeignKey("dbo.Orders", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Orders", "RatingId", "dbo.OrderRatings");
            DropIndex("dbo.Orders", new[] { "RatingId" });
            DropIndex("dbo.Orders", new[] { "TherapistId" });
            DropIndex("dbo.Orders", new[] { "PatientId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderRatings");
        }
    }
}
