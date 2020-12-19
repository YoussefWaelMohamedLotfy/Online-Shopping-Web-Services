namespace Online_Shopping_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserEmailToOrderCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderCarts", "UserEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderCarts", "UserEmail");
        }
    }
}
