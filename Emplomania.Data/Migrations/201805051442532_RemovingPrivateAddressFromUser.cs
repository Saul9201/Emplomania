namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingPrivateAddressFromUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "PrivateAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PrivateAddress", c => c.String());
        }
    }
}
