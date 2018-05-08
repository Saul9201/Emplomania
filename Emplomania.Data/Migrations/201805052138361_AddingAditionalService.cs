namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAditionalService : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AditionalServices",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserType = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "AditionalServiceFK", c => c.Guid());
            CreateIndex("dbo.Users", "AditionalServiceFK");
            AddForeignKey("dbo.Users", "AditionalServiceFK", "dbo.AditionalServices", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "AditionalServiceFK", "dbo.AditionalServices");
            DropIndex("dbo.Users", new[] { "AditionalServiceFK" });
            DropColumn("dbo.Users", "AditionalServiceFK");
            DropTable("dbo.AditionalServices");
        }
    }
}
