namespace Online_Shopping_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeIdInCartItemTableIdentity : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CartItems", new[] { "ID" });
            DropPrimaryKey("dbo.CartItems");
            AlterColumn("dbo.CartItems", "ID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CartItems", "ID");
            CreateIndex("dbo.CartItems", "ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CartItems", new[] { "ID" });
            DropPrimaryKey("dbo.CartItems");
            AlterColumn("dbo.CartItems", "ID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.CartItems", "ID");
            CreateIndex("dbo.CartItems", "ID");
        }
    }
}
