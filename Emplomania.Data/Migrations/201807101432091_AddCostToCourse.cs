namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCostToCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Cost", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Cost");
        }
    }
}
