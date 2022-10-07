namespace FIT5032AssignmentProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rebuildOrderRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "RatingId", "dbo.OrderRatings");
            DropIndex("dbo.Orders", new[] { "RatingId" });
            DropColumn("dbo.Orders", "RatingId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "RatingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "RatingId");
            AddForeignKey("dbo.Orders", "RatingId", "dbo.OrderRatings", "Id", cascadeDelete: true);
        }
    }
}
