namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingWebSiteFieldToTeacherTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "WebSite", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "WebSite");
        }
    }
}
