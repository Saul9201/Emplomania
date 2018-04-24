namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingWorkAspirationTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WorkAspirations", "ScheduleFK", "dbo.Schedules");
            DropForeignKey("dbo.WorkAspirations", "WorkplaceFK", "dbo.Workplaces");
            DropIndex("dbo.WorkAspirations", new[] { "WorkplaceFK" });
            DropIndex("dbo.WorkAspirations", new[] { "ScheduleFK" });
            AlterColumn("dbo.WorkAspirations", "WorkplaceFK", c => c.Guid());
            AlterColumn("dbo.WorkAspirations", "ScheduleFK", c => c.Guid());
            CreateIndex("dbo.WorkAspirations", "WorkplaceFK");
            CreateIndex("dbo.WorkAspirations", "ScheduleFK");
            AddForeignKey("dbo.WorkAspirations", "ScheduleFK", "dbo.Schedules", "Id");
            AddForeignKey("dbo.WorkAspirations", "WorkplaceFK", "dbo.Workplaces", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkAspirations", "WorkplaceFK", "dbo.Workplaces");
            DropForeignKey("dbo.WorkAspirations", "ScheduleFK", "dbo.Schedules");
            DropIndex("dbo.WorkAspirations", new[] { "ScheduleFK" });
            DropIndex("dbo.WorkAspirations", new[] { "WorkplaceFK" });
            AlterColumn("dbo.WorkAspirations", "ScheduleFK", c => c.Guid(nullable: false));
            AlterColumn("dbo.WorkAspirations", "WorkplaceFK", c => c.Guid(nullable: false));
            CreateIndex("dbo.WorkAspirations", "ScheduleFK");
            CreateIndex("dbo.WorkAspirations", "WorkplaceFK");
            AddForeignKey("dbo.WorkAspirations", "WorkplaceFK", "dbo.Workplaces", "Id", cascadeDelete: true);
            AddForeignKey("dbo.WorkAspirations", "ScheduleFK", "dbo.Schedules", "Id", cascadeDelete: true);
        }
    }
}
