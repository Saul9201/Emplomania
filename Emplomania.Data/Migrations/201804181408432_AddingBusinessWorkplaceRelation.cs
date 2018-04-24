namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingBusinessWorkplaceRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessWorkplace",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessFK = c.Guid(nullable: false),
                        WorkplaceFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Business", t => t.BusinessFK, cascadeDelete: true)
                .ForeignKey("dbo.Workplaces", t => t.WorkplaceFK, cascadeDelete: true)
                .Index(t => t.BusinessFK)
                .Index(t => t.WorkplaceFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BusinessWorkplace", "WorkplaceFK", "dbo.Workplaces");
            DropForeignKey("dbo.BusinessWorkplace", "BusinessFK", "dbo.Business");
            DropIndex("dbo.BusinessWorkplace", new[] { "WorkplaceFK" });
            DropIndex("dbo.BusinessWorkplace", new[] { "BusinessFK" });
            DropTable("dbo.BusinessWorkplace");
        }
    }
}
