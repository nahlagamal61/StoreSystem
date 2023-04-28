namespace StoreSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Phone", c => c.String());
            AddColumn("dbo.Customers", "Mobile", c => c.String());
            AddColumn("dbo.Suppliers", "Phone", c => c.String());
            AddColumn("dbo.Suppliers", "Mobile", c => c.String());
            DropColumn("dbo.Customers", "Telephone");
            DropColumn("dbo.Customers", "Moblie");
            DropColumn("dbo.Suppliers", "Telephone");
            DropColumn("dbo.Suppliers", "Moblie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "Moblie", c => c.String());
            AddColumn("dbo.Suppliers", "Telephone", c => c.String());
            AddColumn("dbo.Customers", "Moblie", c => c.String());
            AddColumn("dbo.Customers", "Telephone", c => c.String());
            DropColumn("dbo.Suppliers", "Mobile");
            DropColumn("dbo.Suppliers", "Phone");
            DropColumn("dbo.Customers", "Mobile");
            DropColumn("dbo.Customers", "Phone");
        }
    }
}
