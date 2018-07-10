namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropsToCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CategoryFK", c => c.Guid());
            AddColumn("dbo.Courses", "Details", c => c.String());
            AddColumn("dbo.Courses", "Duration", c => c.String());
            AddColumn("dbo.Courses", "Frequency", c => c.String());
            AddColumn("dbo.Courses", "TimeToRegister", c => c.String());
            AddColumn("dbo.Courses", "Contact", c => c.String());
            CreateIndex("dbo.Courses", "CategoryFK");
            AddForeignKey("dbo.Courses", "CategoryFK", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "CategoryFK", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryFK" });
            DropColumn("dbo.Courses", "Contact");
            DropColumn("dbo.Courses", "TimeToRegister");
            DropColumn("dbo.Courses", "Frequency");
            DropColumn("dbo.Courses", "Duration");
            DropColumn("dbo.Courses", "Details");
            DropColumn("dbo.Courses", "CategoryFK");
        }
    }
}
