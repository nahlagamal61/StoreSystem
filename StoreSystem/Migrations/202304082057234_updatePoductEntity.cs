namespace StoreSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatePoductEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ExpirationDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ExpirationDate");
        }
    }
}
