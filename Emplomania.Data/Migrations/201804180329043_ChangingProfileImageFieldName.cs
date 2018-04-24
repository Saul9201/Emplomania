namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingProfileImageFieldName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ProfileImageRaw", c => c.Binary());
            DropColumn("dbo.Users", "ProfileImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ProfileImage", c => c.Binary());
            DropColumn("dbo.Users", "ProfileImageRaw");
        }
    }
}
