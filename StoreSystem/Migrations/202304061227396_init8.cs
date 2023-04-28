namespace StoreSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExchangePermits", "PermitNumber", c => c.String());
            AddColumn("dbo.ExchangePermits", "PermitDate", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.ExchangePermits", "ExchangeNumber");
            DropColumn("dbo.ExchangePermits", "ExchangeDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ExchangePermits", "ExchangeDate", c => c.DateTime(nullable: false, storeType: "date"));
            AddColumn("dbo.ExchangePermits", "ExchangeNumber", c => c.String());
            DropColumn("dbo.ExchangePermits", "PermitDate");
            DropColumn("dbo.ExchangePermits", "PermitNumber");
        }
    }
}
