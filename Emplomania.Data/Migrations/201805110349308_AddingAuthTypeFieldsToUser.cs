namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAuthTypeFieldsToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "AuthenticationType", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "HowKnowEmplomania", c => c.String());
            AddColumn("dbo.Users", "InvitationConfirmCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "InvitationConfirmCode");
            DropColumn("dbo.Users", "HowKnowEmplomania");
            DropColumn("dbo.Users", "AuthenticationType");
        }
    }
}
