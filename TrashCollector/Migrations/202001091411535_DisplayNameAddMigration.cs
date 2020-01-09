namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DisplayNameAddMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "lastName", c => c.String());
            DropColumn("dbo.Customers", "lastDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "lastDay", c => c.String());
            DropColumn("dbo.Customers", "lastName");
        }
    }
}
