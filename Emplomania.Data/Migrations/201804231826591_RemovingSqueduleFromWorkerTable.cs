namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingSqueduleFromWorkerTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workers", "ScheduleFK", "dbo.Schedules");
            DropIndex("dbo.Workers", new[] { "ScheduleFK" });
            DropColumn("dbo.Workers", "ScheduleFK");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workers", "ScheduleFK", c => c.Guid());
            CreateIndex("dbo.Workers", "ScheduleFK");
            AddForeignKey("dbo.Workers", "ScheduleFK", "dbo.Schedules", "Id");
        }
    }
}
