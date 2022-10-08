namespace FIT5032AssignmentProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Services", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Services", "Address");
        }
    }
}
