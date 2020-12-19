namespace Online_Shopping_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserEmailToCartItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "UserEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartItems", "UserEmail");
        }
    }
}
