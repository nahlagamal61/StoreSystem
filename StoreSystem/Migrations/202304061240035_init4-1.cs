namespace StoreSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init41 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TransferItems", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.TransferItems", new[] { "SupplierId" });
            DropColumn("dbo.TransferItems", "SupplierId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransferItems", "SupplierId", c => c.Int(nullable: false));
            CreateIndex("dbo.TransferItems", "SupplierId");
            AddForeignKey("dbo.TransferItems", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
        }
    }
}
