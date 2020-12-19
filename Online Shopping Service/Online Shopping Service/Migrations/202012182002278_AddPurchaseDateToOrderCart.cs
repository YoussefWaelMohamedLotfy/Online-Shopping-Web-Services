namespace Online_Shopping_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPurchaseDateToOrderCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderCarts", "PurchaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderCarts", "PurchaseDate");
        }
    }
}
