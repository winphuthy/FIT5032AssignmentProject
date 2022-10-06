namespace FIT5032AssignmentProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTherapist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Therapists",
                c => new
                    {
                        TherapistID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Dob = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TherapistID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Therapists");
        }
    }
}
