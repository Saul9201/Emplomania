namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingNullablesAndAddingRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "MunicipalityFK", "dbo.Municipalities");
            DropIndex("dbo.Users", new[] { "MunicipalityFK" });
            AlterColumn("dbo.Business", "CategoryFK", c => c.Guid());
            AlterColumn("dbo.Business", "MunicipalityFK", c => c.Guid());
            AlterColumn("dbo.Users", "MunicipalityFK", c => c.Guid());
            CreateIndex("dbo.Business", "CategoryFK");
            CreateIndex("dbo.Business", "MunicipalityFK");
            CreateIndex("dbo.Users", "MunicipalityFK");
            AddForeignKey("dbo.Business", "CategoryFK", "dbo.Categories", "Id");
            AddForeignKey("dbo.Business", "MunicipalityFK", "dbo.Municipalities", "Id");
            AddForeignKey("dbo.Users", "MunicipalityFK", "dbo.Municipalities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "MunicipalityFK", "dbo.Municipalities");
            DropForeignKey("dbo.Business", "MunicipalityFK", "dbo.Municipalities");
            DropForeignKey("dbo.Business", "CategoryFK", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "MunicipalityFK" });
            DropIndex("dbo.Business", new[] { "MunicipalityFK" });
            DropIndex("dbo.Business", new[] { "CategoryFK" });
            AlterColumn("dbo.Users", "MunicipalityFK", c => c.Guid(nullable: false));
            AlterColumn("dbo.Business", "MunicipalityFK", c => c.Guid(nullable: false));
            AlterColumn("dbo.Business", "CategoryFK", c => c.Guid(nullable: false));
            CreateIndex("dbo.Users", "MunicipalityFK");
            AddForeignKey("dbo.Users", "MunicipalityFK", "dbo.Municipalities", "Id", cascadeDelete: true);
        }
    }
}
