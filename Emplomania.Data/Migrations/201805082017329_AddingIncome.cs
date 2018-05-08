namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingIncome : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Income",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientType = c.Int(nullable: false),
                        ClientCategory = c.Int(nullable: false),
                        IncomeType = c.Int(nullable: false),
                        IncomeDate = c.DateTime(),
                        MoneyCountCUC = c.Int(nullable: false),
                        Return = c.Int(nullable: false),
                        MembershipFK = c.Guid(),
                        AditionalServiceFK = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AditionalServices", t => t.AditionalServiceFK)
                .ForeignKey("dbo.Memberships", t => t.MembershipFK)
                .Index(t => t.MembershipFK)
                .Index(t => t.AditionalServiceFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Income", "MembershipFK", "dbo.Memberships");
            DropForeignKey("dbo.Income", "AditionalServiceFK", "dbo.AditionalServices");
            DropIndex("dbo.Income", new[] { "AditionalServiceFK" });
            DropIndex("dbo.Income", new[] { "MembershipFK" });
            DropTable("dbo.Income");
        }
    }
}
