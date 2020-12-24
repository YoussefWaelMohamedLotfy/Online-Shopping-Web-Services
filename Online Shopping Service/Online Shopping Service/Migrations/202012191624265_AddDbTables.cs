namespace Online_Shopping_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDbTables : DbMigration
    {
        public override void Up()
        {
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
            
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemID = c.Int(nullable: false),
                        UserEmail = c.String(),
                        Count = c.Int(nullable: false),
                        IsCheckedOut = c.Boolean(nullable: false),
                        CartID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("dbo.OrderCarts", t => t.CartID, cascadeDelete: true)
                .Index(t => t.ItemID)
                .Index(t => t.CartID);
            
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
                        CartID = c.Int(nullable: false, identity: true),
                        Total = c.Int(nullable: false),
                        PaymentMethod = c.String(),
                        UserEmail = c.String(),
                        IsCheckedOut = c.Boolean(nullable: false),
                        PurchaseDate = c.DateTime(),
                        ArrivalDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.CartID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "CartID", "dbo.OrderCarts");
            DropForeignKey("dbo.CartItems", "ItemID", "dbo.Items");
            DropIndex("dbo.CartItems", new[] { "CartID" });
            DropIndex("dbo.CartItems", new[] { "ItemID" });
            DropTable("dbo.OrderCarts");
            DropTable("dbo.Items");
            DropTable("dbo.CartItems");
            DropTable("dbo.Cards");
        }
    }
}
