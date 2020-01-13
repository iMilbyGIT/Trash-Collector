namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PickupDayEmplMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "pickupDay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "pickupDay");
        }
    }
}
