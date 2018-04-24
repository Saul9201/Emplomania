namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAspirations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkAspirations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerFK = c.Guid(nullable: false),
                        WorkplaceFK = c.Guid(nullable: false),
                        ScheduleFK = c.Guid(nullable: false),
                        Experience = c.String(),
                        Observations = c.String(),
                        Abilities = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.WorkerFK, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleFK, cascadeDelete: true)
                .ForeignKey("dbo.Workplaces", t => t.WorkplaceFK, cascadeDelete: true)
                .Index(t => t.WorkerFK)
                .Index(t => t.WorkplaceFK)
                .Index(t => t.ScheduleFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkAspirations", "WorkplaceFK", "dbo.Workplaces");
            DropForeignKey("dbo.WorkAspirations", "ScheduleFK", "dbo.Schedules");
            DropForeignKey("dbo.WorkAspirations", "WorkerFK", "dbo.Workers");
            DropIndex("dbo.WorkAspirations", new[] { "ScheduleFK" });
            DropIndex("dbo.WorkAspirations", new[] { "WorkplaceFK" });
            DropIndex("dbo.WorkAspirations", new[] { "WorkerFK" });
            DropTable("dbo.WorkAspirations");
        }
    }
}
