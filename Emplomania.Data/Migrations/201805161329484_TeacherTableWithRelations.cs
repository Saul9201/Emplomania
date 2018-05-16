namespace Emplomania.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherTableWithRelations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NoLicencia = c.String(),
                        NoCarnet = c.String(),
                        Address = c.String(),
                        CoursesDetails = c.String(),
                        UserFK = c.Guid(nullable: false),
                        SchoolGradeFK = c.Guid(),
                        SpecialtyFK = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserFK, cascadeDelete: true)
                .ForeignKey("dbo.SchoolGrades", t => t.SchoolGradeFK)
                .ForeignKey("dbo.Specialties", t => t.SpecialtyFK)
                .Index(t => t.UserFK)
                .Index(t => t.SchoolGradeFK)
                .Index(t => t.SpecialtyFK);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "SpecialtyFK", "dbo.Specialties");
            DropForeignKey("dbo.Teachers", "SchoolGradeFK", "dbo.SchoolGrades");
            DropForeignKey("dbo.Teachers", "UserFK", "dbo.Users");
            DropIndex("dbo.Teachers", new[] { "SpecialtyFK" });
            DropIndex("dbo.Teachers", new[] { "SchoolGradeFK" });
            DropIndex("dbo.Teachers", new[] { "UserFK" });
            DropTable("dbo.Teachers");
        }
    }
}
