namespace FIT5032AssignmentProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPatient : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Dob = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PatientID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
        }
    }
}
