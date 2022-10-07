namespace FIT5032AssignmentProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addService : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TherapistId = c.Int(nullable: false),
                        Description = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Therapists", t => t.TherapistId, cascadeDelete: true)
                .Index(t => t.TherapistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "TherapistId", "dbo.Therapists");
            DropIndex("dbo.Services", new[] { "TherapistId" });
            DropTable("dbo.Services");
        }
    }
}
