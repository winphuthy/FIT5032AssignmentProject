namespace FIT5032AssignmentProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrderRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderRatings", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderRatings", "OrderId");
            AddForeignKey("dbo.OrderRatings", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderRatings", "OrderId", "dbo.Orders");
            DropIndex("dbo.OrderRatings", new[] { "OrderId" });
            DropColumn("dbo.OrderRatings", "OrderId");
        }
    }
}
