namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserFieldToIncomeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Income", "User", c => c.Guid());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Income", "User");
        }
    }
}
