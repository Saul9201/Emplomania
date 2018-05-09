namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFieldsToIncomeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Income", "MoneyCountMemberchipCUC", c => c.Int(nullable: false));
            AddColumn("dbo.Income", "MoneyCountAditionalServCUC", c => c.Int(nullable: false));
            DropColumn("dbo.Income", "MoneyCountCUC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Income", "MoneyCountCUC", c => c.Int(nullable: false));
            DropColumn("dbo.Income", "MoneyCountAditionalServCUC");
            DropColumn("dbo.Income", "MoneyCountMemberchipCUC");
        }
    }
}
