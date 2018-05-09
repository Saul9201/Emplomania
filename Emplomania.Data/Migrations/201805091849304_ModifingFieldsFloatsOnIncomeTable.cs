namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifingFieldsFloatsOnIncomeTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Income", "MoneyCountMemberchipCUC", c => c.Single());
            AlterColumn("dbo.Income", "MoneyCountAditionalServCUC", c => c.Single());
            AlterColumn("dbo.Income", "Return", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Income", "Return", c => c.Single(nullable: false));
            AlterColumn("dbo.Income", "MoneyCountAditionalServCUC", c => c.Single(nullable: false));
            AlterColumn("dbo.Income", "MoneyCountMemberchipCUC", c => c.Single(nullable: false));
        }
    }
}
