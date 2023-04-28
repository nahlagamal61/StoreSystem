namespace StoreSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransferItems", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.TransferItems", "ProductId");
            AddForeignKey("dbo.TransferItems", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransferItems", "ProductId", "dbo.Products");
            DropIndex("dbo.TransferItems", new[] { "ProductId" });
            DropColumn("dbo.TransferItems", "ProductId");
        }
    }
}
