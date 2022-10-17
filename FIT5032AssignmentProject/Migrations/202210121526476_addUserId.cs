namespace FIT5032AssignmentProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "userId", c => c.String(nullable: false));
            AddColumn("dbo.Patients", "userId", c => c.String(nullable: false));
            AddColumn("dbo.Therapists", "userId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Therapists", "userId");
            DropColumn("dbo.Patients", "userId");
            DropColumn("dbo.Admins", "userId");
        }
    }
}
