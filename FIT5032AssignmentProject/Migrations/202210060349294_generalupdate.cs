namespace FIT5032AssignmentProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class generalupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Admins", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Patients", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Patients", "LastName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Patients", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Admins", "FirstName", c => c.String(maxLength: 30));
        }
    }
}
