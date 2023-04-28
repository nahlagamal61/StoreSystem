﻿namespace StoreSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addproductDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "AddDate", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "AddDate");
        }
    }
}
