namespace Online_Shopping_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToItemModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "AddedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "AddedOn");
        }
    }
}
