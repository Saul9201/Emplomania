namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCupponToIncomeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Income", "MoneyCountCredCupponCUC", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Income", "MoneyCountCredCupponCUC");
        }
    }
}
