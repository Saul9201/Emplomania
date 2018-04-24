using Emplomania.Data.Configurations;
using Emplomania.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emplomania.Data
{
    public class EmplomaniaAdminDBContext : DbContext
    {
        public EmplomaniaAdminDBContext():base("EmplomaniaAdminDBContext")
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CivilStatus> CivilStatuses { get; set; }
        public DbSet<Complexion> Complexios { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<DriverLicense> DriverLicenses { get; set; }
        public DbSet<EyeColor> EyeColors { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageLevel> LanguageLevels { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Prize> Prizes { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<SchoolGrade> SchoolGrades { get; set; }
        public DbSet<SkinColor> SkinColors { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Business> Business { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<BusinessWorkplace> BusinessWorkplaces { get; set; }
        public DbSet<WorkReference> WorkReferences { get; set; }
        public DbSet<WorkerDriverLicense> WorkerDriverLicenses { get; set; }
        public DbSet<WorkerVehicle> WorkerVehicles { get; set; }
        public DbSet<WorkerLanguage> WorkerLanguages { get; set; }
        public DbSet<WorkerCourse> WorkerCourses { get; set; }
        public DbSet<WorkAspiration> WorkAspirations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(typeof(CategoryConfiguration).Assembly);
        }

        public bool CreateDbIfNotExcist()
        {
            var dbc = this.Database.CreateIfNotExists();
            return dbc;
        }

        public void UndoChanges()
        {
            var changedEntries = this.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }
        }
    }
}
