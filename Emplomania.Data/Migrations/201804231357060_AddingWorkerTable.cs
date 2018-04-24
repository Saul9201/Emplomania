namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingWorkerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorkerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerFK = c.Guid(nullable: false),
                        CourseFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.WorkerFK, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseFK, cascadeDelete: true)
                .Index(t => t.WorkerFK)
                .Index(t => t.CourseFK);
            
            CreateTable(
                "dbo.WorkerDriverLicenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerFK = c.Guid(nullable: false),
                        DriverLicenseFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.WorkerFK, cascadeDelete: true)
                .ForeignKey("dbo.DriverLicenses", t => t.DriverLicenseFK, cascadeDelete: true)
                .Index(t => t.WorkerFK)
                .Index(t => t.DriverLicenseFK);
            
            CreateTable(
                "dbo.WorkerLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerFK = c.Guid(nullable: false),
                        LanguageFK = c.Guid(nullable: false),
                        LanguageLevelFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.WorkerFK, cascadeDelete: true)
                .ForeignKey("dbo.LanguageLevels", t => t.LanguageLevelFK, cascadeDelete: true)
                .ForeignKey("dbo.Languages", t => t.LanguageFK, cascadeDelete: true)
                .Index(t => t.WorkerFK)
                .Index(t => t.LanguageFK)
                .Index(t => t.LanguageLevelFK);
            
            CreateTable(
                "dbo.WorkerVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerFK = c.Guid(nullable: false),
                        VehicleFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.WorkerFK, cascadeDelete: true)
                .ForeignKey("dbo.Vehicles", t => t.VehicleFK, cascadeDelete: true)
                .Index(t => t.WorkerFK)
                .Index(t => t.VehicleFK);
            
            CreateTable(
                "dbo.WorkReferences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkerFK = c.Guid(nullable: false),
                        Place = c.String(),
                        Occupation = c.String(),
                        WorkedTime = c.String(),
                        ContactPerson = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Workers", t => t.WorkerFK, cascadeDelete: true)
                .Index(t => t.WorkerFK);
            
            AddColumn("dbo.Workers", "OtherCourses", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkerCourses", "CourseFK", "dbo.Courses");
            DropForeignKey("dbo.WorkerVehicles", "VehicleFK", "dbo.Vehicles");
            DropForeignKey("dbo.WorkerLanguages", "LanguageFK", "dbo.Languages");
            DropForeignKey("dbo.WorkerLanguages", "LanguageLevelFK", "dbo.LanguageLevels");
            DropForeignKey("dbo.WorkerDriverLicenses", "DriverLicenseFK", "dbo.DriverLicenses");
            DropForeignKey("dbo.WorkReferences", "WorkerFK", "dbo.Workers");
            DropForeignKey("dbo.WorkerVehicles", "WorkerFK", "dbo.Workers");
            DropForeignKey("dbo.WorkerLanguages", "WorkerFK", "dbo.Workers");
            DropForeignKey("dbo.WorkerDriverLicenses", "WorkerFK", "dbo.Workers");
            DropForeignKey("dbo.WorkerCourses", "WorkerFK", "dbo.Workers");
            DropIndex("dbo.WorkReferences", new[] { "WorkerFK" });
            DropIndex("dbo.WorkerVehicles", new[] { "VehicleFK" });
            DropIndex("dbo.WorkerVehicles", new[] { "WorkerFK" });
            DropIndex("dbo.WorkerLanguages", new[] { "LanguageLevelFK" });
            DropIndex("dbo.WorkerLanguages", new[] { "LanguageFK" });
            DropIndex("dbo.WorkerLanguages", new[] { "WorkerFK" });
            DropIndex("dbo.WorkerDriverLicenses", new[] { "DriverLicenseFK" });
            DropIndex("dbo.WorkerDriverLicenses", new[] { "WorkerFK" });
            DropIndex("dbo.WorkerCourses", new[] { "CourseFK" });
            DropIndex("dbo.WorkerCourses", new[] { "WorkerFK" });
            DropColumn("dbo.Workers", "OtherCourses");
            DropTable("dbo.WorkReferences");
            DropTable("dbo.WorkerVehicles");
            DropTable("dbo.WorkerLanguages");
            DropTable("dbo.WorkerDriverLicenses");
            DropTable("dbo.WorkerCourses");
        }
    }
}
