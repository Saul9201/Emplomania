using Emplomania.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data.Configurations
{
    public class UserConfigurations : EntityTypeConfiguration<User>
    {
        public UserConfigurations()
        {
            ToTable("Users");
            HasKey(x => x.Id);

            HasMany<Employer>(u => u.Employers)
                .WithRequired()
                .HasForeignKey(e => e.UserFK);

            HasMany<Worker>(u => u.Workers)
                .WithRequired()
                .HasForeignKey(w => w.UserFK);

            HasMany<Teacher>(u => u.Teachers)
                .WithRequired()
                .HasForeignKey(t => t.UserFK);

            HasMany<OfferNeed>(u => u.OffersNeeds)
                .WithOptional()
                .HasForeignKey(on => on.UserFK);
        }
    }

    public class EmployerConfigurations : EntityTypeConfiguration<Employer>
    {
        public EmployerConfigurations()
        {
            ToTable("Employers");
            HasKey(e => e.Id);

            HasMany<Business>(e => e.Business)
                .WithOptional()
                .HasForeignKey(b => b.EmployerFK);
        }
    }

    public class WorkerConfigurations : EntityTypeConfiguration<Worker>
    {
        public WorkerConfigurations()
        {
            ToTable("Workers");
            HasKey(w => w.Id);

            HasMany<WorkReference>(w => w.WorkReferences)
                .WithRequired()
                .HasForeignKey(wr => wr.WorkerFK);
            HasMany<WorkerDriverLicense>(w => w.DriverLicenses)
                .WithRequired()
                .HasForeignKey(wdl => wdl.WorkerFK);
            HasMany<WorkerVehicle>(w => w.Vehicles)
                .WithRequired()
                .HasForeignKey(wv => wv.WorkerFK);
            HasMany<WorkerLanguage>(w => w.Languages)
                .WithRequired()
                .HasForeignKey(wl => wl.WorkerFK);
            HasMany<WorkerCourse>(w => w.Courses)
                .WithRequired()
                .HasForeignKey(wc => wc.WorkerFK);
            HasMany<WorkAspiration>(w => w.WorkAspirations)
                .WithRequired()
                .HasForeignKey(wa => wa.WorkerFK);
        }
    }

    public class BusinessConfigurations : EntityTypeConfiguration<Business>
    {
        public BusinessConfigurations()
        {
            ToTable("Business");
            HasKey(b => b.Id);

            HasMany<BusinessWorkplace>(b => b.Workplaces)
                .WithRequired()
                .HasForeignKey(bw => bw.BusinessFK);
        }
    }

    public class BusinessWorkplaceConfigurations : EntityTypeConfiguration<BusinessWorkplace>
    {
        public BusinessWorkplaceConfigurations()
        {
            ToTable("BusinessWorkplace");
            HasKey(x => x.Id);
        }
    }

    public class WorkReferenceConfigurations : EntityTypeConfiguration<WorkReference>
    {
        public WorkReferenceConfigurations()
        {
            ToTable("WorkReferences");
            HasKey(x => x.Id);
        }
    }

    public class WorkAspirationConfigurations : EntityTypeConfiguration<WorkAspiration>
    {
        public WorkAspirationConfigurations()
        {
            ToTable("WorkAspirations");
            HasKey(wa => wa.Id);
        }
    }

    public class WorkerDriverLicenseConfigurations: EntityTypeConfiguration<WorkerDriverLicense>
    {
        public WorkerDriverLicenseConfigurations()
        {
            ToTable("WorkerDriverLicenses");
            HasKey(x => x.Id);
        }
    }

    public class WorkerVehicleConfigurations : EntityTypeConfiguration<WorkerVehicle>
    {
        public WorkerVehicleConfigurations()
        {
            ToTable("WorkerVehicles");
            HasKey(x => x.Id);
        }
    }

    public class WorkerLanguageConfigurations : EntityTypeConfiguration<WorkerLanguage>
    {
        public WorkerLanguageConfigurations()
        {
            ToTable("WorkerLanguages");
            HasKey(x => x.Id);
        }
    }

    public class WorkerCourseConfigurations : EntityTypeConfiguration<WorkerCourse>
    {
        public WorkerCourseConfigurations()
        {
            ToTable("WorkerCourses");
            HasKey(x => x.Id);
        }
    }

    public class TeacherConfigurations : EntityTypeConfiguration<Teacher>
    {
        public TeacherConfigurations()
        {
            ToTable("Teachers");
            HasKey(x => x.Id);
        }
    }
}
