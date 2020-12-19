namespace Online_Shopping_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartIdToCartItemTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "CartID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartItems", "CartID");
        }
    }
}
