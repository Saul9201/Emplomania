namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOffersNeeds : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OffersNeeds",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        WorkplaceFK = c.Guid(),
                        UserFK = c.Guid(),
                        Others = c.String(),
                        Details = c.String(),
                        Discriminator = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserFK)
                .ForeignKey("dbo.Workplaces", t => t.WorkplaceFK)
                .Index(t => t.WorkplaceFK)
                .Index(t => t.UserFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OffersNeeds", "WorkplaceFK", "dbo.Workplaces");
            DropForeignKey("dbo.OffersNeeds", "UserFK", "dbo.Users");
            DropIndex("dbo.OffersNeeds", new[] { "UserFK" });
            DropIndex("dbo.OffersNeeds", new[] { "WorkplaceFK" });
            DropTable("dbo.OffersNeeds");
        }
    }
}
