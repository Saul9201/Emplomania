namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFieldToBusiness : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Business", "Name", c => c.String());
            AddColumn("dbo.Business", "MovilPhoneNumber", c => c.String());
            AddColumn("dbo.Business", "HomePhoneNumber", c => c.String());
            AddColumn("dbo.Business", "Address", c => c.String());
            AddColumn("dbo.Business", "Email", c => c.String());
            AddColumn("dbo.Business", "WebSite", c => c.String());
            AddColumn("dbo.Business", "Details", c => c.String());
            AddColumn("dbo.Business", "CategoryFK", c => c.Guid(nullable: false));
            AddColumn("dbo.Business", "MunicipalityFK", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Business", "MunicipalityFK");
            DropColumn("dbo.Business", "CategoryFK");
            DropColumn("dbo.Business", "Details");
            DropColumn("dbo.Business", "WebSite");
            DropColumn("dbo.Business", "Email");
            DropColumn("dbo.Business", "Address");
            DropColumn("dbo.Business", "HomePhoneNumber");
            DropColumn("dbo.Business", "MovilPhoneNumber");
            DropColumn("dbo.Business", "Name");
        }
    }
}
