namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddZipToEmplMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "zip", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "zip");
        }
    }
}
