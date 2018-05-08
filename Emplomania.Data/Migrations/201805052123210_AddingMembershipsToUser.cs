namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMembershipsToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Memberships", "UserType", c => c.Int(nullable: false));
            AddColumn("dbo.Memberships", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "MembershipFK", c => c.Guid());
            CreateIndex("dbo.Users", "MembershipFK");
            AddForeignKey("dbo.Users", "MembershipFK", "dbo.Memberships", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "MembershipFK", "dbo.Memberships");
            DropIndex("dbo.Users", new[] { "MembershipFK" });
            DropColumn("dbo.Users", "MembershipFK");
            DropColumn("dbo.Memberships", "Price");
            DropColumn("dbo.Memberships", "UserType");
        }
    }
}
