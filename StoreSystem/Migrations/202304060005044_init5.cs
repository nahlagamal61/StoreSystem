namespace StoreSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Stores", name: "Employee_Id", newName: "ResponsablePerson_Id");
            RenameIndex(table: "dbo.Stores", name: "IX_Employee_Id", newName: "IX_ResponsablePerson_Id");
            CreateTable(
                "dbo.ExchangePermits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        ExchangeNumber = c.String(),
                        ExchangeDate = c.DateTime(nullable: false, storeType: "date"),
                        SupplierId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.ExchangePermitItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExchangePermitId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExchangePermits", t => t.ExchangePermitId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ExchangePermitId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ImportPermits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreId = c.Int(nullable: false),
                        PermitNumber = c.String(),
                        PermitDate = c.DateTime(nullable: false, storeType: "date"),
                        SupplierId = c.Int(nullable: false),
                        ProductionDate = c.DateTime(nullable: false, storeType: "date"),
                        ExpirationDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.StoreId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .Index(t => t.StoreId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.ImportPermitItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImportPermitId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ImportPermits", t => t.ImportPermitId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ImportPermitId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromStoreId = c.Int(nullable: false),
                        ToStoreId = c.Int(nullable: false),
                        TransferDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.FromStoreId, cascadeDelete: true)
                .ForeignKey("dbo.Stores", t => t.ToStoreId)
                .Index(t => t.FromStoreId)
                .Index(t => t.ToStoreId);
            
            CreateTable(
                "dbo.TransferItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransferId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SupplierId = c.Int(nullable: false),
                        ProductionDate = c.DateTime(nullable: false, storeType: "date"),
                        ExpirationDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId, cascadeDelete: true)
                .ForeignKey("dbo.Transfers", t => t.TransferId)
                .Index(t => t.TransferId)
                .Index(t => t.SupplierId);
            
            AddColumn("dbo.Customers", "StoreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "StoreId");
            CreateIndex("dbo.Products", "StoreId");
            AddForeignKey("dbo.Products", "StoreId", "dbo.Stores", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "StoreId", "dbo.Stores", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.Transfers", "ToStoreId", "dbo.Stores");
            DropForeignKey("dbo.TransferItems", "TransferId", "dbo.Transfers");
            DropForeignKey("dbo.TransferItems", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Transfers", "FromStoreId", "dbo.Stores");
            DropForeignKey("dbo.ImportPermits", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.ImportPermits", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.ImportPermitItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ImportPermitItems", "ImportPermitId", "dbo.ImportPermits");
            DropForeignKey("dbo.ExchangePermits", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.ExchangePermits", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.ExchangePermitItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "StoreId", "dbo.Stores");
            DropForeignKey("dbo.ExchangePermitItems", "ExchangePermitId", "dbo.ExchangePermits");
            DropIndex("dbo.TransferItems", new[] { "SupplierId" });
            DropIndex("dbo.TransferItems", new[] { "TransferId" });
            DropIndex("dbo.Transfers", new[] { "ToStoreId" });
            DropIndex("dbo.Transfers", new[] { "FromStoreId" });
            DropIndex("dbo.ImportPermitItems", new[] { "ProductId" });
            DropIndex("dbo.ImportPermitItems", new[] { "ImportPermitId" });
            DropIndex("dbo.ImportPermits", new[] { "SupplierId" });
            DropIndex("dbo.ImportPermits", new[] { "StoreId" });
            DropIndex("dbo.Products", new[] { "StoreId" });
            DropIndex("dbo.ExchangePermitItems", new[] { "ProductId" });
            DropIndex("dbo.ExchangePermitItems", new[] { "ExchangePermitId" });
            DropIndex("dbo.ExchangePermits", new[] { "SupplierId" });
            DropIndex("dbo.ExchangePermits", new[] { "StoreId" });
            DropIndex("dbo.Customers", new[] { "StoreId" });
            DropColumn("dbo.Customers", "StoreId");
            DropTable("dbo.TransferItems");
            DropTable("dbo.Transfers");
            DropTable("dbo.ImportPermitItems");
            DropTable("dbo.ImportPermits");
            DropTable("dbo.ExchangePermitItems");
            DropTable("dbo.ExchangePermits");
            RenameIndex(table: "dbo.Stores", name: "IX_ResponsablePerson_Id", newName: "IX_Employee_Id");
            RenameColumn(table: "dbo.Stores", name: "ResponsablePerson_Id", newName: "Employee_Id");
        }
    }
}
