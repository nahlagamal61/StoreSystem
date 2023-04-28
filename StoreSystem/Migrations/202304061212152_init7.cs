﻿namespace StoreSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UnitOfMeasurement", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "UnitOfMeasurement");
        }
    }
}
