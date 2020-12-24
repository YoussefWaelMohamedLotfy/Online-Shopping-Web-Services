namespace Online_Shopping_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTotalDatatypeInOrderCartTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderCarts", "Total", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderCarts", "Total", c => c.Int(nullable: false));
        }
    }
}
