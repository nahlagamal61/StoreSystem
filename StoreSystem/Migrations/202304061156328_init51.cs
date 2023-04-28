namespace StoreSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init51 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "StoreId", "dbo.Stores");
            DropIndex("dbo.Customers", new[] { "StoreId" });
            DropColumn("dbo.Customers", "StoreId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "StoreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "StoreId");
            AddForeignKey("dbo.Customers", "StoreId", "dbo.Stores", "Id", cascadeDelete: true);
        }
    }
}
