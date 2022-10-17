namespace FIT5032AssignmentProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRequrieduserIdforTesting : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "userId", c => c.String());
            AlterColumn("dbo.Patients", "userId", c => c.String());
            AlterColumn("dbo.Therapists", "userId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Therapists", "userId", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "userId", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "userId", c => c.String(nullable: false));
        }
    }
}
