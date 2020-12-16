namespace Online_Shopping_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedTables : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Cards VALUES ('1234567890123456', 'Ahmed', 149, 1586)");
            Sql("INSERT INTO Cards VALUES ('4865137948320346', 'Mohamed', 486, 2168)");
            Sql("INSERT INTO Cards VALUES ('8465462421206484', 'Khaled', 314, 345)");
            Sql("INSERT INTO Cards VALUES ('7651324849871231', 'Hana', 549, 126)");
        }
        
        public override void Down()
        {
        }
    }
}
