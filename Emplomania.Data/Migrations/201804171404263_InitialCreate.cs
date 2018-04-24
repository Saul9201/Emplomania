namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Role = c.Int(nullable: false),
                        PasswordHash = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CivilStatuses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BornDate = c.DateTime(),
                        Stature = c.Single(nullable: false),
                        Childrens = c.Boolean(nullable: false),
                        Barriada = c.String(),
                        Abilities = c.String(),
                        Salary = c.String(),
                        Experience = c.String(),
                        EyeColorFK = c.Guid(),
                        SkinColorFK = c.Guid(),
                        ComplexionFK = c.Guid(),
                        GenderFK = c.Guid(),
                        CivilStatusFK = c.Guid(),
                        SchoolGradeFK = c.Guid(),
                        SpecialtyFK = c.Guid(),
                        ScheduleFK = c.Guid(),
                        UserFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CivilStatuses", t => t.CivilStatusFK)
                .ForeignKey("dbo.Complexions", t => t.ComplexionFK)
                .ForeignKey("dbo.EyeColors", t => t.EyeColorFK)
                .ForeignKey("dbo.Users", t => t.UserFK, cascadeDelete: true)
                .ForeignKey("dbo.Schedules", t => t.ScheduleFK)
                .ForeignKey("dbo.SchoolGrades", t => t.SchoolGradeFK)
                .ForeignKey("dbo.SkinColors", t => t.SkinColorFK)
                .ForeignKey("dbo.Specialties", t => t.SpecialtyFK)
                .ForeignKey("dbo.Genders", t => t.GenderFK)
                .Index(t => t.EyeColorFK)
                .Index(t => t.SkinColorFK)
                .Index(t => t.ComplexionFK)
                .Index(t => t.GenderFK)
                .Index(t => t.CivilStatusFK)
                .Index(t => t.SchoolGradeFK)
                .Index(t => t.SpecialtyFK)
                .Index(t => t.ScheduleFK)
                .Index(t => t.UserFK);
            
            CreateTable(
                "dbo.Complexions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DriverLicenses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EyeColors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LanguageLevels",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Memberships",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Municipalities",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProvinceFK = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provinces", t => t.ProvinceFK, cascadeDelete: true)
                .Index(t => t.ProvinceFK);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        MovilPhoneNumber = c.String(),
                        HomePhoneNumber = c.String(),
                        Email = c.String(),
                        Name = c.String(),
                        LastName = c.String(),
                        LastName2 = c.String(),
                        PrivateAddress = c.String(),
                        Verified = c.Boolean(nullable: false),
                        Balance = c.Single(nullable: false),
                        ProfileImage = c.Binary(),
                        MunicipalityFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Municipalities", t => t.MunicipalityFK, cascadeDelete: true)
                .Index(t => t.MunicipalityFK);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NoLicencia = c.String(),
                        UserFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserFK, cascadeDelete: true)
                .Index(t => t.UserFK);
            
            CreateTable(
                "dbo.Business",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EmployerFK = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employers", t => t.EmployerFK, cascadeDelete: true)
                .Index(t => t.EmployerFK);
            
            CreateTable(
                "dbo.Prizes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SchoolGrades",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SkinColors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Workplaces",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "GenderFK", "dbo.Genders");
            DropForeignKey("dbo.Workers", "SpecialtyFK", "dbo.Specialties");
            DropForeignKey("dbo.Workers", "SkinColorFK", "dbo.SkinColors");
            DropForeignKey("dbo.Workers", "SchoolGradeFK", "dbo.SchoolGrades");
            DropForeignKey("dbo.Workers", "ScheduleFK", "dbo.Schedules");
            DropForeignKey("dbo.Municipalities", "ProvinceFK", "dbo.Provinces");
            DropForeignKey("dbo.Users", "MunicipalityFK", "dbo.Municipalities");
            DropForeignKey("dbo.Workers", "UserFK", "dbo.Users");
            DropForeignKey("dbo.Employers", "UserFK", "dbo.Users");
            DropForeignKey("dbo.Business", "EmployerFK", "dbo.Employers");
            DropForeignKey("dbo.Workers", "EyeColorFK", "dbo.EyeColors");
            DropForeignKey("dbo.Workers", "ComplexionFK", "dbo.Complexions");
            DropForeignKey("dbo.Workers", "CivilStatusFK", "dbo.CivilStatuses");
            DropIndex("dbo.Business", new[] { "EmployerFK" });
            DropIndex("dbo.Employers", new[] { "UserFK" });
            DropIndex("dbo.Users", new[] { "MunicipalityFK" });
            DropIndex("dbo.Municipalities", new[] { "ProvinceFK" });
            DropIndex("dbo.Workers", new[] { "UserFK" });
            DropIndex("dbo.Workers", new[] { "ScheduleFK" });
            DropIndex("dbo.Workers", new[] { "SpecialtyFK" });
            DropIndex("dbo.Workers", new[] { "SchoolGradeFK" });
            DropIndex("dbo.Workers", new[] { "CivilStatusFK" });
            DropIndex("dbo.Workers", new[] { "GenderFK" });
            DropIndex("dbo.Workers", new[] { "ComplexionFK" });
            DropIndex("dbo.Workers", new[] { "SkinColorFK" });
            DropIndex("dbo.Workers", new[] { "EyeColorFK" });
            DropTable("dbo.Genders");
            DropTable("dbo.Courses");
            DropTable("dbo.Workplaces");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Specialties");
            DropTable("dbo.SkinColors");
            DropTable("dbo.SchoolGrades");
            DropTable("dbo.Schedules");
            DropTable("dbo.Provinces");
            DropTable("dbo.Prizes");
            DropTable("dbo.Business");
            DropTable("dbo.Employers");
            DropTable("dbo.Users");
            DropTable("dbo.Municipalities");
            DropTable("dbo.Memberships");
            DropTable("dbo.Languages");
            DropTable("dbo.LanguageLevels");
            DropTable("dbo.EyeColors");
            DropTable("dbo.DriverLicenses");
            DropTable("dbo.Currencies");
            DropTable("dbo.Complexions");
            DropTable("dbo.Workers");
            DropTable("dbo.CivilStatuses");
            DropTable("dbo.Categories");
            DropTable("dbo.AdminUsers");
        }
    }
}
