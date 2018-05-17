namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingIncomeDateRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Income", "IncomeDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Income", "IncomeDate", c => c.DateTime());
        }
    }
}
