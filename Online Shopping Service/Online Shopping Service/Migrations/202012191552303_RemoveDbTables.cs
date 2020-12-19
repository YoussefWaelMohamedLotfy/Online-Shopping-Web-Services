namespace Online_Shopping_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDbTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "ItemID", "dbo.OrderCarts");
            DropForeignKey("dbo.CartItems", "ID", "dbo.Items");
            DropIndex("dbo.CartItems", new[] { "ID" });
            DropIndex("dbo.CartItems", new[] { "ItemID" });
            DropTable("dbo.Cards");
            DropTable("dbo.CartItems");
            DropTable("dbo.OrderCarts");
            DropTable("dbo.Items");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Category = c.String(),
                        RemainingCount = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OrderCarts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Total = c.Int(nullable: false),
                        PaymentMethod = c.String(),
                        UserEmail = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        UserEmail = c.String(),
                        Count = c.Int(nullable: false),
                        CartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardNumber = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        CVV = c.Int(nullable: false),
                        CurrentBalance = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CardNumber);
            
            CreateIndex("dbo.CartItems", "ItemID");
            CreateIndex("dbo.CartItems", "ID");
            AddForeignKey("dbo.CartItems", "ID", "dbo.Items", "ID");
            AddForeignKey("dbo.CartItems", "ItemID", "dbo.OrderCarts", "ID", cascadeDelete: true);
        }
    }
}
