using Emplomania.Model;
using Emplomania.Model.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.Configurations
{
    internal class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Categories");

            HasMany<Business>(c => c.Business)
                .WithOptional()
                .HasForeignKey(b => b.CategoryFK);

            HasMany<Course>(c => c.Courses)
                .WithOptional()
                .HasForeignKey(co => co.CategoryFK);
        }
    }

    internal class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Courses");

            HasMany<WorkerCourse>(c => c.Workers)
                .WithRequired()
                .HasForeignKey(wc => wc.CourseFK);
        }
    }

    internal class CivilStatusConfiguration : EntityTypeConfiguration<CivilStatus>
    {
        public CivilStatusConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("CivilStatuses");

            HasMany<Worker>(cs =>cs.Workers)
                .WithOptional()
                .HasForeignKey(w => w.CivilStatusFK);
        }
    }

    internal class ComplexionConfiguration : EntityTypeConfiguration<Complexion>
    {
        public ComplexionConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Complexions");

            HasMany<Worker>(c => c.Workers)
                .WithOptional()
                .HasForeignKey(w => w.ComplexionFK);
        }
    }

    internal class CurrencyConfiguration : EntityTypeConfiguration<Currency>
    {
        public CurrencyConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Currencies");
        }
    }

    internal class DriverLicenseConfiguration : EntityTypeConfiguration<DriverLicense>
    {
        public DriverLicenseConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("DriverLicenses");

            HasMany<WorkerDriverLicense>(dl => dl.Workers)
                .WithRequired()
                .HasForeignKey(wdl => wdl.DriverLicenseFK);
        }
    }

    internal class GenderConfiguration : EntityTypeConfiguration<Gender>
    {
        public GenderConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Genders");

            HasMany<Worker>(g => g.Workers)
                .WithOptional()
                .HasForeignKey(w => w.GenderFK);
        }
    }

    internal class EyeColorConfiguration : EntityTypeConfiguration<EyeColor>
    {
        public EyeColorConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("EyeColors");

            HasMany<Worker>(ec => ec.Workers)
                .WithOptional()
                .HasForeignKey(w => w.EyeColorFK);
        }
    }
    
    internal class LanguageConfiguration : EntityTypeConfiguration<Language>
    {
        public LanguageConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Languages");

            HasMany<WorkerLanguage>(l => l.Workers)
                .WithRequired()
                .HasForeignKey(wl => wl.LanguageFK);
        }
    }

    internal class LanguageLevelConfiguration : EntityTypeConfiguration<LanguageLevel>
    {
        public LanguageLevelConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("LanguageLevels");

            HasMany<WorkerLanguage>(ll => ll.WorkerLanguages)
                .WithRequired()
                .HasForeignKey(wl => wl.LanguageLevelFK);
        }
    }

    internal class AditionalServiceConfiguration : EntityTypeConfiguration<AditionalService>
    {
        public AditionalServiceConfiguration()
        {
            ToTable("AditionalServices");
            HasKey(x => x.Id);

            HasMany<User>(s => s.Users)
                .WithOptional()
                .HasForeignKey(u => u.AditionalServiceFK);

            HasMany<Income>(s => s.Income)
                .WithOptional()
                .HasForeignKey(i => i.AditionalServiceFK);
        }
    }

    internal class MembershipConfiguration : EntityTypeConfiguration<Membership>
    {
        public MembershipConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Memberships");

            HasMany<User>(x => x.Users)
                .WithOptional()
                .HasForeignKey(x => x.MembershipFK);

            HasMany<Income>(m => m.Income)
            .WithOptional()
            .HasForeignKey(i => i.MembershipFK);

        }
    }

    internal class MunicipalityConfiguration : EntityTypeConfiguration<Municipality>
    {
        public MunicipalityConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Municipalities");


            HasMany<User>(m => m.Users)
                .WithOptional()
                .HasForeignKey(u => u.MunicipalityFK);
            HasMany<Business>(m => m.Business)
                .WithOptional()
                .HasForeignKey(b => b.MunicipalityFK);
        }
    }

    internal class PrizeConfiguration : EntityTypeConfiguration<Prize>
    {
        public PrizeConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Prizes");
        }
    }

    internal class ProvinceConfiguration : EntityTypeConfiguration<Province>
    {
        public ProvinceConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Provinces");

            HasMany<Municipality>(x => x.Municipalities)
                .WithRequired()
                .HasForeignKey(c => c.ProvinceFK);
        }
    }

    internal class ScheduleConfiguration : EntityTypeConfiguration<Schedule>
    {
        public ScheduleConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Schedules");

            HasMany<WorkAspiration>(s => s.WorkAspirations)
                .WithOptional()
                .HasForeignKey(wa => wa.ScheduleFK);
        }
    }

    internal class SchoolGradeConfiguration : EntityTypeConfiguration<SchoolGrade>
    {
        public SchoolGradeConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("SchoolGrades");

            HasMany<Worker>(sg => sg.Workers)
                .WithOptional()
                .HasForeignKey(w => w.SchoolGradeFK);

            HasMany<Teacher>(sg => sg.Teachers)
                .WithOptional()
                .HasForeignKey(t => t.SchoolGradeFK);
        }
    }

    internal class SkinColorConfiguration : EntityTypeConfiguration<SkinColor>
    {
        public SkinColorConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("SkinColors");

            HasMany<Worker>(sc => sc.Workers)
                .WithOptional()
                .HasForeignKey(w => w.SkinColorFK);
        }
    }

    internal class SpecialtyConfiguration : EntityTypeConfiguration<Specialty>
    {
        public SpecialtyConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Specialties");

            HasMany<Worker>(sp => sp.Workers)
                .WithOptional()
                .HasForeignKey(w => w.SpecialtyFK);

            HasMany<Teacher>(sp => sp.Teachers)
                .WithOptional()
                .HasForeignKey(t => t.SpecialtyFK);
        }
    }

    internal class VehicleConfiguration : EntityTypeConfiguration<Vehicle>
    {
        public VehicleConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Vehicles");

            HasMany<WorkerVehicle>(v => v.Workers)
                .WithRequired()
                .HasForeignKey(wv => wv.VehicleFK);
        }
    }

    internal class WorkplaceConfiguration : EntityTypeConfiguration<Workplace>
    {
        public WorkplaceConfiguration()
        {
            HasKey(x => x.Id);
            ToTable("Workplaces");

            HasMany<BusinessWorkplace>(w => w.Business)
                .WithRequired()
                .HasForeignKey(bw => bw.WorkplaceFK);
            HasMany<WorkAspiration>(wp => wp.WorkAspirations)
                .WithOptional()
                .HasForeignKey(wa => wa.WorkplaceFK);
            HasMany<OfferNeed>(wp => wp.OffersNeeds)
                .WithOptional()
                .HasForeignKey(on => on.WorkplaceFK);
        }
        
    }
}
