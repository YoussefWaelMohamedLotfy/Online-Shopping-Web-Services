namespace Online_Shopping_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesToDb : DbMigration
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
                        ID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OrderCarts", t => t.ItemID, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.OrderCarts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Total = c.Int(nullable: false),
                        PaymentMethod = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "ID", "dbo.Items");
            DropForeignKey("dbo.CartItems", "ItemID", "dbo.OrderCarts");
            DropIndex("dbo.CartItems", new[] { "ItemID" });
            DropIndex("dbo.CartItems", new[] { "ID" });
            DropTable("dbo.Items");
            DropTable("dbo.OrderCarts");
            DropTable("dbo.CartItems");
            DropTable("dbo.Cards");
        }
    }
}
